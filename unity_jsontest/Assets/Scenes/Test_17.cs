
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
			UnityEngine.Debug.Log("Test_17 : " + t_jsonstring);

			//チェック。
			{
				if(Test.NullCheckList(t_item_from.value_list,t_item_to.value_list) == true){
					for(int ii=0;ii<t_item_from.value_list.Count;ii++){
						if(t_item_from.value_list[ii] != t_item_to.value_list[ii]){
							UnityEngine.Debug.LogWarning(ii.ToString() + " : " + t_item_from.value_list[ii].ToString() + " : " + t_item_to.value_list[ii].ToString());
						}
					}
				}else{
					UnityEngine.Debug.LogWarning("null");
				}

				if(Test.NullCheckDictionary(t_item_from.value_dictionary,t_item_to.value_dictionary) == true){
					foreach(string t_key in t_item_from.value_dictionary.Keys){
						if(t_item_from.value_dictionary[t_key] != t_item_to.value_dictionary[t_key]){
							UnityEngine.Debug.LogWarning(t_key + " : " + t_item_from.value_dictionary[t_key].ToString() + " : " + t_item_to.value_dictionary[t_key].ToString());
						}
					}
				}else{
					UnityEngine.Debug.LogWarning("null");
				}

				if(Test.NullCheckArray(t_item_from.value_array,t_item_to.value_array) == true){
					for(int ii=0;ii<t_item_from.value_array.Length;ii++){
						if(t_item_from.value_array[ii] != t_item_to.value_array[ii]){
							UnityEngine.Debug.LogWarning(ii.ToString() + " : " + t_item_from.value_array[ii] + " : " + t_item_to.value_array[ii]);
						}
					}
				}else{
					UnityEngine.Debug.LogWarning("null");
				}
			}
		}
	}
}

