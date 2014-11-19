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
	internal static class MC18PacketWriter
	{

		public static void RegistWriters(ProtocolEngine engine)
		{
			/***
			  Handshake
			****************************************************/
			{
				engine.RegistWriter<HandshakePacket>(HandshakeWriter);
			}

			/***
			  Status
			****************************************************/
			{
				engine.RegistWriter<StatusRequestPacket>(StatusRequestWriter);
				engine.RegistWriter<StatusResponsePacket>(StatusResponseWriter);
				engine.RegistWriter<StatusPingPacket>(StatusPingWriter);
			}

			/***
			  Login
			****************************************************/
			{
				engine.RegistWriter<LoginStartPacket>(LoginStartWriter);
				engine.RegistWriter<EncryptRequestPacket>(EncryptRequestWriter);
				engine.RegistWriter<EncryptResponsePacket>(EncryptResponseWriter);
				engine.RegistWriter<LoginSuccessPacket>(LoginSuccessWriter);
				engine.RegistWriter<LoginKickPacket>(LoginKickWriter);
				engine.RegistWriter<SetCompressionPacket>(LoginSetCompressionWriter);
			}

			/***
			  Play
			****************************************************/
			{

				engine.RegistWriter<KickPacket>(PlayKickWriter);
			}
		}






		#region Handshake
		private static void HandshakeWriter(HandshakePacket data, MinecraftStream ms)
		{
			ms.Write(data.Version.ProtocolID);
			ms.Write(data.ServerAddress);
			ms.Write(data.ServerPort);
			ms.Write((int)data.NextState);
		}
		#endregion

		#region Status
		private static void StatusRequestWriter(StatusRequestPacket data, MinecraftStream ms) { }

		private static void StatusResponseWriter(StatusResponsePacket data, MinecraftStream ms)
		{
			string responseJson = JsonConvert.SerializeObject(data.Response);
			ms.Write(responseJson);
		}

		private static void StatusPingWriter(StatusPingPacket data, MinecraftStream ms)
		{
			ms.Write(data.Time);
		}
		#endregion

		#region Login

		private static void LoginStartWriter(LoginStartPacket data, MinecraftStream ms)
		{
			ms.Write(data.Name);
		}



		private static void EncryptRequestWriter(EncryptRequestPacket data, MinecraftStream ms)
		{
			ms.Write(data.ServerID);
			ms.Write(data.PublicKey.Length);
			ms.Write(data.PublicKey);
			ms.Write(data.VerifyToken.Length);
			ms.Write(data.VerifyToken);
		}
		private static void EncryptResponseWriter(EncryptResponsePacket data, MinecraftStream ms)
		{
			ms.Write(data.SharedSecret.Length);
			ms.Write(data.SharedSecret);
			ms.Write(data.VerifyToken.Length);
			ms.Write(data.VerifyToken);
		}


		private static void LoginSuccessWriter(LoginSuccessPacket data, MinecraftStream ms)
		{
			ms.Write(data.Uuid);
			ms.Write(data.UserName);
		}

		private static void LoginKickWriter(LoginKickPacket data, MinecraftStream ms)
		{
			ms.Write(data.Result);
		}

		private static void LoginSetCompressionWriter(SetCompressionPacket data, MinecraftStream ms)
		{
			ms.Write(data.Threshold);
		}

		#endregion

		#region Play


		private static void PlayKickWriter(KickPacket data, MinecraftStream ms)
		{
			ms.Write(data.Reason);
		}

		#endregion


	}
}
