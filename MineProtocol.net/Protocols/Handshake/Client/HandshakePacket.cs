﻿
namespace MineProtocol.net.Protocols.Handshake.Client
{
	public struct HandshakePacket :IPacketData
	{
		public ProtocolVersion Version;
		public string ServerAddress;
		public ushort ServerPort;
		public ProtocolState NextState;


		public int ProtocolId
		{
			get { return 0x00; }
		}

		public ProtocolState ProtocolStatus
		{
			get
			{
				return ProtocolState.Handshake;
			}
		}
		public Side Sides
		{
			get { return Side.Client; }
		}
	}
}
