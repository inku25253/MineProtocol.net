using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net.Protocols.Login.Server
{
	public class SetCompressionPacket : IPacketData
	{
		public int Threshold;
		public int ProtocolId
		{
			get { return 0x03; }
		}
		public ProtocolState ProtocolStatus
		{
			get
			{
				return ProtocolState.Login;
			}
		}
		public Side Sides
		{
			get { return Side.Server; }
		}
	}
}
