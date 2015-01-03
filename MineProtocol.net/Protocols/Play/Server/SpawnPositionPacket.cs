using LibMinecraft;

namespace MineProtocol.net.Protocols.Play.Server
{
	public struct SpawnPositionPacket :IPacketData
	{
		#region IPacketData メンバー

		public int ProtocolId
		{
			get { return 0x05; }
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

		public Vector3 Position;

		public SpawnPositionPacket(Vector3 position)
		{
			Position = position;
		}
	}
}