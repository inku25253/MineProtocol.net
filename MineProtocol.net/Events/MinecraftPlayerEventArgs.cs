namespace MineProtocol.net.Events
{
	public class MinecraftPlayerEventArgs :MinecraftEventArgs
	{
		public MinecraftClient Client { get; private set; }

		public MinecraftPlayerEventArgs(MinecraftClient client)
		{
			Client = client;
		}
	}
}
