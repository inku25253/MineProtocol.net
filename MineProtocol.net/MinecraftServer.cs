using System.Net;
using System.Net.Sockets.Plus;
using MineProtocol.net.MC18;

namespace MineProtocol.net
{
	public class MinecraftServer
	{
		private readonly SocketServer<MinecraftClient, IPacketData, IPacketData> _socket =
			new SocketServer<MinecraftClient, IPacketData, IPacketData>();

		public PacketService PacketService { get; private set; }


		public event SocketServer<MinecraftClient, IPacketData, IPacketData>.SocketConnectEvent OnConnect
		{
			add { _socket.OnConnectRequest += value; }
			remove { _socket.OnConnectRequest -= value; }
		}

		public event SocketServer<MinecraftClient, IPacketData, IPacketData>.SocketDisconnectEvent OnDisconnect
		{
			add { _socket.OnDisconnect += value; }
			remove { _socket.OnDisconnect -= value; }
		}


		public MinecraftServer()
		{
			var protocolTemplate = new MC18ProtocolTemplate();

			_socket.DefaultDecoder = protocolTemplate;
			_socket.DefaultEncoder = protocolTemplate;

			((SimpleActivator<MinecraftClient, IPacketData, IPacketData>)_socket.Activator)
				.SetArguments(typeof(SocketClientRequest), ProtocolVersion.MC1_8, Side.Server);


			_socket.OnConnectRequest += socket_OnConnectRequest;
			_socket.OnDataReceived += socket_OnDataReceived;
			_socket.OnDisconnect += socket_OnDisconnect;
			_socket.OnSocketException += socket_OnSocketException;

			PacketService = new PacketService(new MC18HandshakeHandlers(), new MC18LoginHandlers(), new MC18StatusHandlers(), new MC18PlayHandlers());
		}



		private void socket_OnConnectRequest(object sender,
			SocketConnectEventArgs<MinecraftClient, IPacketData, IPacketData> args)
		{
		}

		private void socket_OnDataReceived(object sender,
			SocketReceiveEventArgs<MinecraftClient, IPacketData, IPacketData> args)
		{
			PacketService.Handle(args.State, args.Packet);
		}

		private void socket_OnDisconnect(object sender,
			SocketDisconnectEventArgs<MinecraftClient, IPacketData, IPacketData> args)
		{

		}

		private void socket_OnSocketException(object sender,
			SocketErrorEventArgs<MinecraftClient, IPacketData, IPacketData> args)
		{
		}


		public bool Setup(EndPoint endp)
		{
			return _socket.Setup(endp);
		}

		public void Start()
		{
			_socket.Start();
		}

		public void Stop()
		{
			_socket.Stop();
		}
	}
}