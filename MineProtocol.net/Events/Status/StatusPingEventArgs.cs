
using MineProtocol.net.Protocols.Status;

namespace MineProtocol.net.Events.Status
{
	public class StatusPingEventArgs :MinecraftPacketEventArgs<StatusPingPacket>
	{

		public long Time { get { return Packet.Time; } }

		public StatusPingEventArgs(MinecraftClient client, StatusPingPacket args)
			: base(client, args)
		{

		}
	}
}
