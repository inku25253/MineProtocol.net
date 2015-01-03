
using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace MineProtocol.net
{
	public struct ProtocolVersion
	{

//新バージョン(Netty版)
		public static readonly ProtocolVersion MC1_8_1 = new ProtocolVersion(47,"1.8.1",true);
		public static readonly ProtocolVersion MC1_8 = new ProtocolVersion(47,"1.8",true);
		public static readonly ProtocolVersion MC1_8_pre3 = new ProtocolVersion(46,"1.8-pre3",true);
		public static readonly ProtocolVersion MC1_8_pre2 = new ProtocolVersion(45,"1.8-pre2",true);
		public static readonly ProtocolVersion MC1_8_pre1 = new ProtocolVersion(44,"1.8-pre1",true);
		public static readonly ProtocolVersion MC14w34d = new ProtocolVersion(43,"14w34d",true);
		public static readonly ProtocolVersion MC14w34c = new ProtocolVersion(42,"14w34c",true);
		public static readonly ProtocolVersion MC14w34b = new ProtocolVersion(41,"14w34b",true);
		public static readonly ProtocolVersion MC14w34a = new ProtocolVersion(40,"14w34a",true);
		public static readonly ProtocolVersion MC14w33c = new ProtocolVersion(39,"14w33c",true);
		public static readonly ProtocolVersion MC14w33b = new ProtocolVersion(38,"14w33b",true);
		public static readonly ProtocolVersion MC14w33a = new ProtocolVersion(37,"14w33a",true);
		public static readonly ProtocolVersion MC14w32d = new ProtocolVersion(36,"14w32d",true);
		public static readonly ProtocolVersion MC14w32c = new ProtocolVersion(35,"14w32c",true);
		public static readonly ProtocolVersion MC14w32b = new ProtocolVersion(34,"14w32b",true);
		public static readonly ProtocolVersion MC14w32a = new ProtocolVersion(33,"14w32a",true);
		public static readonly ProtocolVersion MC14w31a = new ProtocolVersion(32,"14w31a",true);
		public static readonly ProtocolVersion MC14w30c = new ProtocolVersion(31,"14w30c",true);
		public static readonly ProtocolVersion MC14w30a = new ProtocolVersion(30,"14w30a",true);
		public static readonly ProtocolVersion MC14w29a = new ProtocolVersion(29,"14w29a",true);
		public static readonly ProtocolVersion MC14w28b = new ProtocolVersion(28,"14w28b",true);
		public static readonly ProtocolVersion MC14w28a = new ProtocolVersion(27,"14w28a",true);
		public static readonly ProtocolVersion MC14w27b = new ProtocolVersion(26,"14w27b",true);
		public static readonly ProtocolVersion MC14w27a = new ProtocolVersion(26,"14w27a",true);
		public static readonly ProtocolVersion MC14w26c = new ProtocolVersion(25,"14w26c",true);
		public static readonly ProtocolVersion MC14w26b = new ProtocolVersion(24,"14w26b",true);
		public static readonly ProtocolVersion MC14w26a = new ProtocolVersion(23,"14w26a",true);
		public static readonly ProtocolVersion MC14w25b = new ProtocolVersion(22,"14w25b",true);
		public static readonly ProtocolVersion MC14w25a = new ProtocolVersion(21,"14w25a",true);
		public static readonly ProtocolVersion MC14w21b = new ProtocolVersion(20,"14w21b",true);
		public static readonly ProtocolVersion MC14w21a = new ProtocolVersion(19,"14w21a",true);
		public static readonly ProtocolVersion MC14w20a = new ProtocolVersion(18,"14w20a",true);
		public static readonly ProtocolVersion MC14w19a = new ProtocolVersion(17,"14w19a",true);
		public static readonly ProtocolVersion MC14w18b = new ProtocolVersion(16,"14w18b",true);
		public static readonly ProtocolVersion MC14w17a = new ProtocolVersion(15,"14w17a",true);
		public static readonly ProtocolVersion MC14w11a = new ProtocolVersion(14,"14w11a",true);
		public static readonly ProtocolVersion MC14w08a = new ProtocolVersion(12,"14w08a",true);
		public static readonly ProtocolVersion MC14w07a = new ProtocolVersion(11,"14w07a",true);
		public static readonly ProtocolVersion MC14w06a = new ProtocolVersion(10,"14w06a",true);
		public static readonly ProtocolVersion MC14w05a = new ProtocolVersion(9,"14w05a",true);
		public static readonly ProtocolVersion MC14w04b = new ProtocolVersion(8,"14w04b",true);
		public static readonly ProtocolVersion MC14w04a = new ProtocolVersion(7,"14w04a",true);
		public static readonly ProtocolVersion MC14w03a = new ProtocolVersion(6,"14w03a",true);
		public static readonly ProtocolVersion MC14w02a = new ProtocolVersion(5,"14w02a",true);
		public static readonly ProtocolVersion MC1_7_10 = new ProtocolVersion(5,"1.7.10",true);
		public static readonly ProtocolVersion MC1_7_9 = new ProtocolVersion(5,"1.7.9",true);
		public static readonly ProtocolVersion MC1_7_8 = new ProtocolVersion(5,"1.7.8",true);
		public static readonly ProtocolVersion MC1_7_7 = new ProtocolVersion(5,"1.7.7",true);
		public static readonly ProtocolVersion MC1_7_6 = new ProtocolVersion(4,"1.7.6",true);
		public static readonly ProtocolVersion MC1_7_5 = new ProtocolVersion(4,"1.7.5",true);
		public static readonly ProtocolVersion MC1_7_4 = new ProtocolVersion(4,"1.7.4",true);
		public static readonly ProtocolVersion MC1_7_3 = new ProtocolVersion(4,"1.7.3",true);
		public static readonly ProtocolVersion MC1_7_2 = new ProtocolVersion(4,"1.7.2",true);
		public static readonly ProtocolVersion MC1_7_1 = new ProtocolVersion(4,"1.7.1",true);



//旧バージョン
		public static readonly ProtocolVersion MC1_6_4 = new ProtocolVersion(78,"1.6.4");
		public static readonly ProtocolVersion MC1_6_2 = new ProtocolVersion(74,"1.6.2");
		public static readonly ProtocolVersion MC1_6_1 = new ProtocolVersion(73,"1.6.1");
		public static readonly ProtocolVersion MC1_6 = new ProtocolVersion(72,"1.6");
		public static readonly ProtocolVersion MC13w26a = new ProtocolVersion(72,"13w26a");
		public static readonly ProtocolVersion MC13w25c = new ProtocolVersion(71,"13w25c");
		public static readonly ProtocolVersion MC13w25b = new ProtocolVersion(71,"13w25b");
		public static readonly ProtocolVersion MC13w25a = new ProtocolVersion(71,"13w25a");
		public static readonly ProtocolVersion MC13w24b = new ProtocolVersion(70,"13w24b");
		public static readonly ProtocolVersion MC13w24a = new ProtocolVersion(69,"13w24a");
		public static readonly ProtocolVersion MC13w23b = new ProtocolVersion(68,"13w23b");
		public static readonly ProtocolVersion MC13w23a = new ProtocolVersion(67,"13w23a");
		public static readonly ProtocolVersion MC13w22a = new ProtocolVersion(67,"13w22a");
		public static readonly ProtocolVersion MC13w21b = new ProtocolVersion(67,"13w21b");
		public static readonly ProtocolVersion MC13w21a = new ProtocolVersion(67,"13w21a");
		public static readonly ProtocolVersion MC13w19a = new ProtocolVersion(66,"13w19a");
		public static readonly ProtocolVersion MC13w18a = new ProtocolVersion(65,"13w18a");
		public static readonly ProtocolVersion MC13w17a = new ProtocolVersion(64,"13w17a");
		public static readonly ProtocolVersion MC13w16b = new ProtocolVersion(63,"13w16b");
		public static readonly ProtocolVersion MC1_5_2 = new ProtocolVersion(61,"1.5.2");
		public static readonly ProtocolVersion MC1_5_1 = new ProtocolVersion(60,"1.5.1");
		public static readonly ProtocolVersion MC1_5 = new ProtocolVersion(60,"1.5");
		public static readonly ProtocolVersion MC13w09b = new ProtocolVersion(59,"13w09b");
		public static readonly ProtocolVersion MC13w06a = new ProtocolVersion(58,"13w06a");
		public static readonly ProtocolVersion MC13w05b = new ProtocolVersion(57,"13w05b");
		public static readonly ProtocolVersion MC13w05a = new ProtocolVersion(56,"13w05a");
		public static readonly ProtocolVersion MC13w04a = new ProtocolVersion(55,"13w04a");
		public static readonly ProtocolVersion MC13w03a = new ProtocolVersion(54,"13w03a");
		public static readonly ProtocolVersion MC13w02a = new ProtocolVersion(53,"13w02a");
		public static readonly ProtocolVersion MC13w01a = new ProtocolVersion(52,"13w01a");
		public static readonly ProtocolVersion MC1_4_6 = new ProtocolVersion(51,"1.4.6");
		public static readonly ProtocolVersion MC12w49a = new ProtocolVersion(50,"12w49a");
		public static readonly ProtocolVersion MC1_4_4 = new ProtocolVersion(49,"1.4.4");
		public static readonly ProtocolVersion MC1_4_3 = new ProtocolVersion(48,"1.4.3");
		public static readonly ProtocolVersion MC1_4_2 = new ProtocolVersion(47,"1.4.2");
		public static readonly ProtocolVersion MC12w41a = new ProtocolVersion(46,"12w41a");
		public static readonly ProtocolVersion MC12w40a = new ProtocolVersion(45,"12w40a");
		public static readonly ProtocolVersion MC12w34b = new ProtocolVersion(42,"12w34b");
		public static readonly ProtocolVersion MC12w34a = new ProtocolVersion(41,"12w34a");
		public static readonly ProtocolVersion MC12w32a = new ProtocolVersion(40,"12w32a");
		public static readonly ProtocolVersion MC1_3_2 = new ProtocolVersion(39,"1.3.2");
		public static readonly ProtocolVersion MC12w27a = new ProtocolVersion(38,"12w27a");
		public static readonly ProtocolVersion MC12w25_26a = new ProtocolVersion(37,"12w25/26a");
		public static readonly ProtocolVersion MC12w24a = new ProtocolVersion(36,"12w24a");
		public static readonly ProtocolVersion MC12w23a = new ProtocolVersion(35,"12w23a");
		public static readonly ProtocolVersion MC12w22a = new ProtocolVersion(34,"12w22a");
		public static readonly ProtocolVersion MC12w21ab = new ProtocolVersion(33,"12w21ab");
		public static readonly ProtocolVersion MC12w19a = new ProtocolVersion(32,"12w19a");
		public static readonly ProtocolVersion MC12w18a = new ProtocolVersion(32,"12w18a");
		public static readonly ProtocolVersion MC12w17a = new ProtocolVersion(31,"12w17a");
		public static readonly ProtocolVersion MC12w16a = new ProtocolVersion(30,"12w16a");
		public static readonly ProtocolVersion MC1_2_5 = new ProtocolVersion(29,"1.2.5");
		public static readonly ProtocolVersion MC1_2_4 = new ProtocolVersion(29,"1.2.4");
		public static readonly ProtocolVersion MC1_2_3 = new ProtocolVersion(28,"1.2.3");
		public static readonly ProtocolVersion MC12w07a = new ProtocolVersion(27,"12w07a");
		public static readonly ProtocolVersion MC12w06a = new ProtocolVersion(25,"12w06a");
		public static readonly ProtocolVersion MC12w01_05a = new ProtocolVersion(24,"12w01-05a");
		public static readonly ProtocolVersion MC1_1_0 = new ProtocolVersion(23,"1.1.0");
		public static readonly ProtocolVersion MC1_0_0 = new ProtocolVersion(22,"1.0.0");

public static Dictionary<int,List<ProtocolVersion>> ProtocolVersionList = new Dictionary<int,List<ProtocolVersion>>();
		static ProtocolVersion()
		{
			ProtocolVersionList.Add(47,new List<ProtocolVersion>());
			ProtocolVersionList.Add(46,new List<ProtocolVersion>());
			ProtocolVersionList.Add(45,new List<ProtocolVersion>());
			ProtocolVersionList.Add(44,new List<ProtocolVersion>());
			ProtocolVersionList.Add(43,new List<ProtocolVersion>());
			ProtocolVersionList.Add(42,new List<ProtocolVersion>());
			ProtocolVersionList.Add(41,new List<ProtocolVersion>());
			ProtocolVersionList.Add(40,new List<ProtocolVersion>());
			ProtocolVersionList.Add(39,new List<ProtocolVersion>());
			ProtocolVersionList.Add(38,new List<ProtocolVersion>());
			ProtocolVersionList.Add(37,new List<ProtocolVersion>());
			ProtocolVersionList.Add(36,new List<ProtocolVersion>());
			ProtocolVersionList.Add(35,new List<ProtocolVersion>());
			ProtocolVersionList.Add(34,new List<ProtocolVersion>());
			ProtocolVersionList.Add(33,new List<ProtocolVersion>());
			ProtocolVersionList.Add(32,new List<ProtocolVersion>());
			ProtocolVersionList.Add(31,new List<ProtocolVersion>());
			ProtocolVersionList.Add(30,new List<ProtocolVersion>());
			ProtocolVersionList.Add(29,new List<ProtocolVersion>());
			ProtocolVersionList.Add(28,new List<ProtocolVersion>());
			ProtocolVersionList.Add(27,new List<ProtocolVersion>());
			ProtocolVersionList.Add(26,new List<ProtocolVersion>());
			ProtocolVersionList.Add(25,new List<ProtocolVersion>());
			ProtocolVersionList.Add(24,new List<ProtocolVersion>());
			ProtocolVersionList.Add(23,new List<ProtocolVersion>());
			ProtocolVersionList.Add(22,new List<ProtocolVersion>());
			ProtocolVersionList.Add(21,new List<ProtocolVersion>());
			ProtocolVersionList.Add(20,new List<ProtocolVersion>());
			ProtocolVersionList.Add(19,new List<ProtocolVersion>());
			ProtocolVersionList.Add(18,new List<ProtocolVersion>());
			ProtocolVersionList.Add(17,new List<ProtocolVersion>());
			ProtocolVersionList.Add(16,new List<ProtocolVersion>());
			ProtocolVersionList.Add(15,new List<ProtocolVersion>());
			ProtocolVersionList.Add(14,new List<ProtocolVersion>());
			ProtocolVersionList.Add(12,new List<ProtocolVersion>());
			ProtocolVersionList.Add(11,new List<ProtocolVersion>());
			ProtocolVersionList.Add(10,new List<ProtocolVersion>());
			ProtocolVersionList.Add(9,new List<ProtocolVersion>());
			ProtocolVersionList.Add(8,new List<ProtocolVersion>());
			ProtocolVersionList.Add(7,new List<ProtocolVersion>());
			ProtocolVersionList.Add(6,new List<ProtocolVersion>());
			ProtocolVersionList.Add(5,new List<ProtocolVersion>());
			ProtocolVersionList.Add(4,new List<ProtocolVersion>());

//OldNodes
			ProtocolVersionList.Add(78,new List<ProtocolVersion>());
			ProtocolVersionList.Add(74,new List<ProtocolVersion>());
			ProtocolVersionList.Add(73,new List<ProtocolVersion>());
			ProtocolVersionList.Add(72,new List<ProtocolVersion>());
			ProtocolVersionList.Add(71,new List<ProtocolVersion>());
			ProtocolVersionList.Add(70,new List<ProtocolVersion>());
			ProtocolVersionList.Add(69,new List<ProtocolVersion>());
			ProtocolVersionList.Add(68,new List<ProtocolVersion>());
			ProtocolVersionList.Add(67,new List<ProtocolVersion>());
			ProtocolVersionList.Add(66,new List<ProtocolVersion>());
			ProtocolVersionList.Add(65,new List<ProtocolVersion>());
			ProtocolVersionList.Add(64,new List<ProtocolVersion>());
			ProtocolVersionList.Add(63,new List<ProtocolVersion>());
			ProtocolVersionList.Add(61,new List<ProtocolVersion>());
			ProtocolVersionList.Add(60,new List<ProtocolVersion>());
			ProtocolVersionList.Add(59,new List<ProtocolVersion>());
			ProtocolVersionList.Add(58,new List<ProtocolVersion>());
			ProtocolVersionList.Add(57,new List<ProtocolVersion>());
			ProtocolVersionList.Add(56,new List<ProtocolVersion>());
			ProtocolVersionList.Add(55,new List<ProtocolVersion>());
			ProtocolVersionList.Add(54,new List<ProtocolVersion>());
			ProtocolVersionList.Add(53,new List<ProtocolVersion>());
			ProtocolVersionList.Add(52,new List<ProtocolVersion>());
			ProtocolVersionList.Add(51,new List<ProtocolVersion>());
			ProtocolVersionList.Add(50,new List<ProtocolVersion>());
			ProtocolVersionList.Add(49,new List<ProtocolVersion>());
			ProtocolVersionList.Add(48,new List<ProtocolVersion>());
			ProtocolVersionList[47].Add(MC1_8_1);
			ProtocolVersionList[47].Add(MC1_8);
			ProtocolVersionList[46].Add(MC1_8_pre3);
			ProtocolVersionList[45].Add(MC1_8_pre2);
			ProtocolVersionList[44].Add(MC1_8_pre1);
			ProtocolVersionList[43].Add(MC14w34d);
			ProtocolVersionList[42].Add(MC14w34c);
			ProtocolVersionList[41].Add(MC14w34b);
			ProtocolVersionList[40].Add(MC14w34a);
			ProtocolVersionList[39].Add(MC14w33c);
			ProtocolVersionList[38].Add(MC14w33b);
			ProtocolVersionList[37].Add(MC14w33a);
			ProtocolVersionList[36].Add(MC14w32d);
			ProtocolVersionList[35].Add(MC14w32c);
			ProtocolVersionList[34].Add(MC14w32b);
			ProtocolVersionList[33].Add(MC14w32a);
			ProtocolVersionList[32].Add(MC14w31a);
			ProtocolVersionList[31].Add(MC14w30c);
			ProtocolVersionList[30].Add(MC14w30a);
			ProtocolVersionList[29].Add(MC14w29a);
			ProtocolVersionList[28].Add(MC14w28b);
			ProtocolVersionList[27].Add(MC14w28a);
			ProtocolVersionList[26].Add(MC14w27b);
			ProtocolVersionList[26].Add(MC14w27a);
			ProtocolVersionList[25].Add(MC14w26c);
			ProtocolVersionList[24].Add(MC14w26b);
			ProtocolVersionList[23].Add(MC14w26a);
			ProtocolVersionList[22].Add(MC14w25b);
			ProtocolVersionList[21].Add(MC14w25a);
			ProtocolVersionList[20].Add(MC14w21b);
			ProtocolVersionList[19].Add(MC14w21a);
			ProtocolVersionList[18].Add(MC14w20a);
			ProtocolVersionList[17].Add(MC14w19a);
			ProtocolVersionList[16].Add(MC14w18b);
			ProtocolVersionList[15].Add(MC14w17a);
			ProtocolVersionList[14].Add(MC14w11a);
			ProtocolVersionList[12].Add(MC14w08a);
			ProtocolVersionList[11].Add(MC14w07a);
			ProtocolVersionList[10].Add(MC14w06a);
			ProtocolVersionList[9].Add(MC14w05a);
			ProtocolVersionList[8].Add(MC14w04b);
			ProtocolVersionList[7].Add(MC14w04a);
			ProtocolVersionList[6].Add(MC14w03a);
			ProtocolVersionList[5].Add(MC14w02a);
			ProtocolVersionList[5].Add(MC1_7_10);
			ProtocolVersionList[5].Add(MC1_7_9);
			ProtocolVersionList[5].Add(MC1_7_8);
			ProtocolVersionList[5].Add(MC1_7_7);
			ProtocolVersionList[4].Add(MC1_7_6);
			ProtocolVersionList[4].Add(MC1_7_5);
			ProtocolVersionList[4].Add(MC1_7_4);
			ProtocolVersionList[4].Add(MC1_7_3);
			ProtocolVersionList[4].Add(MC1_7_2);
			ProtocolVersionList[4].Add(MC1_7_1);
			ProtocolVersionList[78].Add(MC1_6_4);
			ProtocolVersionList[74].Add(MC1_6_2);
			ProtocolVersionList[73].Add(MC1_6_1);
			ProtocolVersionList[72].Add(MC1_6);
			ProtocolVersionList[72].Add(MC13w26a);
			ProtocolVersionList[71].Add(MC13w25c);
			ProtocolVersionList[71].Add(MC13w25b);
			ProtocolVersionList[71].Add(MC13w25a);
			ProtocolVersionList[70].Add(MC13w24b);
			ProtocolVersionList[69].Add(MC13w24a);
			ProtocolVersionList[68].Add(MC13w23b);
			ProtocolVersionList[67].Add(MC13w23a);
			ProtocolVersionList[67].Add(MC13w22a);
			ProtocolVersionList[67].Add(MC13w21b);
			ProtocolVersionList[67].Add(MC13w21a);
			ProtocolVersionList[66].Add(MC13w19a);
			ProtocolVersionList[65].Add(MC13w18a);
			ProtocolVersionList[64].Add(MC13w17a);
			ProtocolVersionList[63].Add(MC13w16b);
			ProtocolVersionList[61].Add(MC1_5_2);
			ProtocolVersionList[60].Add(MC1_5_1);
			ProtocolVersionList[60].Add(MC1_5);
			ProtocolVersionList[59].Add(MC13w09b);
			ProtocolVersionList[58].Add(MC13w06a);
			ProtocolVersionList[57].Add(MC13w05b);
			ProtocolVersionList[56].Add(MC13w05a);
			ProtocolVersionList[55].Add(MC13w04a);
			ProtocolVersionList[54].Add(MC13w03a);
			ProtocolVersionList[53].Add(MC13w02a);
			ProtocolVersionList[52].Add(MC13w01a);
			ProtocolVersionList[51].Add(MC1_4_6);
			ProtocolVersionList[50].Add(MC12w49a);
			ProtocolVersionList[49].Add(MC1_4_4);
			ProtocolVersionList[48].Add(MC1_4_3);
			ProtocolVersionList[47].Add(MC1_4_2);
			ProtocolVersionList[46].Add(MC12w41a);
			ProtocolVersionList[45].Add(MC12w40a);
			ProtocolVersionList[42].Add(MC12w34b);
			ProtocolVersionList[41].Add(MC12w34a);
			ProtocolVersionList[40].Add(MC12w32a);
			ProtocolVersionList[39].Add(MC1_3_2);
			ProtocolVersionList[38].Add(MC12w27a);
			ProtocolVersionList[37].Add(MC12w25_26a);
			ProtocolVersionList[36].Add(MC12w24a);
			ProtocolVersionList[35].Add(MC12w23a);
			ProtocolVersionList[34].Add(MC12w22a);
			ProtocolVersionList[33].Add(MC12w21ab);
			ProtocolVersionList[32].Add(MC12w19a);
			ProtocolVersionList[32].Add(MC12w18a);
			ProtocolVersionList[31].Add(MC12w17a);
			ProtocolVersionList[30].Add(MC12w16a);
			ProtocolVersionList[29].Add(MC1_2_5);
			ProtocolVersionList[29].Add(MC1_2_4);
			ProtocolVersionList[28].Add(MC1_2_3);
			ProtocolVersionList[27].Add(MC12w07a);
			ProtocolVersionList[25].Add(MC12w06a);
			ProtocolVersionList[24].Add(MC12w01_05a);
			ProtocolVersionList[23].Add(MC1_1_0);
			ProtocolVersionList[22].Add(MC1_0_0);

		}


		[JsonProperty(PropertyName="protocol")]
		public readonly int ProtocolID;
		[JsonProperty(PropertyName="name")]
		public readonly string VersionName ;
		[NonSerialized]
		public readonly bool IsNewProtocol;



		public ProtocolVersion(int protocolId,string versionName,bool isNewProtocol = false)
		{
			this.ProtocolID = protocolId;
			this.VersionName = versionName;
			this.IsNewProtocol = isNewProtocol;
		}

		
		public static explicit operator int(ProtocolVersion info)
		{
			return info.ProtocolID;
		}
		public static explicit operator string(ProtocolVersion info)
		{
			return info.VersionName;
		}

		public static bool operator ==(ProtocolVersion a, ProtocolVersion b)
		{
			return a.ProtocolID == b.ProtocolID;
		}
		public static bool operator !=(ProtocolVersion a, ProtocolVersion b)
		{
			return a.ProtocolID != b.ProtocolID;
		}
		public static bool operator >(ProtocolVersion a, ProtocolVersion b)
		{
			int av = a.IsNewProtocol ? a.ProtocolID + 100 : a.ProtocolID;
			int bv = b.IsNewProtocol ? b.ProtocolID + 100 : b.ProtocolID;

			return av > bv;
		}
		public static bool operator >=(ProtocolVersion a, ProtocolVersion b)
		{
			int av = a.IsNewProtocol ? a.ProtocolID + 100 : a.ProtocolID;
			int bv = b.IsNewProtocol ? b.ProtocolID + 100 : b.ProtocolID;

			return av >= bv;
		}
		public static bool operator <(ProtocolVersion a, ProtocolVersion b)
		{
			int av = a.IsNewProtocol ? a.ProtocolID + 100 : a.ProtocolID;
			int bv = b.IsNewProtocol ? b.ProtocolID + 100 : b.ProtocolID;

			return av > bv;
		}
		public static bool operator <=(ProtocolVersion a, ProtocolVersion b)
		{
			int av = a.IsNewProtocol ? a.ProtocolID + 100 : a.ProtocolID;
			int bv = b.IsNewProtocol ? b.ProtocolID + 100 : b.ProtocolID;

			return av >= bv;
		}


		public override int GetHashCode()
		{
			return this.ProtocolID;
		}
		public override bool Equals(object obj)
		{
			if (obj is ProtocolVersion == false)
				return false;

			return this.ProtocolID == ((ProtocolVersion)obj).ProtocolID;
		}

	}
}