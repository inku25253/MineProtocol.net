using LibMinecraft;

namespace MineProtocol.net.Protocols.Play.Server
{
	public struct SoundEffectPacket :IPacketData
	{
		#region IPacketData メンバー

		public int ProtocolId
		{
			get { return 0x29; }
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

		public SoundEffect Effect;
		public Vector3 Position;
		public float Volume;
		public byte Pitch;

		public SoundEffectPacket(SoundEffect effect, Vector3 position, float volume, byte pitch)
		{
			Effect = effect;
			Position = position;
			Volume = volume;
			Pitch = pitch;
		}
	}
}