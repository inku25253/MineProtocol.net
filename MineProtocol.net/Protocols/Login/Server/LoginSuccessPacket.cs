namespace MineProtocol.net.Protocols.Login.Server
{
	public class LoginSuccessPacket : IPacketData
	{

		public string Uuid;
		public string UserName;


		public int ProtocolId
		{
			get { return 0x02; }
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
