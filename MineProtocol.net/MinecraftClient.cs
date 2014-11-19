using System.Net.Sockets.Plus;
using MineProtocol.net.MC18;
using MineProtocol.net.Protocols.Login.Server;
using MineProtocol.net.Protocols.Play.Server;

namespace MineProtocol.net
{
	public class MinecraftClient
	{
		private readonly SocketClient<MinecraftClient, IPacketData, IPacketData> _socket;

		public ProtocolEngine ProtocolEngine { get; internal set; }

		public ProtocolState CurrentProtocolState
		{
			get
			{
				return ProtocolEngine.State;
			}
			set
			{
				ProtocolEngine.State = value;
				ProtocolEngine.Flush();
			}
		}

		public ProtocolVersion Version
		{
			get
			{
				return ProtocolEngine.Version;
			}
			set
			{
				ProtocolEngine.Version = value;
				ProtocolEngine.Flush();
			}
		}

		public Side Side
		{
			get
			{
				return ProtocolEngine.Side;
			}
			set
			{
				ProtocolEngine.Side = value;
				ProtocolEngine.Flush();
			}
		}
		public MinecraftClient(SocketClient<MinecraftClient, IPacketData, IPacketData> socket, ProtocolVersion version,
			Side side)
		{
			_socket = socket;
			ProtocolEngine = new ProtocolEngine(version, side);
			MC18PacketWriter.RegistWriters(ProtocolEngine);
			MC18PacketReader.RegistReaders(ProtocolEngine);
			ProtocolEngine.Flush();
		}

		public void Send(IPacketData data)
		{
			_socket.Send(data);
		}


		public void Kick(string reason)
		{
			switch(CurrentProtocolState)
			{
				case ProtocolState.Play:
					this.Send(new KickPacket(reason));
					break;
				default:
					this.Send(new LoginKickPacket(reason));

					break;
			}
		}
	}
}