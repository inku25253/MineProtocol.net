using LibMinecraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net
{
	public class ProtocolEngine
	{
		//Dictionary<VersionInfo,Dictionary<Side,Dictionary<ProtocolState,Dictionary<Type,IPacketData>> >> 




		ProtocolEngineDictionary writerDictionary;
		ProtocolEngineDictionary readerDictionary;


		public ProtocolEngine(ProtocolVersion version, Side side)
		{
			writerDictionary = new ProtocolEngineDictionary(version)
			{
				Side = side,
				State = ProtocolState.HANDSHAKE
			};

			readerDictionary = new ProtocolEngineDictionary(version)
			{
				Side = side == net.Side.ClientToServer ? Side.ServerToClient : net.Side.ClientToServer,
				State = ProtocolState.HANDSHAKE
			};


		}


		public void Write(IPacketData packetData, MinecraftStream stream)
		{
			Delegate writer = writerDictionary[packetData.GetType()];//as PacketWriter<T>);
			if (writer != null)
				writer.DynamicInvoke(packetData, stream);//writer(packetData, stream);
		}

		public IPacketData Read(MinecraftStream stream)
		{
			//data = null;
			try
			{
				int protocolId = stream.ReadVarint();
				Delegate reader = readerDictionary.Get(protocolId); //as PacketReader)(stream);

				if (reader != null)
					return reader.DynamicInvoke(stream) as IPacketData;
			}
			catch { }
			return null;
		}


		public void RegistWriter<T>(PacketWriter<T> writer) where T : IPacketData
		{
			IPacketData packetData = (Activator.CreateInstance(typeof(T)) as IPacketData);
			this.writerDictionary.Add(typeof(T), packetData.ProtocolId, packetData.Sides, packetData.ProtocolStatus, writer);
		}
		public void RegistReader<T>(PacketReader<T> reader) where T : IPacketData
		{
			IPacketData packetData = (Activator.CreateInstance(typeof(T)) as IPacketData);
			this.readerDictionary.Add(typeof(T), packetData.ProtocolId, packetData.Sides, packetData.ProtocolStatus, reader);
		}
		public ProtocolState State
		{
			get
			{
				return this.writerDictionary.State;
			}
			set
			{
				this.writerDictionary.State = value;
				this.readerDictionary.State = value;
			}
		}
		public Side Side
		{
			get
			{
				return this.writerDictionary.Side;
			}
			set
			{
				this.writerDictionary.Side = value;
				this.readerDictionary.Side = (value == net.Side.ClientToServer) ? Side.ServerToClient : net.Side.ClientToServer;

			}
		}
		public ProtocolVersion Version
		{

			get
			{
				return this.writerDictionary.UsingVersion;
			}
			set
			{
				this.writerDictionary.UsingVersion = value;
				this.readerDictionary.UsingVersion = value;
			}
		}

		public void Flush()
		{
			this.writerDictionary.Flush();
			this.readerDictionary.Flush();
		}
	}

	public delegate void PacketWriter<T>(T data, MinecraftStream ms) where T : IPacketData;
	public delegate T PacketReader<T>(MinecraftStream ms) where T : IPacketData;
}
