
/** テスト。
*/
#define FEE_JSON


/** System.Object。
*/
public class Test_26
{
	/** Item
	*/
	public class Item
	{
		public System.Object value_bool;
		public System.Object value_sbyte;
		public System.Object value_byte;
		public System.Object value_short;
		public System.Object value_ushort;
		public System.Object value_int;
		public System.Object value_uint;
		public System.Object value_long;
		public System.Object value_ulong;
		public System.Object value_char;
		public System.Object value_float;
		public System.Object value_double;
		public System.Object value_decimal;

		public System.Object value_list;
		public System.Object value_dictionary;
		public System.Object value_array;
	}

	/** チェック。
	*/
	public static bool Check(Item a_item_from,Item a_item_to)
	{
		if(a_item_to == null){
			UnityEngine.Debug.LogWarning("mismatch : null");
			return false;
		}

		bool t_result = true;
		return t_result;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_26 -----");

		{
			Item t_item_from = new Item();
			{
				System.Collections.Generic.List<int> t_value_list = new System.Collections.Generic.List<int>();
				t_value_list.Add(1);
				t_value_list.Add(2);
				t_value_list.Add(3);
				
				System.Collections.Generic.Dictionary<string,int> t_value_dictionary = new System.Collections.Generic.Dictionary<string,int>();
				t_value_dictionary.Add("value_4",4);
				t_value_dictionary.Add("value_5",5);
				t_value_dictionary.Add("value_6",6);

				int[] t_value_array = new int[3]; 
				t_value_array[0] = 7;
				t_value_array[1] = 8;
				t_value_array[2] = 9;


				t_item_from.value_bool			= true;
				t_item_from.value_sbyte			= sbyte.MaxValue;
				t_item_from.value_byte			= sbyte.MaxValue;
				t_item_from.value_short			= short.MaxValue;
				t_item_from.value_ushort		= ushort.MaxValue;
				t_item_from.value_int			= int.MaxValue;
				t_item_from.value_uint			= uint.MaxValue;
				t_item_from.value_long			= long.MaxValue;
				t_item_from.value_ulong			= ulong.MaxValue;
				t_item_from.value_char			= char.MaxValue;
				t_item_from.value_float			= float.MaxValue;
				t_item_from.value_double		= double.MaxValue;
				t_item_from.value_decimal		= decimal.MaxValue;
				t_item_from.value_list			= t_value_list;
				t_item_from.value_dictionary	= t_value_dictionary;
				t_item_from.value_array			= t_value_array;
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
			UnityEngine.Debug.Log("Test_26 : " + t_jsonstring);

			//チェック。
			if(Check(t_item_from,t_item_to) == false){
				UnityEngine.Debug.LogError("mismatch");
			}
		}
	}
}

