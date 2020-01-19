
/** テスト。
*/
#define FEE_JSON


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
	public static void Check(Item a_from,Item a_to)
	{
		if(a_to == null){
			UnityEngine.Debug.LogWarning("mismatch : null");
			return;
		}

		Test.Check_Bool(	"value_bool",		a_from.value_bool,		a_to.value_bool);
		Test.Check_Sbyte(	"value_sbyte",		a_from.value_sbyte,		a_to.value_sbyte);
		Test.Check_Byte(	"value_byte",		a_from.value_byte,		a_to.value_byte);
		Test.Check_Short(	"value_short",		a_from.value_short,		a_to.value_short);
		Test.Check_Ushort(	"value_ushort",		a_from.value_ushort,	a_to.value_ushort);
		Test.Check_Int(		"value_int",		a_from.value_int,		a_to.value_int);
		Test.Check_Uint(	"value_uint",		a_from.value_uint,		a_to.value_uint);
		Test.Check_Long(	"value_long",		a_from.value_long,		a_to.value_long);
		Test.Check_Ulong(	"value_ulong",		a_from.value_ulong,		a_to.value_ulong);
		Test.Check_Char(	"value_char",		a_from.value_char,		a_to.value_char);
		Test.Check_Float(	"value_float",		a_from.value_float,		a_to.value_float);
		Test.Check_Double(	"value_double",		a_from.value_double,	a_to.value_double);
		Test.Check_Decimal(	"value_decimal",	a_from.value_decimal,	a_to.value_decimal);
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_01 -----");

		{
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
				t_item_from.value_decimal = decimal.MaxValue;
			}

			//オブジェクト ==> ＪＳＯＮＩＴＥＭ。
			#if(FEE_JSON)
			Fee.JsonItem.JsonItem t_jsonitem = Fee.JsonItem.Convert.ObjectToJsonItem<Item>(t_item_from);
			#endif

			//ＪＳＯＮＩＴＥＭ ==> ＪＳＯＮ文字列。
			#if(FEE_JSON)
			string t_jsonstring = t_jsonitem.ConvertJsonString();
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
			UnityEngine.Debug.Log("Test_01 : " + t_jsonstring);

			//チェック。
			Check(t_item_from,t_item_to);
		}
	}
}

