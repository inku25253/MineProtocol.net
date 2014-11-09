using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.IO;
using LibMinecraft;
using System.Collections.Generic;
using MineProtocol.net;
using MineProtocol.net.Protocols.Handshake.Client;

namespace TestProject1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void DictionaryTest()
		{
			Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, string>>>> dic = new Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, string>>>>();
			string one = "";
			string two = "";
			string tree = "";
			string four = "";
			for (int i = 0; i < 100; i++)
			{
				one = Path.GetRandomFileName();
				two = Path.GetRandomFileName();
				tree = Path.GetRandomFileName();
				four = Path.GetRandomFileName();
				if (dic.ContainsKey(one) == false)
				{

					dic[one] = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();


				}
				if (dic[one].ContainsKey(two) == false)
				{
					dic[one][two] = new Dictionary<string, Dictionary<string, string>>();

				}
				if (dic[one][two].ContainsKey(tree) == false)
				{
					dic[one][two][tree] = new Dictionary<string, string>();
				}
				dic[one][two][tree][four] =  "VALUE";
			}

			Assert.IsTrue(dic.ContainsKey(one) && dic[one].ContainsKey(two) && dic[one][two].ContainsKey(tree) && dic[one][two][tree].ContainsKey(four));

			string value = dic[one][two][tree][four];

		}
		static ProtocolEngine engine;
		[TestMethod]
		public void ProtocolEngineInitTest()
		{
			engine = new ProtocolEngine(ProtocolVersion.MC1_0_0, Side.Client);
			engine.RegistWriter<HandshakePacket>(test);
			engine.Flush();
		}

		[TestMethod]
		public void ProtocolEngineWriteTest()
		{

			engine.Write(new HandshakePacket(), new MinecraftStream());

		}
		private static void test(IPacketData data, MinecraftStream ms)
		{

		}

		public static void Main()
		{
			//ProtocolEngine engine = new ProtocolEngine();
			//engine.RegistWriter(ProtocolVersion.MC1_0_0, Side.ClientToServer, ProtocolState.HANDSHAKE, typeof(HandshakePacket), test);
			//engine.Write(ProtocolVersion.MC1_0_0, Side.ClientToServer, ProtocolState.HANDSHAKE, new HandshakePacket(), new MinecraftStream());
			//1 Type
			//2 Version
			//3 ProtocolState
			//4 Side
			Console.ReadLine();
		}


		public class testClass
		{
			public string key;
			public string sub;
			public string value;
		}
	}
}
