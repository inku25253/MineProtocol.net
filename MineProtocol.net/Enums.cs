using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net
{
	public enum ProtocolState : int
	{
		HANDSHAKE = 0,
		STATUS = 1,
		LOGIN = 2,
		PLAY = 3
	}
	public enum Side : int
	{
		Server,
		Client
	}
}
