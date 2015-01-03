namespace MineProtocol.net.Protocols.Play.Server
{
	public struct TimeUpdatePacket :IPacketData
	{
		#region IPacketData メンバー

		public int ProtocolId
		{
			get { return 0x03; }
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

		public long WorldTime;
		public long DayTime;

		public TimeUpdatePacket(long worldTime, long dayTime)
		{
			WorldTime = worldTime;
			DayTime = dayTime;
		}
	}
}