using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets.Plus;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net
{
	public class MinecraftServer
	{
		SocketServer<MinecraftClient, IPacketData, IPacketData> socket = new SocketServer<MinecraftClient, IPacketData, IPacketData>();


		public MinecraftServer()
		{
			MC18ProtocolTemplate protocolTemplate = new MC18ProtocolTemplate();
			socket.DefaultDecoder = protocolTemplate;
			socket.DefaultEncoder = protocolTemplate;

			socket.Activator = new SimpleActivator<MinecraftClient, IPacketData, IPacketData>(ProtocolVersion.MC1_8, Side.Server);


			socket.OnConnectRequest +=socket_OnConnectRequest;
			socket.OnDataReceived +=socket_OnDataReceived;
			socket.OnDisconnect +=socket_OnDisconnect;
			socket.OnSocketException += socket_OnSocketException;
		}

		void socket_OnConnectRequest(object sender, SocketConnectEventArgs<MinecraftClient, IPacketData, IPacketData> args)
		{

		}

		void socket_OnDataReceived(object sender, SocketReceiveEventArgs<MinecraftClient, IPacketData, IPacketData> args)
		{

		}

		void socket_OnDisconnect(object sender, SocketDisconnectEventArgs<MinecraftClient, IPacketData, IPacketData> args)
		{

		}
		void socket_OnSocketException(object sender, SocketErrorEventArgs<MinecraftClient, IPacketData, IPacketData> args)
		{

		}




		public bool Setup(EndPoint endp)
		{
			return socket.Setup(endp);
		}
		public void Start()
		{
			socket.Start();
		}
		public void Stop()
		{
			socket.Stop();
		}




	}
}
