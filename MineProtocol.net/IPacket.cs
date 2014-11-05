using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net
{
	public interface IPacketData
	{
		VersionInfo Version { get; }



		void Write();
		void Read();
	}
}
