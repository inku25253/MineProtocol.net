using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net.Protocols.Status
{
	public class StatusPingPacket : IPacketData
	{

		public long Time;
		public int ProtocolId
		{
			get { return 0x01; }
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
			get { return Side.Client | Side.Server; }
		}
	}
}
