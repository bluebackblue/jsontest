
/** テスト。
*/
#define FEE_JSON


/** null処理１。
*/
public class Test_16
{
	/** Item
	*/
	public class Item
	{
		/** value_class
		*/
		public Item value_class;

		/** value_string
		*/
		public string value_string;

		/** value_list
		*/
		public System.Collections.Generic.List<int> value_list;

		/** value_dictionary
		*/
		public System.Collections.Generic.Dictionary<string,int> value_dictionary;

		/** value_array
		*/
		public int[] value_array;
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

		t_result &= Test.Check_NullObject("value_class",		a_from.value_class,			a_to.value_class);
		t_result &= Test.Check_NullObject("value_string",		a_from.value_string,		a_to.value_string);
		t_result &= Test.Check_NullObject("value_list",			a_from.value_list,			a_to.value_list);
		t_result &= Test.Check_NullObject("value_dictionary",	a_from.value_dictionary,	a_to.value_dictionary);
		t_result &= Test.Check_NullObject("value_array",		a_from.value_array,			a_to.value_array);

		return t_result;
	}

	/** 更新。
	*/
	public static void Main(string a_label = nameof(Test_16))
	{
		UnityEngine.Debug.Log("----- " + a_label + " -----");

		try{
			Item t_item_from = new Item();
			{
				//value_class
				t_item_from.value_class = null;

				//value_string
				t_item_from.value_string = null;

				//value_list
				t_item_from.value_list = null;

				//value_dictionary
				t_item_from.value_dictionary = null;

				//value_array
				t_item_from.value_array = null;
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

