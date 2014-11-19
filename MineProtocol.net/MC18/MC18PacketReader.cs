using System;
using LibMinecraft;
using MineProtocol.net.Protocols.Handshake.Client;
using MineProtocol.net.Protocols.Login.Client;
using MineProtocol.net.Protocols.Login.Server;
using MineProtocol.net.Protocols.Play.Server;
using MineProtocol.net.Protocols.Status;
using MineProtocol.net.Protocols.Status.Client;
using MineProtocol.net.Protocols.Status.Server;
using Newtonsoft.Json;

namespace MineProtocol.net.MC18
{
	internal static class MC18PacketReader
	{

		public static void RegistReaders(ProtocolEngine engine)
		{
			// ReSharper disable RedundantTypeArgumentsOfMethod

			/***
			  Handshake
			****************************************************/
			{
				engine.RegistReader<HandshakePacket>(HandshakeReader);
			}

			/***
			  Status
			****************************************************/
			{
				engine.RegistReader<StatusRequestPacket>(StatusRequestReader);
				engine.RegistReader<StatusResponsePacket>(StatusResponseReader);
				engine.RegistReader<StatusPingPacket>(StatusPingReader);
			}

			/***
			  Login
			****************************************************/
			{
				engine.RegistReader<LoginStartPacket>(LoginStartReader);
				engine.RegistReader<EncryptRequestPacket>(EncryptRequestReader);

				engine.RegistReader<EncryptResponsePacket>(EncryptResponseReader);

				engine.RegistReader<LoginSuccessPacket>(LoginSuccessReader);
				engine.RegistReader<LoginKickPacket>(LoginKickReader);
				engine.RegistReader<SetCompressionPacket>(LoginSetCompressionReader);
			}

			/***
			  Play
			****************************************************/
			{
				engine.RegistReader<KickPacket>(PlayKickReader);
			}

			// ReSharper restore RedundantTypeArgumentsOfMethod
		}







		#region Handshake
		private static HandshakePacket HandshakeReader(MinecraftStream ms)
		{
			try
			{
				return new HandshakePacket()
				{
					Version = ProtocolVersion.ProtocolVersionList[ms.ReadVarint()][0],
					ServerAddress = ms.ReadString(),
					ServerPort = ms.ReadUInt16(),
					NextState = (ProtocolState)ms.ReadVarint()
				};
			}
			catch { throw new InvalidOperationException(); }
		}
		#endregion

		#region Status
		private static StatusRequestPacket StatusRequestReader(MinecraftStream ms)
		{
			return new StatusRequestPacket();
		}

		private static StatusResponsePacket StatusResponseReader(MinecraftStream ms)
		{
			string rawJson = ms.ReadString();
			var response= JsonConvert.DeserializeObject<StatusResponsePacket.ResponseData>(rawJson);
			return new StatusResponsePacket() { Response = response };
		}

		private static StatusPingPacket StatusPingReader(MinecraftStream ms)
		{
			return new StatusPingPacket() { Time = ms.ReadInt64() };
		}
		#endregion

		#region Login

		private static LoginStartPacket LoginStartReader(MinecraftStream ms)
		{
			return new LoginStartPacket() { Name = ms.ReadString() };
		}



		private static EncryptRequestPacket EncryptRequestReader(MinecraftStream ms)
		{
			EncryptRequestPacket result = new EncryptRequestPacket();
			result.ServerID = ms.ReadString();
			int length = ms.ReadVarint();
			result.PublicKey = new byte[length];
			ms.Read(result.PublicKey);
			length = ms.ReadVarint();
			result.VerifyToken = new byte[length];
			ms.Read(result.VerifyToken);
			return result;
		}
		private static EncryptResponsePacket EncryptResponseReader(MinecraftStream ms)
		{
			EncryptResponsePacket result = new EncryptResponsePacket();

			int length = ms.ReadVarint();
			result.SharedSecret = new byte[length];
			ms.Read(result.SharedSecret);
			length = ms.ReadVarint();
			result.VerifyToken = new byte[length];
			ms.Read(result.VerifyToken);

			return result;
		}


		private static LoginSuccessPacket LoginSuccessReader(MinecraftStream ms)
		{
			return new LoginSuccessPacket() { Uuid = ms.ReadString(), UserName = ms.ReadString() };
		}

		private static LoginKickPacket LoginKickReader(MinecraftStream ms)
		{
			return new LoginKickPacket() { Result = ms.ReadString() };
		}

		private static SetCompressionPacket LoginSetCompressionReader(MinecraftStream ms)
		{
			return new SetCompressionPacket() { Threshold = ms.ReadVarint() };
		}

		#endregion

		#region Play

		private static KickPacket PlayKickReader(MinecraftStream ms)
		{
			return new KickPacket(ms.ReadString());
		}

		#endregion
	}
}
