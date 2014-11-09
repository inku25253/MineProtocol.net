using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net.Protocols.Status.Client
{
	public class StatusRequestPacket : IPacketData
	{
		public int ProtocolId
		{
			get { return 0x00; }
		}
		public ProtocolState ProtocolStatus
		{
			get
			{
				return ProtocolState.STATUS;
			}
		}
		public Side Sides
		{
			get { return Side.ClientToServer; }
		}
	}
}
