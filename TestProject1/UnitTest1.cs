using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace TestProject1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
		}

		public static void Main()
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(@"d:\prog\VS2013\Projects\MineProtocol.net\MineProtocol.net\Versions.xml");
			XmlNodeList nodeList = doc.SelectNodes("versions/old/version");

			foreach (XmlNode old in nodeList)
			{
				string protocolID = old.Attributes["protocolId"].InnerText;
				string versionName = old.InnerText;


				Console.WriteLine("{0} : {1}", protocolID, versionName);
			}
		}
	}
}
