﻿

/** テスト。
*/
#define FEE_JSON


/** Simple
*/
namespace Simple
{
	/** 最大値。
	*/
	public class Test_01
	{
		/** Item
		*/
		public class Item
		{
			public bool value_bool;
			public sbyte value_sbyte;
			public byte value_byte;
			public short value_short;
			public ushort value_ushort;
			public int value_int;
			public uint value_uint;
			public long value_long;
			public ulong value_ulong;
			public char value_char;
			public float value_float;
			public double value_double;
			public decimal value_decimal;
		}

		/** チェック。
		*/
		public static bool Check(Item a_from,Item a_to)
		{
			if(a_to == null){
				UnityEngine.Debug.LogWarning("mismatch : null");
				return false;
			}

			bool t_result = true;

			t_result &= Simple.Check_Bool(		"value_bool",		a_from.value_bool,		a_to.value_bool);
			t_result &= Simple.Check_Sbyte(		"value_sbyte",		a_from.value_sbyte,		a_to.value_sbyte);
			t_result &= Simple.Check_Byte(		"value_byte",		a_from.value_byte,		a_to.value_byte);
			t_result &= Simple.Check_Short(		"value_short",		a_from.value_short,		a_to.value_short);
			t_result &= Simple.Check_Ushort(	"value_ushort",		a_from.value_ushort,	a_to.value_ushort);
			t_result &= Simple.Check_Int(		"value_int",		a_from.value_int,		a_to.value_int);
			t_result &= Simple.Check_Uint(		"value_uint",		a_from.value_uint,		a_to.value_uint);
			t_result &= Simple.Check_Long(		"value_long",		a_from.value_long,		a_to.value_long);
			t_result &= Simple.Check_Ulong(		"value_ulong",		a_from.value_ulong,		a_to.value_ulong);
			t_result &= Simple.Check_Char(		"value_char",		a_from.value_char,		a_to.value_char);
			t_result &= Simple.Check_Float(		"value_float",		a_from.value_float,		a_to.value_float);
			t_result &= Simple.Check_Double(	"value_double",		a_from.value_double,	a_to.value_double);
			t_result &= Simple.Check_Decimal(	"value_decimal",	a_from.value_decimal,	a_to.value_decimal);

			return t_result;
		}

		/** 更新。
		*/
		public static void Main(string a_label = nameof(Test_01))
		{
			UnityEngine.Debug.Log("----- " + a_label + " -----");

			try{
				Item t_item_from = new Item();
				{
					t_item_from.value_bool = true;
					t_item_from.value_sbyte = sbyte.MaxValue;
					t_item_from.value_byte = byte.MaxValue;
					t_item_from.value_short = short.MaxValue;
					t_item_from.value_ushort = ushort.MaxValue;
					t_item_from.value_int = int.MaxValue;
					t_item_from.value_uint = uint.MaxValue;
					t_item_from.value_long = long.MaxValue;
					t_item_from.value_ulong = ulong.MaxValue;
					t_item_from.value_char = char.MaxValue;
					t_item_from.value_float = float.MaxValue;
					t_item_from.value_double = double.MaxValue;
					t_item_from.value_decimal = decimal.MaxValue - 0.1m;
				}

				//オブジェクト ==> ＪＳＯＮＩＴＥＭ。
				#if(FEE_JSON)
				Fee.JsonItem.JsonItem t_jsonitem = Fee.JsonItem.Convert.ObjectToJsonItem<Item>(t_item_from);
				#endif

				//ＪＳＯＮＩＴＥＭ ==> ＪＳＯＮ文字列。
				#if(FEE_JSON)
				string t_jsonstring = t_jsonitem.ConvertToJsonString();
				#else
				string t_jsonstring = UnityEngine.JsonUtility.ToJson(t_item_from);
				#endif

				//ＪＳＯＮ文字列 ==> オブジェクト。
				#if(FEE_JSON)
				Item t_item_to = Fee.JsonItem.Convert.JsonStringToObject<Item>(t_jsonstring);
				#else
				Item t_item_to = UnityEngine.JsonUtility.FromJson<Item>(t_jsonstring);
				#endif

				//ログ。
				UnityEngine.Debug.Log(a_label + " : " + t_jsonstring);

				//チェック。
				if(Check(t_item_from,t_item_to) == false){
					UnityEngine.Debug.LogError("mismatch");
				}
			}catch(System.Exception t_exception){
				UnityEngine.Debug.LogError(a_label + " : exception : " + t_exception.Message);
			}
		}
	}
}


