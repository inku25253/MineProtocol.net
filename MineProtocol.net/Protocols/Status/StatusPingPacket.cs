namespace MineProtocol.net.Protocols.Status
{
	public struct StatusPingPacket :IPacketData
	{
		public StatusPingPacket(long time)
		{
			Time = time;	
		}
		public long Time;
		public int ProtocolId
		{
			get { return 0x01; }
		}
		public ProtocolState ProtocolStatus
		{
			get
			{
				return ProtocolState.Status;
			}
		}
		public Side Sides
		{
			get { return Side.Client | Side.Server; }
		}
	}
}
