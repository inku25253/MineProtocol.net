namespace MineProtocol.net.Protocols.Play.Server
{
	public struct KickPacket :IPacketData
	{
		public KickPacket(string reason)
		{
			Reason = reason;
		}
		public string Reason;

		#region IPacketData メンバー

		public int ProtocolId
		{
			get { return 0x40; }
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
	}
}
