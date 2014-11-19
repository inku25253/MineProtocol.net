using MineProtocol.net.Protocols.Status.Client;
using MineProtocol.net.Protocols.Status.Server;

namespace MineProtocol.net.Events.Status
{
	public class StatusRequestEventArgs :MinecraftPacketEventArgs<StatusRequestPacket>
	{

		public StatusResponsePacket.ResponseData Response;

		public StatusRequestEventArgs(MinecraftClient client, StatusRequestPacket packet, StatusResponsePacket.ResponseData response)
			: base(client, packet)
		{
			Response = response;
		}
	}
}
