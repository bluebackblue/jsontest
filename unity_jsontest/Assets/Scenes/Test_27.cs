
/** テスト。
*/
#define FEE_JSON


/** Collections.ArrayList。
*/
public class Test_27
{
	/** Type
	*/
	public enum Type : byte
	{
		TypeA = 100,
	}

	/** Item_Value
	*/
	public class Item_Value
	{
		public string value_string;
		public bool value_bool;
		public Item_Value(string a_value_string,bool a_value_bool)
		{
			this.value_string = a_value_string;
			this.value_bool = a_value_bool;
		}
	}

	/** Item
	*/
	public class Item
	{
		public System.Collections.ArrayList arraylist;
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

		/* TODO:
		string t_re_convert = Fee.JsonItem.Convert.ObjectToJsonString(a_to);
		UnityEngine.Debug.Log(t_re_convert);
		*/

		return t_result;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_27 -----");

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

				t_item_from.arraylist = new System.Collections.ArrayList();
				t_item_from.arraylist.Add(new Item_Value("value_4",true));
				t_item_from.arraylist.Add(100);
				t_item_from.arraylist.Add("value_2");
				t_item_from.arraylist.Add(Type.TypeA);
				t_item_from.arraylist.Add(t_value_list);
				t_item_from.arraylist.Add(t_value_dictionary);
				t_item_from.arraylist.Add(t_value_array);
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
			UnityEngine.Debug.Log("Test_27 : " + t_jsonstring);

			//チェック。
			if(Check(t_item_from,t_item_to) == false){
				UnityEngine.Debug.LogError("mismatch");
			}
		}
	}
}

