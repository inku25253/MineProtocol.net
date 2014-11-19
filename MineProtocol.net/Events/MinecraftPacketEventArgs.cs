using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net.Events
{
	public class MinecraftPacketEventArgs<T> :MinecraftPlayerEventArgs where T :IPacketData
	{
		public T Packet;

		public MinecraftPacketEventArgs(MinecraftClient client, T packet)
			: base(client)
		{
			Packet = packet;
		}
	}
}
