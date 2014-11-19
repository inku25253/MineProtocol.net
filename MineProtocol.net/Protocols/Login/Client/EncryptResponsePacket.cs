using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net.Protocols.Login.Client
{
	public class EncryptResponsePacket : IPacketData
	{
		public byte[] SharedSecret;
		public byte[] VerifyToken;


		public int ProtocolId
		{
			get { return 0x01; }
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
	}
}
