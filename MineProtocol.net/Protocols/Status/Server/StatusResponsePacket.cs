using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net.Protocols.Status.Server
{
	public struct StatusResponsePacket : IPacketData
	{
		public ResponseData Response;



		public int ProtocolId
		{
			get { return 0x00; }
		}
		public ProtocolState ProtocolStatus
		{
			get
			{
				return ProtocolState.STATUS;
			}
		}


		public Side Sides
		{
			get { return Side.ServerToClient; }
		}


		public class ResponseData
		{
			[JsonProperty("version")]
			public ProtocolVersion Version;
			[JsonProperty("players")]
			public PlayerListData Playerlist;
			[JsonProperty("description")]
			public string Description;
			[JsonProperty("favicon")]
			public string favicon = "data:image/png;base64,";
		}
		public class ForgeResponseData : ResponseData
		{
			[JsonProperty("modinfo")]
			public ModData ModData;
		}
		public struct PlayerListData
		{
			[JsonProperty("max")]
			public int Max;
			[JsonProperty("online")]
			public int OnlinePlayerCount;

			[JsonProperty("sample")]
			public PlayerData[] Players;


		}
		public struct PlayerData
		{
			[JsonProperty("name")]
			public string Name;
			[JsonProperty("id")]
			public string UUID;
		}
		public struct DescriptionData
		{
			[JsonProperty("text")]
			public string Text;
		}
		public struct ModData
		{
			[JsonProperty("type")]
			public string Type;
			[JsonProperty("modList")]
			public ModListData[] ModList;
		}
		public struct ModListData
		{
			[JsonProperty("modid")]
			public string ModId;
			[JsonProperty("version")]
			public string Version;
		}

	}
}
