namespace MineProtocol.net.Protocols.Play.Server
{
	public struct TabCompletePacket :IPacketData
	{
		#region IPacketData メンバー

		public int ProtocolId
		{
			get { return 0x3A; }
		}

		public ProtocolState ProtocolStatus
		{
			get { return ProtocolState.Play; }
		}

		public Side Sides
		{
			get { return Side.Server; }
		}

		#endregion

		public string[] Match;

		public TabCompletePacket(string[] match)
		{
			Match = match;	
		}
	}
}