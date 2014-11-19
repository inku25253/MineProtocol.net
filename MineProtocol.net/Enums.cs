using System;

namespace MineProtocol.net
{
	public enum ProtocolState
	{
		Handshake = 0,
		Status = 1,
		Login = 2,
		Play = 3
	}

	[Flags]
	public enum Side
	{
		Server,
		Client
	}
}
