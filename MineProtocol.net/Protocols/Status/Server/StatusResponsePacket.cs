using Newtonsoft.Json;

namespace MineProtocol.net.Protocols.Status.Server
{
	public struct StatusResponsePacket :IPacketData
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
				return ProtocolState.Status;
			}
		}


		public Side Sides
		{
			get { return Side.Server; }
		}


		public StatusResponsePacket(ResponseData data)
		{
			this.Response = data;
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
			public string Favicon;

			public ResponseData(ProtocolVersion version, PlayerListData playerlist, string description, string favicon = "data:image/png;base64,")
			{
				this.Version = version;
				this.Playerlist = playerlist;
				this.Description = description;
				this.Favicon = favicon;
			}

			public ResponseData()
			{
				
			}
		}
		public class ForgeResponseData :ResponseData
		{
			[JsonProperty("modinfo")]
			public ModData ModData;

			public ForgeResponseData(ModData modData, ProtocolVersion version, PlayerListData playerList, string description, string favicon = "data:image/png;base64,")
				: base(version, playerList, description, favicon)
			{
				ModData = modData;
			}
		}
		public struct PlayerListData
		{
			[JsonProperty("max")]
			public int Max;
			[JsonProperty("online")]
			public int OnlinePlayerCount;

			[JsonProperty("sample")]
			public PlayerData[] Players;

			public PlayerListData(int max, int onlinePlayerCount, PlayerData[] players)
			{
				Max = max;
				OnlinePlayerCount = onlinePlayerCount;
				Players = players;
			}


		}
		public struct PlayerData
		{
			[JsonProperty("name")]
			public string Name;
			[JsonProperty("id")]
			public string Uuid;

			public PlayerData(string name, string uuid)
			{
				Name = name;
				Uuid = uuid;
			}
		}
		public struct DescriptionData
		{
			[JsonProperty("text")]
			public string Text;

			public DescriptionData(string text)
			{
				Text = text;
			}
		}
		public struct ModData
		{
			[JsonProperty("type")]
			public string Type;
			[JsonProperty("modList")]
			public ModListData[] ModList;

			public ModData(string type, ModListData[] modList)
			{
				Type = type;
				ModList = modList;
			}
		}
		public struct ModListData
		{
			[JsonProperty("modid")]
			public string ModId;
			[JsonProperty("version")]
			public string Version;

			public ModListData(string modId, string version)
			{
				ModId = modId;
				Version = version;
			}
		}

	}
}
