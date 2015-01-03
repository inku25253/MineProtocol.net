using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LibMinecraft
{
	public class ChatMessage
	{
		[JsonProperty("extra")]
		public readonly List<ChatMessage> ExtraList = new List<ChatMessage>();

		public ChatColor Color;

		[JsonProperty("bold")]
		public bool Bold = false;

		[JsonProperty("underline")]
		public bool Underline = false;
		[JsonProperty("italic")]
		public bool Italic = false;
		[JsonProperty("strikethrough")]
		public bool Strikethrough = false;
		[JsonProperty("obfuscated")]
		public bool Obfuscated = false;
		[JsonProperty("text")]
		public string Text = "";


		public ChatMessage(string text)
		{
			this.Text = text;
		}

		public ChatMessage(string text, ChatColor color)
			: this(text)
		{
			this.Color = color;
		}

		public ChatMessage(params object[] args)
		{
			Text = "";
			ChatColor cColor = ChatColor.White;
			for(int i = 0; i < args.Length; ++i)
			{
				object mData = args[i];

				if(mData is string)
				{
					Add(new ChatMessage(mData as string, cColor));
				}
				else if(mData is ChatColor)
				{
					cColor = (ChatColor)mData;
				}
			}
		}

		public void Add(ChatMessage message)
		{
			ExtraList.Add(message);
		}

		public string ToJson()
		{
			dynamic jObj = new JObject();

			if(ExtraList.Count > 0)
			{
				jObj.extra = ExtraList.ToArray();
			}
			if(Color.ColorName != null)
			{
				jObj.color = Color.ColorName;
			}
			if(Bold)
			{
				jObj.bold = true;
			}
			if(Underline)
			{
				jObj.underlined = true;
			}
			if(Strikethrough)
			{
				jObj.strikethrough = true;
			}
			if(Obfuscated)
			{
				jObj.obfuscated = true;
			}
			jObj.text = Text;

			return jObj.ToString();

		}

	}

	public class ChatButton :ChatMessage
	{

		public ChatButtonAction Action;
		public ChatButton(ChatButtonAction action, string text)
			: base(text)
		{
			this.Action = action;
		}
	}

	public class ChatHoverItem :ChatMessage
	{
		public ChatHoverAction Action;
		public ChatHoverItem(ChatHoverAction action, string text)
			: base(text)
		{
			this.Action = action;
		}
	}
}
