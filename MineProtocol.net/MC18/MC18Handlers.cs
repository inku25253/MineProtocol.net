using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineProtocol.net.Events.Handshake;
using MineProtocol.net.Events.Status;
using MineProtocol.net.Protocols.Handshake.Client;
using MineProtocol.net.Protocols.Status;
using MineProtocol.net.Protocols.Status.Client;
using MineProtocol.net.Protocols.Status.Server;

namespace MineProtocol.net.MC18
{
	// ReSharper disable InconsistentNaming
	public class MC18HandshakeHandlers :IHandshakeHandler
	// ReSharper restore InconsistentNaming
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

	// ReSharper disable InconsistentNaming
	public class MC18LoginHandlers :ILoginHandler
	// ReSharper restore InconsistentNaming
	{

		#region IPacketHandler メンバー

		public override void Handle(MinecraftClient client, IPacketData data)
		{

		}

		#endregion
	}
	// ReSharper disable InconsistentNaming
	public class MC18StatusHandlers :IStateHandler
	// ReSharper restore InconsistentNaming
	{
		#region IPacketHandler メンバー

		public override void Handle(MinecraftClient client, IPacketData data)
		{
			if(data is StatusRequestPacket)
			{
				StatusRequestEventArgs args = new StatusRequestEventArgs(client, (StatusRequestPacket)data, new StatusResponsePacket.ResponseData(ProtocolVersion.MC1_8, new StatusResponsePacket.PlayerListData(300, 0, new StatusResponsePacket.PlayerData[0]), "TEST!"));
				this.OnStatusRequestEvent(args);
				client.Send(new StatusResponsePacket(args.Response));
			}
			else if(data is StatusPingPacket)
			{
				StatusPingEventArgs args = new StatusPingEventArgs(client, (StatusPingPacket)data);
				this.OnStatusPingEvent(args);
				client.Send(new StatusPingPacket(args.Time));
			}
		}

		#endregion
	}

	// ReSharper disable InconsistentNaming
	public class MC18PlayHandlers :IPlayHandler
	// ReSharper restore InconsistentNaming
	{

		#region IPacketHandler メンバー

		public override void Handle(MinecraftClient client, IPacketData data)
		{
		}

		#endregion
	}
}
