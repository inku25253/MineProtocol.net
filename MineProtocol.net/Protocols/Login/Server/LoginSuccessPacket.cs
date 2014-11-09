using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net.Protocols.Login.Server
{
	public class LoginSuccessPacket : IPacketData
	{

		public string UUID;
		public string UserName;


		public int ProtocolId
		{
			get { return 0x02; }
		}
		public ProtocolState ProtocolStatus
		{
			get
			{
				return ProtocolState.LOGIN;
			}
		}
		public Side Sides
		{
			get { return Side.ServerToClient; }
		}
	}
}
