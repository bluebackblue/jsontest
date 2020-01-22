
/** テスト。
*/
#define FEE_JSON


/** null処理２。
*/
public class Test_17
{
	/** Item
	*/
	public class Item
	{
		/** value_list
		*/
		public System.Collections.Generic.List<Item> value_list;

		/** value_dictionary
		*/
		public System.Collections.Generic.Dictionary<string,Item> value_dictionary;

		/** value_array
		*/
		public Item[] value_array;
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

		//value_list
		t_result &= Test.Check_Enumerator("value_list",a_from.value_list,a_to.value_list,(string a_a_label,in Item a_a_from,in Item a_a_to)=>{
			bool t_t_result = true;
			t_t_result &= Test.Check_NullObject(a_a_label,a_a_from,a_a_to);
			return t_t_result;
		});

		//value_dictionary
		t_result &= Test.Check_Dictionary("value_dictionary",a_from.value_dictionary,a_to.value_dictionary,(string a_a_label,in Item a_a_from,in Item a_a_to)=>{
			bool t_t_result = true;
			t_t_result &= Test.Check_NullObject(a_a_label,a_a_from,a_a_to);
			return t_t_result;
		});

		//value_array
		t_result &= Test.Check_Enumerator("value_array",a_from.value_array,a_to.value_array,(string a_a_label,in Item a_a_from,in Item a_a_to)=>{
			bool t_t_result = true;
			t_t_result &= Test.Check_NullObject(a_a_label,a_a_from,a_a_to);
			return t_t_result;
		});

		return t_result;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_17 -----");

		{
			Item t_item_from = new Item();
			{
				//value_list
				t_item_from.value_list = new System.Collections.Generic.List<Item>();
				t_item_from.value_list.Add(null);
				t_item_from.value_list.Add(null);
				t_item_from.value_list.Add(null);

				//value_dictionary
				t_item_from.value_dictionary = new System.Collections.Generic.Dictionary<string,Item>();
				t_item_from.value_dictionary.Add("value_1",null);
				t_item_from.value_dictionary.Add("value_2",null);
				t_item_from.value_dictionary.Add("value_3",null);

				//value_array
				t_item_from.value_array = new Item[3];
				t_item_from.value_array[0] = null;
				t_item_from.value_array[1] = null;
				t_item_from.value_array[2] = null;
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
			UnityEngine.Debug.Log("Test_17 : " + t_jsonstring);

			//チェック。
			if(Check(t_item_from,t_item_to) == false){
				UnityEngine.Debug.LogError("mismatch");
			}
		}
	}
}

