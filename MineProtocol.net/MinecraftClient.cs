using MineProtocol.net.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net
{
	public class MinecraftClient
	{

		public ProtocolEngine ProtocolEngine { get; internal set; }
		public int ClientID;

		public MinecraftClient(ProtocolVersion version, Side side)
		{
			ProtocolEngine = new ProtocolEngine(version, side);
			MC18PacketWriter.RegistWriters(ProtocolEngine);
			MC18PacketReader.RegistReaders(ProtocolEngine);
			ProtocolEngine.Flush();
		}


	}
}
