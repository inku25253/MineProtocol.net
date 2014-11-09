using LibMinecraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net
{
	public interface IPacketData
	{
		int ProtocolId { get; }
		ProtocolState ProtocolStatus { get; }

		Side Sides { get; }


	}
}
