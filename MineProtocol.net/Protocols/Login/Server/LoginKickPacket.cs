namespace MineProtocol.net.Protocols.Login.Server
{
	public struct LoginKickPacket :IPacketData
	{
		public LoginKickPacket(string result)
		{
			Result = result;
		}

		public string Result;

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
			get { return Side.Server; }
		}

	}
}
