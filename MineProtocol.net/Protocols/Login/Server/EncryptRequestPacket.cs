using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net.Protocols.Login.Server
{
	public class EncryptRequestPacket : IPacketData
	{


		public string ServerID;
		public byte[] PublicKey;
		public byte[] VerifyToken;


		public int ProtocolId
		{
			get { return 0x01; }
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
			get { return Side.Server; }
		}
	}
}
