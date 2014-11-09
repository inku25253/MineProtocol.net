
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net.Protocols.Handshake.Client
{
	public class HandshakePacket : IPacketData
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
				return ProtocolState.HANDSHAKE;
			}
		}
		public Side Sides
		{
			get { return Side.Client; }
		}
	}
}
