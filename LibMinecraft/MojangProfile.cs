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


			using (var requestStr = webRequest.GetRequestStream())
			{
				byte[] bjson = encode.GetBytes(jsonArray);
				requestStr.Write(bjson, 0, bjson.Length);
				requestStr.Flush();
			}

			var wResponse = webRequest.GetResponse();
			string response;
			using (var reader = new StreamReader(wResponse.GetResponseStream()))
			{
				response = reader.ReadToEnd();
			}


			return JsonConvert.DeserializeObject<Profile[]>(response);
		}
		public Profile GetProfile(string targetName)
		{
			var profiles = GetProfiles(targetName);
			if (profiles.Length  < 1)
			{
				throw new Exception();
			}


			return profiles[0];

		}

	}
	public struct Profile
	{
		[JsonProperty("id")]
		public string UUID;

		[JsonProperty("name")]
		public string Name;
	}
}
