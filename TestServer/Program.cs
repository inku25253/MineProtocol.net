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
using System.Net.Sockets.Plus;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestServer
{
	class Program
	{
		public static void Main()
		{

			//SocketServer<SocketMinecraftPlayer, IPacketData, IPacketData> socket = new SocketServer<SocketMinecraftPlayer, IPacketData, IPacketData>();
			while (true)
			{
				Console.Clear();
				SocketClient<MinecraftClient, IPacketData, IPacketData> socket = new SocketClient<MinecraftClient, IPacketData, IPacketData>();
				MC18ProtocolTemplate template = new MC18ProtocolTemplate();

				socket.Decoder = template;
				socket.Encoder = template;
				socket.OnConnected+=socket_OnConnected;
				socket.OnDataReceived +=Client_OnDataReceived;
				socket.OnDisconnect +=socket_OnDisconnect;
				socket.Connect("192.168.0.2", 27092);
				Thread.Sleep(5000);
			}
			/*socket.DefaultDecoder = template;
			socket.DefaultEncoder = template;


			socket.Setup(5050);
			socket.OnDataReceived +=socket_OnDataReceived;
			socket.Start();*/

		}

		static void socket_OnDisconnect(object sender, SocketDisconnectEventArgs<MinecraftClient, IPacketData, IPacketData> args)
		{
			Console.WriteLine("切断");
		}

		static void socket_OnConnected(object sender, SocketConnectEventArgs<MinecraftClient, IPacketData, IPacketData> args)
		{
			args.Client.Send(new HandshakePacket() { Version = ProtocolVersion.MC1_7_2, ServerAddress = "potechi.org", ServerPort= 27092, NextState = ProtocolState.STATUS });
			args.State.ProtocolEngine.State = ProtocolState.STATUS;
			args.State.ProtocolEngine.Flush();
			args.Client.Send(new StatusRequestPacket());
			args.Client.Send(new StatusPingPacket() { Time = Environment.TickCount });
		}

		private static void Client_OnDataReceived(object sender, SocketReceiveEventArgs<MinecraftClient, IPacketData, IPacketData> args)
		{
			if (args.Packet == null)
				return;
			if (args.Packet is StatusPingPacket)
			{
				StatusPingPacket ping = args.Packet as StatusPingPacket;
				Console.WriteLine("Ping: {0}", Environment.TickCount - ping.Time);
			}
			else if (args.Packet is StatusResponsePacket)
			{
				StatusResponsePacket responsePacket = (StatusResponsePacket)args.Packet;
				var resp = responsePacket.Response;
				int i= 0;

				Console.WriteLine("Version:	{0}", resp.Version.VersionName);
				Console.WriteLine("Description:	{0}", resp.Description);
				Console.WriteLine("==============Players({0}/{1})==============", resp.Playerlist.OnlinePlayerCount, resp.Playerlist.Max);
				if (resp.Playerlist.Players != null)
					foreach (var player in resp.Playerlist.Players)
					{
						Console.WriteLine("{0:00},{1}	{2}", ++i, player.Name, player.UUID);
					}
			}
		}


		static void socket_OnDataReceived(object sender, SocketReceiveEventArgs<MinecraftClient, IPacketData, IPacketData> args)
		{

			IPacketData packet = args.Packet;
			if (packet == null)
				return;
			if (packet is HandshakePacket)
			{
				args.State.ProtocolEngine.State = (packet as HandshakePacket).NextState;
				args.State.ProtocolEngine.Flush();
			}
			else if (packet is StatusRequestPacket)
			{
				StatusResponsePacket response = new StatusResponsePacket();
				response.Response = new StatusResponsePacket.ResponseData()
				{
					Description = "TEST",
					Version = ProtocolVersion.MC1_8,
					Playerlist = new StatusResponsePacket.PlayerListData()
					{
						Max = 32767,
						OnlinePlayerCount = 32767,
						Players = new StatusResponsePacket.PlayerData[]{
							new StatusResponsePacket.PlayerData(){ Name= "mine", UUID="" },
							new StatusResponsePacket.PlayerData(){ Name="Craft", UUID = "" }
						}
					}
				};

				args.Send(response);
			}
			else if (packet is StatusPingPacket)
			{

				StatusPingPacket response = packet as StatusPingPacket;

				Console.WriteLine(response.Time);

				args.Send(response);
			}
			else if (packet is LoginStartPacket)
			{
				Profile prof = MojangProfile.Minecraft.GetProfile((packet as LoginStartPacket).Name);
				string fUuid = Guid.ParseExact(prof.UUID, "N").ToString("D");
				LoginSuccessPacket result = new LoginSuccessPacket() { UUID = fUuid, UserName = prof.Name };
				args.Send(result);
				args.State.ProtocolEngine.State = ProtocolState.PLAY;
				args.State.ProtocolEngine.Flush();


			}


		}


	}
}
