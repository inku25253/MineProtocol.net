using MineProtocol.net.Events.Handshake;
using MineProtocol.net.Events.Status;
using MineProtocol.net.Protocols.Status.Server;

namespace MineProtocol.net
{
	public abstract class IPacketHandler
	{
		public abstract ProtocolState State { get; }
		public abstract void Handle(MinecraftClient client, IPacketData data);
	}

	public abstract class IHandshakeHandler :IPacketHandler
	{
		public override ProtocolState State
		{
			get { return ProtocolState.Handshake; }
		}

		public event MinecraftEvent<HandshakeEventArgs> HandshakeEvent;

		protected virtual void OnHandshakeEvent(HandshakeEventArgs args)
		{
			MinecraftEvent<HandshakeEventArgs> handler = HandshakeEvent;
			if(handler != null)
				handler(this, args);
		}


	}
	public abstract class ILoginHandler :IPacketHandler
	{
		public override ProtocolState State
		{
			get { return ProtocolState.Login; }
		}

		public bool OnlineMode;
	}

	public abstract class IStateHandler :IPacketHandler
	{
		public override ProtocolState State
		{
			get { return ProtocolState.Status; }
		}

		public event MinecraftEvent<StatusRequestEventArgs> StatusRequestEvent;
		public event MinecraftEvent<StatusPingEventArgs> StatusPingEvent;

		protected virtual void OnStatusPingEvent(StatusPingEventArgs args)
		{
			MinecraftEvent<StatusPingEventArgs> handler = StatusPingEvent;
			if(handler != null)
				handler(this, args);
		}

		protected virtual void OnStatusRequestEvent(StatusRequestEventArgs args)
		{
			MinecraftEvent<StatusRequestEventArgs> handler = StatusRequestEvent;
			if(handler != null)
				handler(this, args);

		}
	}
	public abstract class IPlayHandler :IPacketHandler
	{
		public override ProtocolState State
		{
			get { return ProtocolState.Play; }
		}
	}
}
