using LibMinecraft;
using MineProtocol.net;
using MineProtocol.net.Protocols.Handshake.Client;
using MineProtocol.net.Protocols.Login.Client;
using MineProtocol.net.Protocols.Login.Server;
using MineProtocol.net.Protocols.Status;
using MineProtocol.net.Protocols.Status.Client;
using MineProtocol.net.Protocols.Status.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets.Plus;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MineProtocol.net.Events.Handshake;

namespace TestServer
{
	class Program
	{
		public static void Main()
		{


			MinecraftServer server = new MinecraftServer();
			if(server.Setup(new IPEndPoint(IPAddress.Any, 5050)) == false)
			{

			}
			server.Start();

			server.PacketService.StateHandler.StatusRequestEvent += StateHandler_StatusRequestEvent;
			Console.ReadLine();

		}

		static void StateHandler_StatusRequestEvent(object sender, MineProtocol.net.Events.Status.StatusRequestEventArgs args)
		{
			args.Response.Version = ProtocolVersion.MC1_8_pre3;
		}


	}
}
