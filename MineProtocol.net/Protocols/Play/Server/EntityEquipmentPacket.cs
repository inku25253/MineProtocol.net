namespace MineProtocol.net.Protocols.Play.Server
{
	public struct EntityEquipmentPacket :IPacketData
	{
		#region IPacketData メンバー

		public int ProtocolId
		{
			get { return 0x04; }
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

		public int EntityId;
		//TODO: Slotができたら
	}
}