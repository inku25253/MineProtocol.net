
using System;

namespace MineProtocol.net
{


	public class VersionInfo
	{
		
		public int ProtocolID{ get; private set;}
		public string VersionName {get; private set;}
		public bool IsNewProtocol{ get; private set;}
		public VersionInfo(int protocolId,string versionName,bool isNewProtocol = false)
		{
			this.ProtocolID = protocolId;
			this.VersionName = versionName;
			this.IsNewProtocol = isNewProtocol;
		}
	}
	public class ProtocolVersion
	{

//新バージョン(Netty版)
		public static readonly VersionInfo MC1_8 = new VersionInfo(47,"1.8",true);
		public static readonly VersionInfo MC1_8_pre3 = new VersionInfo(46,"1.8-pre3",true);
		public static readonly VersionInfo MC1_8_pre2 = new VersionInfo(45,"1.8-pre2",true);
		public static readonly VersionInfo MC1_8_pre1 = new VersionInfo(44,"1.8-pre1",true);
		public static readonly VersionInfo MC14w34d = new VersionInfo(43,"14w34d",true);
		public static readonly VersionInfo MC14w34c = new VersionInfo(42,"14w34c",true);
		public static readonly VersionInfo MC14w34b = new VersionInfo(41,"14w34b",true);
		public static readonly VersionInfo MC14w34a = new VersionInfo(40,"14w34a",true);
		public static readonly VersionInfo MC14w33c = new VersionInfo(39,"14w33c",true);
		public static readonly VersionInfo MC14w33b = new VersionInfo(38,"14w33b",true);
		public static readonly VersionInfo MC14w33a = new VersionInfo(37,"14w33a",true);
		public static readonly VersionInfo MC14w32d = new VersionInfo(36,"14w32d",true);
		public static readonly VersionInfo MC14w32c = new VersionInfo(35,"14w32c",true);
		public static readonly VersionInfo MC14w32b = new VersionInfo(34,"14w32b",true);
		public static readonly VersionInfo MC14w32a = new VersionInfo(33,"14w32a",true);
		public static readonly VersionInfo MC14w31a = new VersionInfo(32,"14w31a",true);
		public static readonly VersionInfo MC14w30c = new VersionInfo(31,"14w30c",true);
		public static readonly VersionInfo MC14w30a = new VersionInfo(30,"14w30a",true);
		public static readonly VersionInfo MC14w29a = new VersionInfo(29,"14w29a",true);
		public static readonly VersionInfo MC14w28b = new VersionInfo(28,"14w28b",true);
		public static readonly VersionInfo MC14w28a = new VersionInfo(27,"14w28a",true);
		public static readonly VersionInfo MC14w27b = new VersionInfo(26,"14w27b",true);
		public static readonly VersionInfo MC14w27a = new VersionInfo(26,"14w27a",true);
		public static readonly VersionInfo MC14w26c = new VersionInfo(25,"14w26c",true);
		public static readonly VersionInfo MC14w26b = new VersionInfo(24,"14w26b",true);
		public static readonly VersionInfo MC14w26a = new VersionInfo(23,"14w26a",true);
		public static readonly VersionInfo MC14w25b = new VersionInfo(22,"14w25b",true);
		public static readonly VersionInfo MC14w25a = new VersionInfo(21,"14w25a",true);
		public static readonly VersionInfo MC14w21b = new VersionInfo(20,"14w21b",true);
		public static readonly VersionInfo MC14w21a = new VersionInfo(19,"14w21a",true);
		public static readonly VersionInfo MC14w20a = new VersionInfo(18,"14w20a",true);
		public static readonly VersionInfo MC14w19a = new VersionInfo(17,"14w19a",true);
		public static readonly VersionInfo MC14w18b = new VersionInfo(16,"14w18b",true);
		public static readonly VersionInfo MC14w17a = new VersionInfo(15,"14w17a",true);
		public static readonly VersionInfo MC14w11a = new VersionInfo(14,"14w11a",true);
		public static readonly VersionInfo MC14w08a = new VersionInfo(12,"14w08a",true);
		public static readonly VersionInfo MC14w07a = new VersionInfo(11,"14w07a",true);
		public static readonly VersionInfo MC14w06a = new VersionInfo(10,"14w06a",true);
		public static readonly VersionInfo MC14w05a = new VersionInfo(9,"14w05a",true);
		public static readonly VersionInfo MC14w04b = new VersionInfo(8,"14w04b",true);
		public static readonly VersionInfo MC14w04a = new VersionInfo(7,"14w04a",true);
		public static readonly VersionInfo MC14w03a = new VersionInfo(6,"14w03a",true);
		public static readonly VersionInfo MC14w02a = new VersionInfo(5,"14w02a",true);
		public static readonly VersionInfo MC1_7_10 = new VersionInfo(5,"1.7.10",true);
		public static readonly VersionInfo MC1_7_9 = new VersionInfo(5,"1.7.9",true);
		public static readonly VersionInfo MC1_7_8 = new VersionInfo(5,"1.7.8",true);
		public static readonly VersionInfo MC1_7_7 = new VersionInfo(5,"1.7.7",true);
		public static readonly VersionInfo MC1_7_6 = new VersionInfo(4,"1.7.6",true);
		public static readonly VersionInfo MC1_7_5 = new VersionInfo(4,"1.7.5",true);
		public static readonly VersionInfo MC1_7_4 = new VersionInfo(4,"1.7.4",true);
		public static readonly VersionInfo MC1_7_3 = new VersionInfo(4,"1.7.3",true);
		public static readonly VersionInfo MC1_7_2 = new VersionInfo(4,"1.7.2",true);
		public static readonly VersionInfo MC1_7_1 = new VersionInfo(4,"1.7.1",true);



//旧バージョン
		public static readonly VersionInfo MC1_6_4 = new VersionInfo(78,"1.6.4");
		public static readonly VersionInfo MC1_6_2 = new VersionInfo(74,"1.6.2");
		public static readonly VersionInfo MC1_6_1 = new VersionInfo(73,"1.6.1");
		public static readonly VersionInfo MC1_6 = new VersionInfo(72,"1.6");
		public static readonly VersionInfo MC13w26a = new VersionInfo(72,"13w26a");
		public static readonly VersionInfo MC13w25c = new VersionInfo(71,"13w25c");
		public static readonly VersionInfo MC13w25b = new VersionInfo(71,"13w25b");
		public static readonly VersionInfo MC13w25a = new VersionInfo(71,"13w25a");
		public static readonly VersionInfo MC13w24b = new VersionInfo(70,"13w24b");
		public static readonly VersionInfo MC13w24a = new VersionInfo(69,"13w24a");
		public static readonly VersionInfo MC13w23b = new VersionInfo(68,"13w23b");
		public static readonly VersionInfo MC13w23a = new VersionInfo(67,"13w23a");
		public static readonly VersionInfo MC13w22a = new VersionInfo(67,"13w22a");
		public static readonly VersionInfo MC13w21b = new VersionInfo(67,"13w21b");
		public static readonly VersionInfo MC13w21a = new VersionInfo(67,"13w21a");
		public static readonly VersionInfo MC13w19a = new VersionInfo(66,"13w19a");
		public static readonly VersionInfo MC13w18a = new VersionInfo(65,"13w18a");
		public static readonly VersionInfo MC13w17a = new VersionInfo(64,"13w17a");
		public static readonly VersionInfo MC13w16b = new VersionInfo(63,"13w16b");
		public static readonly VersionInfo MC1_5_2 = new VersionInfo(61,"1.5.2");
		public static readonly VersionInfo MC1_5_1 = new VersionInfo(60,"1.5.1");
		public static readonly VersionInfo MC1_5 = new VersionInfo(60,"1.5");
		public static readonly VersionInfo MC13w09b = new VersionInfo(59,"13w09b");
		public static readonly VersionInfo MC13w06a = new VersionInfo(58,"13w06a");
		public static readonly VersionInfo MC13w05b = new VersionInfo(57,"13w05b");
		public static readonly VersionInfo MC13w05a = new VersionInfo(56,"13w05a");
		public static readonly VersionInfo MC13w04a = new VersionInfo(55,"13w04a");
		public static readonly VersionInfo MC13w03a = new VersionInfo(54,"13w03a");
		public static readonly VersionInfo MC13w02a = new VersionInfo(53,"13w02a");
		public static readonly VersionInfo MC13w01a = new VersionInfo(52,"13w01a");
		public static readonly VersionInfo MC1_4_6 = new VersionInfo(51,"1.4.6");
		public static readonly VersionInfo MC12w49a = new VersionInfo(50,"12w49a");
		public static readonly VersionInfo MC1_4_4 = new VersionInfo(49,"1.4.4");
		public static readonly VersionInfo MC1_4_3 = new VersionInfo(48,"1.4.3");
		public static readonly VersionInfo MC1_4_2 = new VersionInfo(47,"1.4.2");
		public static readonly VersionInfo MC12w41a = new VersionInfo(46,"12w41a");
		public static readonly VersionInfo MC12w40a = new VersionInfo(45,"12w40a");
		public static readonly VersionInfo MC12w34b = new VersionInfo(42,"12w34b");
		public static readonly VersionInfo MC12w34a = new VersionInfo(41,"12w34a");
		public static readonly VersionInfo MC12w32a = new VersionInfo(40,"12w32a");
		public static readonly VersionInfo MC1_3_2 = new VersionInfo(39,"1.3.2");
		public static readonly VersionInfo MC12w27a = new VersionInfo(38,"12w27a");
		public static readonly VersionInfo MC12w25_26a = new VersionInfo(37,"12w25/26a");
		public static readonly VersionInfo MC12w24a = new VersionInfo(36,"12w24a");
		public static readonly VersionInfo MC12w23a = new VersionInfo(35,"12w23a");
		public static readonly VersionInfo MC12w22a = new VersionInfo(34,"12w22a");
		public static readonly VersionInfo MC12w21ab = new VersionInfo(33,"12w21ab");
		public static readonly VersionInfo MC12w19a = new VersionInfo(32,"12w19a");
		public static readonly VersionInfo MC12w18a = new VersionInfo(32,"12w18a");
		public static readonly VersionInfo MC12w17a = new VersionInfo(31,"12w17a");
		public static readonly VersionInfo MC12w16a = new VersionInfo(30,"12w16a");
		public static readonly VersionInfo MC1_2_5 = new VersionInfo(29,"1.2.5");
		public static readonly VersionInfo MC1_2_4 = new VersionInfo(29,"1.2.4");
		public static readonly VersionInfo MC1_2_3 = new VersionInfo(28,"1.2.3");
		public static readonly VersionInfo MC12w07a = new VersionInfo(27,"12w07a");
		public static readonly VersionInfo MC12w06a = new VersionInfo(25,"12w06a");
		public static readonly VersionInfo MC12w01_05a = new VersionInfo(24,"12w01-05a");
		public static readonly VersionInfo MC1_1_0 = new VersionInfo(23,"1.1.0");
		public static readonly VersionInfo MC1_0_0 = new VersionInfo(22,"1.0.0");
	}
}