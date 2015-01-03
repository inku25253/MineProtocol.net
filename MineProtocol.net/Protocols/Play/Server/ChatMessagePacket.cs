using LibMinecraft;

namespace MineProtocol.net.Protocols.Play.Server
{
	public struct ChatMessagePacket :IPacketData
	{
		#region IPacketData メンバー

		public int ProtocolId
		{
			get { return 0x02; }
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

		public ChatMessage Message;
		public ChatPosition Position;

		public ChatMessagePacket(ChatMessage message, ChatPosition position)
		{
			Message = message;
			Position = position;
		}
	}
}