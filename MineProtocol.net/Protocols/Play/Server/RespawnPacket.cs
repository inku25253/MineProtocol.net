using LibMinecraft;

namespace MineProtocol.net.Protocols.Play.Server
{
	public struct RespawnPacket :IPacketData
	{
		#region IPacketData メンバー

		public int ProtocolId
		{
			get { return 0x07; }
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

		public Dimension Dimension;
		public Difficulty Difficulty;
		public Gamemode Gamemode;
		public LevelType Level;

		public RespawnPacket(Dimension dimension, Difficulty difficulty, Gamemode gamemode, LevelType level)
		{
			Dimension = dimension;
			Difficulty = difficulty;
			Gamemode = gamemode;
			Level = level;
		}
	}
}