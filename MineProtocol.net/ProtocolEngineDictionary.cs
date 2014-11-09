using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineProtocol.net
{
	public class ProtocolEngineDictionary
	{
		List<MultiKeyValue?> collection = new List<MultiKeyValue?>();
		MultiKeyValue?[] usingCollection;


		public ProtocolVersion UsingVersion;
		public Side Side;
		public ProtocolState State;



		public ProtocolEngineDictionary(ProtocolVersion usingVersion)
		{
			this.UsingVersion = usingVersion;
		}

		public Delegate this[Type packetDataType]
		{
			get { return Get(packetDataType); }
		}


		public void Flush()
		{
			var v = from p in collection where p.HasValue && p.Value.Version == UsingVersion && p.Value.Side == Side && p.Value.ProtocolState == State select p;
			usingCollection = v.ToArray();
		}




		public Delegate Get(Type packetDataType)
		{
			if (usingCollection == null)
				throw new InvalidOperationException("初期化がされていません。 UsingVersionとSideとStateを設定してFlush()を実行してください。");
			for (int i = 0; i < usingCollection.Length; ++i)
			{
				MultiKeyValue? value = usingCollection[i];
				if (value.HasValue == false)
					continue;
				//if (value == null)
				//	continue;
				if (value.Value.DataType != packetDataType)
					continue;
				return value.Value.Value;
			}
			return null;
		}
		public Delegate Get(int packetId)
		{
			if (usingCollection == null)
				throw new InvalidOperationException("初期化がされていません。 UsingVersionとSideとStateを設定してFlush()を実行してください。");
			for (int i = 0; i < usingCollection.Length; ++i)
			{
				MultiKeyValue? value = usingCollection[i];
				if (value.HasValue == false)
					continue;
				//if (value == null)
				//	continue;
				if (value.Value.Key != packetId)
					continue;
				return value.Value.Value;
			}
			return null;
		}
		public void Add(Type packetDataType, int packetId,Side side, ProtocolState protocolState, Delegate value1)
		{
			MultiKeyValue value = new MultiKeyValue()
			{
				Version = UsingVersion,
				Side = side,
				ProtocolState = protocolState,
				DataType = packetDataType,
				Value = value1,
				Key = packetId
			};
			collection.Add(value);
		}
		public bool ContainsKey(ProtocolVersion version, Side side, ProtocolState state, Type packetDataType)
		{
			return collection.Any(
				(k) => k.HasValue || k.Value.Version == version && k.Value.Side == side && k.Value.ProtocolState == state && k.Value.DataType == packetDataType
			);
		}
		public bool ContainsKey(Type packetData)
		{
			return usingCollection.Any((p) => p.HasValue ||  p.Value.DataType == packetData);
		}

	}
	public struct MultiKeyValue
	{
		public ProtocolVersion Version;
		public Side Side;
		public ProtocolState ProtocolState;
		public Type DataType;
		public int Key;

		public Delegate Value;

	}
}
