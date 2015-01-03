namespace MineProtocol.net.Protocols.Play.Server
{
	public struct PluginMessagePacket :IPacketData
	{
		#region IPacketData メンバー

		public int ProtocolId
		{
			get { return 0x17; }
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

		public string Channel;
		public byte[] Data;

		public PluginMessagePacket(string channel, byte[] data)
		{
			Channel = channel;
			Data = data;
		}
	}
}