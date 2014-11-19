using MineProtocol.net.Events;

namespace MineProtocol.net
{


	public delegate void PacketServiceHandler(MinecraftClient client, IPacketData data);

	public delegate void MinecraftEvent<in T>(object sender, T args) where T :MinecraftEventArgs;

}
