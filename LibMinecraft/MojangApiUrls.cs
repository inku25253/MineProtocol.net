using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMinecraft
{
	public class MojangApiUrls
	{

		/// <summary>
		/// 
		/// 
		/// 0 => Agent
		/// 1 => Username
		/// 2 => Timestamp
		/// </summary>
		public const string ProfileAtTime="https://api.mojang.com/users/profiles/{0}/{1}?at={2}";
		
		/// <summary>
		/// 
		/// 
		/// {0} => UUID
		/// </summary>
		public const string NameHistory = "https://api.mojang.com/user/profiles/{0}/names";
		
		/// <summary>
		/// 
		/// 
		/// {0} => Agent
		/// </summary>
		public const string PlayerNameToUUID = "https://api.mojang.com/profiles/{0}";

		/// <summary>
		/// 
		/// 
		/// {0} => Agent
		/// {1} => UUID
		/// </summary>
		public const string UUIDToProfileAndSkin = "https://sessionserver.mojang.com/session/{0}/profile/{1}";
	}
}
