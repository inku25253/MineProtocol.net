namespace MineProtocol.net
{
	public interface IPacketData
	{
		int ProtocolId { get; }
		ProtocolState ProtocolStatus { get; }

		Side Sides { get; }


	}
}
