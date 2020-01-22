
/** テスト。
*/
#define FEE_JSON


/** Enum。
*/
public class Test_05
{
	/** Type
	*/
	public enum Type
	{
		Value = 0,
	}

	/** Type_Byte
	*/
	public enum Type_Byte : byte
	{
		Min = byte.MinValue,
		Max = byte.MaxValue,
	}

	/** Type_SByte
	*/
	public enum Type_SByte : sbyte
	{
		Min = sbyte.MinValue,
		Max = sbyte.MaxValue,
	}

	/** Type_Short
	*/
	public enum Type_Short : short
	{
		Min = short.MinValue,
		Max = short.MaxValue,
	}

	/** Type_Ushort
	*/
	public enum Type_Ushort : ushort
	{
		Min = ushort.MinValue,
		Max = ushort.MaxValue,
	}

	/** Type_Int
	*/
	public enum Type_Int : int
	{
		Min = int.MinValue,
		Max = int.MaxValue,
	}

	/** Type_Uint
	*/
	public enum Type_Uint : uint
	{
		Min = uint.MinValue,
		Max = uint.MaxValue,
	}

	/** Type_Long
	*/
	public enum Type_Long : long
	{
		Min = long.MinValue,
		Max = long.MaxValue,
	}

	/** Type_Ulong
	*/
	public enum Type_Ulong : ulong
	{
		Min = ulong.MinValue,
		Max = ulong.MaxValue,
	}

	/** Item
	*/
	public class Item
	{
		/** 型指定なし。
		*/
		public Type type;

		/** 型指定。最小値。
		*/
		public Type_Byte type_byte_min;
		public Type_SByte type_sbyte_min;
		public Type_Short type_short_min;
		public Type_Ushort type_ushort_min;
		public Type_Int type_int_min;
		public Type_Uint type_uint_min;
		public Type_Long type_long_min;
		public Type_Ulong type_ulong_min;

		/** 型指定。最大値。
		*/
		public Type_Byte type_byte_max;
		public Type_SByte type_sbyte_max;
		public Type_Short type_short_max;
		public Type_Ushort type_ushort_max;
		public Type_Int type_int_max;
		public Type_Uint type_uint_max;
		public Type_Long type_long_max;
		public Type_Ulong type_ulong_max;
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

		t_result &= Test.Check_Enum("value_type",			a_from.type,				a_to.type);

		t_result &= Test.Check_Enum("type_byte_min",		a_from.type_byte_min,		a_to.type_byte_min);
		t_result &= Test.Check_Enum("type_sbyte_min",		a_from.type_sbyte_min,		a_to.type_sbyte_min);
		t_result &= Test.Check_Enum("type_short_min",		a_from.type_short_min,		a_to.type_short_min);
		t_result &= Test.Check_Enum("type_ushort_min",		a_from.type_ushort_min,		a_to.type_ushort_min);
		t_result &= Test.Check_Enum("type_int_min",			a_from.type_int_min,		a_to.type_int_min);
		t_result &= Test.Check_Enum("type_uint_min",		a_from.type_uint_min,		a_to.type_uint_min);
		t_result &= Test.Check_Enum("type_long_min",		a_from.type_long_min,		a_to.type_long_min);
		t_result &= Test.Check_Enum("type_ulong_min",		a_from.type_ulong_min,		a_to.type_ulong_min);

		t_result &= Test.Check_Enum("type_byte_max",		a_from.type_byte_max,		a_to.type_byte_max);
		t_result &= Test.Check_Enum("type_sbyte_max",		a_from.type_sbyte_max,		a_to.type_sbyte_max);
		t_result &= Test.Check_Enum("type_short_max",		a_from.type_short_max,		a_to.type_short_max);
		t_result &= Test.Check_Enum("type_ushort_max",		a_from.type_ushort_max,		a_to.type_ushort_max);
		t_result &= Test.Check_Enum("type_int_max",			a_from.type_int_max,		a_to.type_int_max);
		t_result &= Test.Check_Enum("type_uint_max",		a_from.type_uint_max,		a_to.type_uint_max);
		t_result &= Test.Check_Enum("type_long_max",		a_from.type_long_max,		a_to.type_long_max);
		t_result &= Test.Check_Enum("type_ulong_max",		a_from.type_ulong_max,		a_to.type_ulong_max);

		return t_result;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_05 -----");

		{
			Item t_item_from = new Item();
			{
				t_item_from.type = Type.Value;

				t_item_from.type_byte_min = Type_Byte.Min;
				t_item_from.type_sbyte_min = Type_SByte.Min;
				t_item_from.type_short_min = Type_Short.Min;
				t_item_from.type_ushort_min = Type_Ushort.Min;
				t_item_from.type_int_min = Type_Int.Min;
				t_item_from.type_uint_min = Type_Uint.Min;
				t_item_from.type_long_min = Type_Long.Min;
				t_item_from.type_ulong_min = Type_Ulong.Min;

				t_item_from.type_byte_max = Type_Byte.Max;
				t_item_from.type_sbyte_max = Type_SByte.Max;
				t_item_from.type_short_max = Type_Short.Max;
				t_item_from.type_ushort_max = Type_Ushort.Max;
				t_item_from.type_int_max = Type_Int.Max;
				t_item_from.type_uint_max = Type_Uint.Max;
				t_item_from.type_long_max = Type_Long.Max;
				t_item_from.type_ulong_max = Type_Ulong.Max;
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
			UnityEngine.Debug.Log("Test_05 : " + t_jsonstring);

			//チェック。
			if(Check(t_item_from,t_item_to) == false){
				UnityEngine.Debug.LogError("mismatch");
			}
		}
	}
}

