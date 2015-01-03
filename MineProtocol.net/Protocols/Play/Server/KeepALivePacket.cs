namespace MineProtocol.net.Protocols.Play.Server
{
	public struct KeepALivePacket :IPacketData
	{
		#region IPacketData メンバー

		public int ProtocolId
		{
			get { return 0x00; }
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

		public int LiveId;

		public KeepALivePacket(int liveId)
		{
			LiveId = liveId;
		}
	}
}
