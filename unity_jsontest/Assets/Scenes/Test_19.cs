
/** テスト。
*/
#define FEE_JSON


/** IDictionary(key = string)
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
			UnityEngine.Debug.Log("Test_19 : " + t_jsonstring);

			//チェック。
			{
				if(Test.NullSizeCheck_Dictionary(t_item_from.sorted_dictionary,t_item_to.sorted_dictionary) == true){
					foreach(string t_key in t_item_from.sorted_dictionary.Keys){
						if(t_item_from.sorted_dictionary[t_key] != t_item_to.sorted_dictionary[t_key]){
							UnityEngine.Debug.LogWarning("mismatch : " + t_key + " : " + t_item_from.sorted_dictionary[t_key] + " : " + t_item_to.sorted_dictionary[t_key]);
						}
					}
				}else{
					UnityEngine.Debug.LogWarning("mismatch");
				}

				if(Test.NullSizeCheck_Dictionary(t_item_from.sorted_list,t_item_to.sorted_list) == true){
					foreach(string t_key in t_item_from.sorted_list.Keys){
						if(t_item_from.sorted_list[t_key] != t_item_to.sorted_list[t_key]){
							UnityEngine.Debug.LogWarning("mismatch : " + t_key + " : " + t_item_from.sorted_list[t_key] + " : " + t_item_to.sorted_list[t_key]);
						}
					}
				}else{
					UnityEngine.Debug.LogWarning("mismatch");
				}
			}
		}
	}
}

