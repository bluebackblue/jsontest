
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
			{
				if(t_item_from.value_bool != t_item_to.value_bool){
					UnityEngine.Debug.LogWarning("mismatch : value_bool : "		+ t_item_from.value_bool.ToString()		+ " : " + t_item_to.value_bool.ToString());
				}
				if(t_item_from.value_sbyte != t_item_to.value_sbyte){
					UnityEngine.Debug.LogWarning("mismatch : value_sbyte : "		+ t_item_from.value_sbyte.ToString()		+ " : " + t_item_to.value_sbyte.ToString());
				}
				if(t_item_from.value_byte != t_item_to.value_byte){
					UnityEngine.Debug.LogWarning("mismatch : value_byte : "		+ t_item_from.value_byte.ToString()			+ " : " + t_item_to.value_byte.ToString());
				}
				if(t_item_from.value_short != t_item_to.value_short){
					UnityEngine.Debug.LogWarning("mismatch : value_short : "		+ t_item_from.value_short.ToString()		+ " : " + t_item_to.value_short.ToString());
				}
				if(t_item_from.value_ushort != t_item_to.value_ushort){
					UnityEngine.Debug.LogWarning("mismatch : value_ushort : "		+ t_item_from.value_ushort.ToString()		+ " : " + t_item_to.value_ushort.ToString());
				}
				if(t_item_from.value_int != t_item_to.value_int){
					UnityEngine.Debug.LogWarning("mismatch : value_int : "			+ t_item_from.value_int.ToString()			+ " : " + t_item_to.value_int.ToString());
				}
				if(t_item_from.value_uint != t_item_to.value_uint){
					UnityEngine.Debug.LogWarning("mismatch : value_uint : "		+ t_item_from.value_uint.ToString()			+ " : " + t_item_to.value_uint.ToString());
				}
				if(t_item_from.value_long != t_item_to.value_long){
					UnityEngine.Debug.LogWarning("mismatch : value_long : "		+ t_item_from.value_long.ToString()			+ " : " + t_item_to.value_long.ToString());
				}
				if(t_item_from.value_ulong != t_item_to.value_ulong){
					UnityEngine.Debug.LogWarning("mismatch : value_ulong : "		+ t_item_from.value_ulong.ToString()		+ " : " + t_item_to.value_ulong.ToString());
				}
				if(t_item_from.value_char != t_item_to.value_char){
					UnityEngine.Debug.LogWarning("mismatch : value_char : "		+ t_item_from.value_char.ToString()			+ " : " + t_item_to.value_char.ToString());
				}
				if(t_item_from.value_float != t_item_to.value_float){
					UnityEngine.Debug.LogWarning("mismatch : value_float : "		+ t_item_from.value_float.ToString()		+ " : " + t_item_to.value_float.ToString());
				}
				if(t_item_from.value_double != t_item_to.value_double){
					UnityEngine.Debug.LogWarning("mismatch : value_double : "		+ t_item_from.value_double.ToString()		+ " : " + t_item_to.value_double.ToString());
				}
				if(t_item_from.value_decimal != t_item_to.value_decimal){
					UnityEngine.Debug.LogWarning("mismatch : value_decimal : "		+ t_item_from.value_decimal.ToString()		+ " : " + t_item_to.value_decimal.ToString());
				}
			}
		}
	}
}

