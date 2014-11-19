using System;
using MineProtocol.net.Protocols.Handshake.Client;
using MineProtocol.net.Protocols.Login.Client;
using MineProtocol.net.Protocols.Login.Server;
using MineProtocol.net.Protocols.Status;
using MineProtocol.net.Protocols.Status.Client;
using MineProtocol.net.Protocols.Status.Server;

namespace MineProtocol.net
{
	public class PacketService
	{

		/// <summary>
		/// 
		/// めも　配列　ProtocolState
		/// </summary>
		public PacketServiceHandler[] Handlers = new PacketServiceHandler[4];



		public IHandshakeHandler HandshakeHandler;
		public ILoginHandler LoginHandler;
		public IStateHandler StateHandler;
		public IPlayHandler PlayHandler;


		public PacketService(IHandshakeHandler handshakeHandler, ILoginHandler loginHandler, IStateHandler stateHandler, IPlayHandler playHandler)
		{
			HandshakeHandler = handshakeHandler;
			LoginHandler = loginHandler;
			StateHandler = stateHandler;
			PlayHandler = playHandler;

			this.Regist(HandshakeHandler);
			this.Regist(LoginHandler);
			this.Regist(StateHandler);
			this.Regist(PlayHandler);
		}






		public void Regist(ProtocolState state, PacketServiceHandler target)
		{
			Handlers[(int)state] = target;
		}

		public void Regist(IPacketHandler handler)
		{
			this.Regist(handler.State, handler.Handle);
		}


		internal void Handle(MinecraftClient client, IPacketData data)
		{
			if(Handlers[(int)(client.CurrentProtocolState)] == null)
				throw new InvalidOperationException("現在のProtocolStateのイベントが登録されていません。");
			Handlers[(int)client.CurrentProtocolState](client, data);
		}

	}
}
