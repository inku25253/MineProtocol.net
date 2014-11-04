using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MineProtocol.net
{
	public class MineProtocol
	{
		public MineProtocol()
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(File.ReadAllText(@"d:\prog\VS2013\Projects\MineProtocol.net\MineProtocol.net\Versions.xml"));
			XmlNodeList nodeList = doc.SelectNodes("versions/old/");

			foreach (XmlNode old in nodeList)
			{
				string protocolID = old.Attributes["protocolId"].InnerText;
				string versionName = old.InnerText;


				//#><#= protocolID #><#= versionName #><#
			}


		}
	}
}
