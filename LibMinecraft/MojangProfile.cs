using System.Net.Configuration;
using System.Security.Policy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibMinecraft
{
	public class MojangProfile
	{

		public static readonly MojangProfile Minecraft = new MojangProfile("Minecraft");



		public string Agent { get; private set; }
		private string ApiUrl;
		private Encoding encode;
		public MojangProfile(string agent)
		{
			this.Agent = agent;
			ApiUrl = string.Format(MojangApiUrls.PlayerNameToUUID, Agent);
			encode = new UTF8Encoding();
		}

		public Profile[] GetProfiles(params string[] targetName)
		{
			string jsonArray = JsonConvert.SerializeObject(targetName);



			var webRequest = WebRequest.CreateHttp(ApiUrl);

			webRequest.ContentType = "application/json";
			webRequest.Method = "POST";


			using(var requestStr = webRequest.GetRequestStream())
			{
				byte[] bjson = encode.GetBytes(jsonArray);
				requestStr.Write(bjson, 0, bjson.Length);
				requestStr.Flush();
			}

			var wResponse = webRequest.GetResponse();
			string response;
			using(var reader = new StreamReader(wResponse.GetResponseStream()))
			{
				response = reader.ReadToEnd();
			}


			return JsonConvert.DeserializeObject<Profile[]>(response);
		}
		public Profile GetProfile(string targetName)
		{
			var profiles = GetProfiles(targetName);
			if(profiles.Length < 1)
			{
				throw new Exception();
			}


			return profiles[0];

		}

		public SkinCape DownloadSkinWithUuid(string uuid)
		{
			string url = string.Format(MojangApiUrls.UUIDToProfileAndSkin, Agent, uuid);
			WebClient webClient = new WebClient();
			string rawJson = webClient.DownloadString(url);
			SkinCape cape = JsonConvert.DeserializeObject<SkinCape>(rawJson);

			foreach(SkinProperties property in cape.Properties)
			{
				byte[] value = Convert.FromBase64String(property.Value);
				rawJson = encode.GetString(value);
				property.SetSkinData(JsonConvert.DeserializeObject<SkinData>(rawJson));
			}
			return cape;
		}

		public SkinCape DownloadSkinWithName(string name)
		{
			var profile = GetProfile(name);
			string uuid = profile.UUID;
			return DownloadSkinWithUuid(uuid);
		}

	}

	public struct SkinCape
	{
		[JsonProperty("id")]
		public string Id;
		[JsonProperty("name")]
		public string Name;

		[JsonProperty("properties")]
		public SkinProperties[] Properties;
	}

	public struct SkinProperties
	{
		[JsonProperty("name")]
		public string Name;
		[JsonProperty("value")]
		public string Value;
		[JsonProperty("sigunature")]
		public string Signature;

		[NonSerialized]
		public SkinData SkinData;

		internal void SetSkinData(SkinData data)
		{
			SkinData = data;
		}
	}

	public struct SkinData
	{
		[JsonProperty("timestamp")]
		public string Timestamp;
		[JsonProperty("profileId")]
		public string ProfileId;
		[JsonProperty("profileName")]
		public string ProfileName;
		[JsonProperty("isPublic")]
		public bool IsPublic;
		[JsonProperty("textures")]
		public SkinUrl Textures;
	}

	public struct SkinUrl
	{
		[JsonProperty("SKIN")]
		public MojangUrls Skin;
		[JsonProperty("CAPE")]
		public MojangUrls Cape;
	}

	public struct MojangUrls
	{
		[JsonProperty("url")]
		public string Url;
	}

	public struct Profile
	{
		[JsonProperty("id")]
		public string UUID;

		[JsonProperty("name")]
		public string Name;
	}
}
