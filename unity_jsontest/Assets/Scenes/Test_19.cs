
/** テスト。
*/
#define FEE_JSON


/** Generic.IDictionary(key = string)
*/
public class Test_19
{
	/** Item
	*/
	public class Item
	{
		/** SortedDictionary
		*/
		public System.Collections.Generic.SortedDictionary<string,int> sorted_dictionary;

		/** SortedList
		*/
		public System.Collections.Generic.SortedList<string,int> sorted_list;
	};

	/** チェック。
	*/
	public static bool Check(Item a_from,Item a_to)
	{
		if(a_to == null){
			UnityEngine.Debug.LogWarning("mismatch : null");
			return false;
		}

		bool t_result = true;

		//sorted_dictionary
		t_result &= Test.Check_Dictionary("sorted_dictionary",a_from.sorted_dictionary,a_to.sorted_dictionary,(string a_a_llabel,in int a_a_from,in int a_a_to)=>{
			bool t_t_result = true;	
			t_t_result &= Test.Check_Int(a_a_llabel,a_a_from,a_a_to);
			return t_t_result;
		});

		//sorted_list
		t_result &= Test.Check_Dictionary("sorted_list",a_from.sorted_list,a_to.sorted_list,(string a_a_llabel,in int a_a_from,in int a_a_to)=>{
			bool t_t_result = true;	
			t_t_result &= Test.Check_Int(a_a_llabel,a_a_from,a_a_to);
			return t_t_result;
		});

		return t_result;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_19 -----");

		{
			Item t_item_from = new Item();
			{
				t_item_from.sorted_dictionary = new System.Collections.Generic.SortedDictionary<string,int>();
				t_item_from.sorted_dictionary.Add("value_1",1);
				t_item_from.sorted_dictionary.Add("value_2",2);
				t_item_from.sorted_dictionary.Add("value_3",3);

				t_item_from.sorted_list = new System.Collections.Generic.SortedList<string,int>();
				t_item_from.sorted_list.Add("value_1",1);
				t_item_from.sorted_list.Add("value_2",2);
				t_item_from.sorted_list.Add("value_3",3);
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
			UnityEngine.Debug.Log("Test_19 : " + t_jsonstring);

			//チェック。
			if(Check(t_item_from,t_item_to) == false){
				UnityEngine.Debug.LogError("mismatch");
			}
		}
	}
}

