namespace MineProtocol.net.Protocols.Play.Server
{
	public struct PlayerAbilityPacket :IPacketData
	{
		#region IPacketData メンバー

		public int ProtocolId
		{
			get { return 0x39; }
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

		public byte Flag;
	}
}