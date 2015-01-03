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

				/** 0x00 **/ { engine.RegistWriter<KeepALivePacket>(KeepALiveWriter); }
				/** 0x01 **/ { engine.RegistWriter<JoinGamePacket>(JoinGameWriter); }
				/** 0x02 **/ { engine.RegistWriter<ChatMessagePacket>(ChatMessageWriter); }
				/** 0x03 **/ { engine.RegistWriter<TimeUpdatePacket>(TimeUpdateWriter); }
				/** 0x04 **/ { engine.RegistWriter<EntityEquipmentPacket>(EntityEquipmentWriter); }
				/** 0x05 **/ { engine.RegistWriter<SpawnPositionPacket>(SpawnPositionWriter); }
				/** 0x06 **/ { }

			}
		}







		#region Handshake
		private static void HandshakeWriter(HandshakePacket data, MinecraftStream ms)
		{
			ms.WriteVarint(data.Version.ProtocolID);
			ms.Write(data.ServerAddress);
			ms.Write(data.ServerPort);
			ms.WriteVarint((int)data.NextState);
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
			ms.WriteVarint(data.PublicKey.Length);
			ms.Write(data.PublicKey);
			ms.WriteVarint(data.VerifyToken.Length);
			ms.Write(data.VerifyToken);
		}
		private static void EncryptResponseWriter(EncryptResponsePacket data, MinecraftStream ms)
		{
			ms.WriteVarint(data.SharedSecret.Length);
			ms.Write(data.SharedSecret);
			ms.WriteVarint(data.VerifyToken.Length);
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
			ms.WriteVarint(data.Threshold);
		}

		#endregion

		#region Play

		/// <summary>
		/// 0x00
		/// </summary>
		/// <param name="data"></param>
		/// <param name="ms"></param>
		private static void KeepALiveWriter(KeepALivePacket data, MinecraftStream ms)
		{
			ms.WriteVarint(data.LiveId);
		}

		/// <summary>
		/// 0x01
		/// </summary>
		/// <param name="data"></param>
		/// <param name="ms"></param>
		private static void JoinGameWriter(JoinGamePacket data, MinecraftStream ms)
		{
			ms.WriteInt32(data.EntityId);
			ms.WriteByte((byte)data.Gamemode);
			ms.Write((byte)data.Dimension);
			ms.Write((byte)data.Difficulty);
			ms.Write(data.MaxPlayers);
			ms.Write(data.Level.ToString());
			ms.Write(data.ReducedDebug);
		}

		/// <summary>
		/// 0x02
		/// </summary>
		/// <param name="data"></param>
		/// <param name="ms"></param>
		private static void ChatMessageWriter(ChatMessagePacket data, MinecraftStream ms)
		{
			string jsonMessage = data.Message.ToJson();//JsonConvert.SerializeObject(data.Message);
			ms.Write(jsonMessage);
			ms.Write((byte)data.Position);
		}

		/// <summary>
		/// 0x03
		/// </summary>
		/// <param name="data"></param>
		/// <param name="ms"></param>
		private static void TimeUpdateWriter(TimeUpdatePacket data, MinecraftStream ms)
		{
			ms.Write(data.WorldTime);
			ms.Write(data.DayTime);
		}

		/// <summary>
		/// 0x04
		/// </summary>
		/// <param name="data"></param>
		/// <param name="ms"></param>
		private static void EntityEquipmentWriter(EntityEquipmentPacket data, MinecraftStream ms)
		{
			ms.WriteVarint(data.EntityId);
			//TODO: Slot待ち
		}

		/// <summary>
		/// 0x05
		/// </summary>
		/// <param name="data"></param>
		/// <param name="ms"></param>
		private static void SpawnPositionWriter(SpawnPositionPacket data, MinecraftStream ms)
		{
			ms.Write(data.Position);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <param name="ms"></param>
		private static void PlayKickWriter(KickPacket data, MinecraftStream ms)
		{
			ms.Write(data.Reason);
		}



		#endregion


	}
}
