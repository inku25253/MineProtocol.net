using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineProtocol.net.Protocols.Login.Client;
using MineProtocol.net.Protocols.Status;

namespace MineProtocol.net.Events.Login
{
	public class LoginStartEventArgs :MinecraftPacketEventArgs<LoginStartPacket>
	{
		public string Name { get { return Packet.Name; } }

		public LoginStartEventArgs(MinecraftClient client, LoginStartPacket packet)
			: base(client, packet)
		{
		}
	}
}
