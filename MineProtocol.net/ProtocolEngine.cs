using LibMinecraft;
using System;

namespace MineProtocol.net
{
	public class ProtocolEngine
	{


		readonly ProtocolEngineDictionary _writerDictionary;
		readonly ProtocolEngineDictionary _readerDictionary;


		public ProtocolEngine(ProtocolVersion version, Side side)
		{
			_writerDictionary = new ProtocolEngineDictionary(version)
			{
				Side = side,
				State = ProtocolState.Handshake
			};

			_readerDictionary = new ProtocolEngineDictionary(version)
			{
				Side = side == Side.Client ? Side.Server : Side.Client,
				State = ProtocolState.Handshake
			};


		}


		public void Write(IPacketData packetData, MinecraftStream stream)
		{
			Delegate writer = _writerDictionary[packetData.GetType()];
			if(writer != null)
				writer.DynamicInvoke(packetData, stream);
		}

		public IPacketData Read(MinecraftStream stream)
		{
			int protocolId = stream.ReadVarint();
			Delegate reader = _readerDictionary.Get(protocolId); 

			if(reader != null)
			{
				return reader.DynamicInvoke(stream) as IPacketData;
			}
			return null;
		}


		public void RegistWriter<T>(PacketWriter<T> writer) where T :IPacketData
		{
			IPacketData packetData = (Activator.CreateInstance(typeof(T)) as IPacketData);
			if(packetData == null)
				throw new ArgumentException("T");
			this._writerDictionary.Add(typeof(T), packetData.ProtocolId, packetData.Sides, packetData.ProtocolStatus, writer);
		}
		public void RegistReader<T>(PacketReader<T> reader) where T :IPacketData
		{
			IPacketData packetData = (Activator.CreateInstance(typeof(T)) as IPacketData);
			if(packetData == null)
				throw new ArgumentException("T");
			this._readerDictionary.Add(typeof(T), packetData.ProtocolId, packetData.Sides, packetData.ProtocolStatus, reader);
		}
		public ProtocolState State
		{
			get
			{
				return this._writerDictionary.State;
			}
			set
			{
				this._writerDictionary.State = value;
				this._readerDictionary.State = value;
			}
		}
		public Side Side
		{
			get
			{
				return this._writerDictionary.Side;
			}
			set
			{
				this._writerDictionary.Side = value;
				this._readerDictionary.Side = (value == Side.Client) ? Side.Server : Side.Client;

			}
		}
		public ProtocolVersion Version
		{

			get
			{
				return this._writerDictionary.UsingVersion;
			}
			set
			{
				this._writerDictionary.UsingVersion = value;
				this._readerDictionary.UsingVersion = value;
			}
		}

		public void Flush()
		{
			this._writerDictionary.Flush();
			this._readerDictionary.Flush();
		}
	}

	public delegate void PacketWriter<in T>(T data, MinecraftStream ms) where T :IPacketData;
	public delegate T PacketReader<out T>(MinecraftStream ms) where T :IPacketData;
}
