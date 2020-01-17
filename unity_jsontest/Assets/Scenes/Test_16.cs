
/** テスト。
*/
#define FEE_JSON


/** ＮＵＬＬ１。
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
		public Item[] value_array;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_16 -----");

		{
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
			UnityEngine.Debug.Log("Test_16 : " + t_jsonstring);

			//チェック。
			{
				if(t_item_to.value_class != null){
					UnityEngine.Debug.LogWarning("value_class : " + t_item_to.value_class.ToString());
				}

				if(t_item_to.value_string != null){
					UnityEngine.Debug.LogWarning("value_string : " + t_item_to.value_list.ToString());
				}

				if(t_item_to.value_list != null){
					UnityEngine.Debug.LogWarning("value_list : " + t_item_to.value_list.ToString());
				}

				if(t_item_to.value_dictionary != null){
					UnityEngine.Debug.LogWarning("value_dictionary : " + t_item_to.value_dictionary.ToString());
				}

				if(t_item_to.value_array != null){
					UnityEngine.Debug.LogWarning("value_array : " + t_item_to.value_array.ToString());
				}
			}
		}
	}
}

