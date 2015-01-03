using LibMinecraft;

namespace MineProtocol.net.Protocols.Play.Server
{
	public struct JoinGamePacket :IPacketData
	{
		#region IPacketData メンバー

		public int ProtocolId
		{
			get { return 0x01; }
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
		public Gamemode Gamemode;
		public Dimension Dimension;
		public Difficulty Difficulty;
		public byte MaxPlayers;
		public LevelType Level;
		public bool ReducedDebug;

		public JoinGamePacket(int entityId, Gamemode gamemode, Dimension dimension, Difficulty difficulty, byte maxPlayers, LevelType level, bool reducedDebug = false)
		{
			EntityId = entityId;
			Gamemode = gamemode;
			Dimension = dimension;
			Difficulty = difficulty;
			MaxPlayers = maxPlayers;
			Level = level;
			ReducedDebug = reducedDebug;
		}
	}
}