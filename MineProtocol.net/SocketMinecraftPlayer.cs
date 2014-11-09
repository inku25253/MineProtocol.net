using MineProtocol.net.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net
{
	public class SocketMinecraftPlayer
	{

		public ProtocolEngine ProtocolEngine { get; internal set; }
		public int ClientID;

		public SocketMinecraftPlayer()
		{
			ProtocolEngine = new ProtocolEngine(ProtocolVersion.MC1_8, Side.ClientToServer);
			MC18PacketWriter.RegistWriters(ProtocolEngine);
			MC18PacketReader.RegistReaders(ProtocolEngine);
			ProtocolEngine.Flush();
		}


	}
}
