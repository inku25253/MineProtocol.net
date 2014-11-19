using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineProtocol.net.Protocols.Handshake.Client;

namespace MineProtocol.net.Events.Handshake
{
	public class HandshakeEventArgs :MinecraftPacketEventArgs<HandshakePacket>
	{

		public ProtocolState NextState { get { return Packet.NextState; } set { Packet.NextState = value; } }
		public ProtocolVersion Version { get { return Packet.Version; } set { Packet.Version = value; } }
		public string Host { get { return Packet.ServerAddress; } set { Packet.ServerAddress = value; } }
		public ushort Port { get { return Packet.ServerPort; } set { Packet.ServerPort = value; } }

		public HandshakeEventArgs(MinecraftClient client, HandshakePacket packet)
			: base(client, packet)
		{
		}
	}
}
