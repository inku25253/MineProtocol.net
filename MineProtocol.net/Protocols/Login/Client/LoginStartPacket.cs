using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net.Protocols.Login.Client
{
	public struct LoginStartPacket : IPacketData
	{

		public string Name;

		public int ProtocolId
		{
			get { return 0x00; }
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
			get { return Side.Client; }
		}

		public LoginStartPacket(string name)
		{
			Name = name;	
		}
	}
}
