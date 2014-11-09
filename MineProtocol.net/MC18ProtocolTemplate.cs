using LibMinecraft;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets.Plus;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net
{
	public class MC18ProtocolTemplate : IPacketEncoder<MinecraftClient, IPacketData, IPacketData>, IPacketDecoder<MinecraftClient, IPacketData, IPacketData>
	{


		public MC18ProtocolTemplate()
		{

		}




		#region IPacketDecoder<object,IPacketData,IPacketData> メンバー

		public IPacketData Decode(
			object sender,
			SocketClient<MinecraftClient, IPacketData, IPacketData> client,
			SocketStream<MinecraftClient, IPacketData, IPacketData> stream
		)
		{
			MinecraftStream mineStream = new MinecraftStream(stream);
			int length = mineStream.ReadVarint();
			byte[] buff = mineStream.Read(length);
			MinecraftStream readerStream = new MinecraftStream(new MemoryStream(buff));
			IPacketData result = client.State.ProtocolEngine.Read(readerStream);

			//client.State.ProtocolEngine.Read()
			return result;
		}

		#endregion

		#region IPacketEncoder<object,IPacketData,IPacketData> メンバー

		public byte[] Encode(
			IPacketData packet,
			SocketClient<MinecraftClient, IPacketData, IPacketData> client
		)
		{
			MinecraftStream mineStream = new MinecraftStream();
			mineStream.Write(packet.ProtocolId);
			client.State.ProtocolEngine.Write(packet, mineStream);

			byte[] size = MinecraftStream.GetVarintBytes((int)mineStream.Position);

			byte[] result = new byte[size.Length + mineStream.Position];
			byte[] memoryPacket = (mineStream.BaseStream as MemoryStream).ToArray();

			Buffer.BlockCopy(size, 0, result, 0, size.Length);
			Buffer.BlockCopy(memoryPacket, 0, result, size.Length, memoryPacket.Length);

			return result;


		}

		#endregion
	}
}
