using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMinecraft;
using MineProtocol.net.Events.Handshake;
using MineProtocol.net.Events.Status;
using MineProtocol.net.Protocols.Handshake.Client;
using MineProtocol.net.Protocols.Login.Client;
using MineProtocol.net.Protocols.Login.Server;
using MineProtocol.net.Protocols.Play.Server;
using MineProtocol.net.Protocols.Status;
using MineProtocol.net.Protocols.Status.Client;
using MineProtocol.net.Protocols.Status.Server;

namespace MineProtocol.net.MC18
{
	public class MC18HandshakeHandlers :IHandshakeHandler
	{

		#region IPacketHandler メンバー

		public override void Handle(MinecraftClient client, IPacketData data)
		{
			if((data is HandshakePacket) == false)
			{
				client.Kick("Invalid Protocol.");
				return;
			}

			HandshakeEventArgs args = new HandshakeEventArgs(client, (HandshakePacket)data);
			this.OnHandshakeEvent(args);

			client.Version = args.Version;
			client.CurrentProtocolState = args.NextState;

		}

		#endregion
	}
	public class MC18LoginHandlers :ILoginHandler
	{

		#region IPacketHandler メンバー

		public override void Handle(MinecraftClient client, IPacketData data)
		{
			if(data is LoginStartPacket)
			{
				LoginStartPacket loginStart = (LoginStartPacket)data;
				Profile mProfile = MojangProfile.Minecraft.GetProfile(loginStart.Name);

				Guid guid = Guid.Parse(mProfile.UUID);
				string uuid = guid.ToString("D");
				LoginSuccessPacket successPacket = new LoginSuccessPacket(uuid, mProfile.Name);
				client.SendPacket(successPacket);

				client.CurrentProtocolState = ProtocolState.Play;

				JoinGamePacket joingamePacket = new JoinGamePacket(0, Gamemode.Creative, Dimension.Overworld, Difficulty.Peaceful, 0xFF, LevelType.Default, true);
				client.SendPacket(joingamePacket);
				client.Send(new ChatMessage("TEST"));

			}
		}

		#endregion
	}
	public class MC18StatusHandlers :IStateHandler
	{
		#region IPacketHandler メンバー

		public override void Handle(MinecraftClient client, IPacketData data)
		{
			if(data is StatusRequestPacket)
			{
				StatusRequestEventArgs args = new StatusRequestEventArgs(
					client,
					(StatusRequestPacket)data,
					new StatusResponsePacket.ResponseData(
						ProtocolVersion.MC1_8,
						new StatusResponsePacket.PlayerListData(
							300,
							0,
							new StatusResponsePacket.PlayerData[0]
						),
						 "TEST!"
					)
				);

				this.OnStatusRequestEvent(args);
				client.SendPacket(new StatusResponsePacket(args.Response));
			}
			else if(data is StatusPingPacket)
			{
				StatusPingEventArgs args = new StatusPingEventArgs(client, (StatusPingPacket)data);
				this.OnStatusPingEvent(args);
				client.SendPacket(new StatusPingPacket(args.Time));
			}
		}

		#endregion
	}

	public class MC18PlayHandlers :IPlayHandler
	{

		#region IPacketHandler メンバー

		public override void Handle(MinecraftClient client, IPacketData data)
		{



		}

		#endregion
	}
}
