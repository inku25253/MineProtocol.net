using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LibMinecraft
{
	public struct ChatColor
	{
		public static readonly ChatColor Black			= new ChatColor("Black", "§0", Color.FromArgb(0, 0, 0));
		public static readonly ChatColor DarkBlue		= new ChatColor("Dark_blue", "§1", Color.FromArgb(0, 0, 170));
		public static readonly ChatColor DarkGreen		= new ChatColor("Dark_green", "§2", Color.FromArgb(0, 170, 0));
		public static readonly ChatColor DarkAqua		= new ChatColor("Dark_aqua", "§3", Color.FromArgb(0, 170, 170));
		public static readonly ChatColor DarkRed		= new ChatColor("Dark_red", "§4", Color.FromArgb(170, 0, 0));
		public static readonly ChatColor DarkPurple		= new ChatColor("Dark_purple", "§5", Color.FromArgb(170, 0, 170));
		public static readonly ChatColor Gold			= new ChatColor("Gold", "§6", Color.FromArgb(255, 170, 0));
		public static readonly ChatColor Gray			= new ChatColor("Gray", "§7", Color.FromArgb(170, 170, 170));
		public static readonly ChatColor DarkGray		= new ChatColor("Dark_gray", "§8", Color.FromArgb(85, 85, 85));
		public static readonly ChatColor Blue			= new ChatColor("Blue", "§9", Color.FromArgb(85, 85, 255));
		public static readonly ChatColor Green			= new ChatColor("Green", "§A", Color.FromArgb(85, 255, 85));
		public static readonly ChatColor Aqua			= new ChatColor("Aqua", "§B", Color.FromArgb(85, 255, 255));
		public static readonly ChatColor Red			= new ChatColor("Red", "§C", Color.FromArgb(255, 85, 85));
		public static readonly ChatColor LightPurple	= new ChatColor("Light_purple", "§D", Color.FromArgb(255, 85, 255));
		public static readonly ChatColor Yellow			= new ChatColor("Yellow", "§E", Color.FromArgb(255, 255, 85));
		public static readonly ChatColor White			= new ChatColor("White", "§F", Color.FromArgb(255, 255, 255));
		public static readonly ChatColor Obfuscated		= new ChatColor("", "§K", Color.White);
		public static readonly ChatColor Bold			= new ChatColor("", "§L", Color.White);
		public static readonly ChatColor Strikethrough	= new ChatColor("", "§M", Color.White);
		public static readonly ChatColor Underline		= new ChatColor("", "§N", Color.White);
		public static readonly ChatColor Italic			= new ChatColor("", "§0", Color.White);
		public static readonly ChatColor Reset			= new ChatColor("", "§R", Color.White);



		public readonly Color Color;
		public readonly string ColorCode;
		public readonly string ColorName;

		private ChatColor(string officialName, string code, Color systemColor)
		{
			this.ColorName = officialName;
			this.ColorCode = code;
			this.Color = systemColor;
		}


		public static string operator +(string a, ChatColor b)
		{
			return a + b.ColorCode;
		}





	}


	public enum ChatButtonAction
	{
		// ReSharper disable InconsistentNaming

		[JsonProperty("open_url")]
		OpenUrl,
		[JsonProperty("change_page")]
		ChangePage,
		[JsonProperty("run_command")]
		RunCommand,
		[JsonProperty("suggest_command")]
		SuggestCommand,
		// ReSharper restore InconsistentNaming

	}

	public enum ChatHoverAction
	{
		[JsonProperty("show_text")]
		ShowText,
		[JsonProperty("show_text")]
		ShowItem,
		[JsonProperty("show_text")]
		ShowAchievement,
		[JsonProperty("show_text")]
		ShowEntity
	}

	public enum Gamemode
	{
		Survival,
		Creative,
		Adventure,

	}

	public enum Dimension :sbyte
	{
		Nether = -1,
		Overworld = 0x00,
		End = 0x01
	}

	public enum Difficulty
	{
		Peaceful,
		Easy,
		Normal,
		Hard
	}

	public enum LevelType
	{
		Default,
		Flat,
		LargeBiomes,
		Amplified,
		Default_1_1
	}

	public enum ChatPosition
	{
		ChatBox,
		SystemMessage,
		AboveActionBar
	}

	public enum SoundEffect
	{
	}

}
