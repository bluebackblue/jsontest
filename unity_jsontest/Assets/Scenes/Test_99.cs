
/** テスト。
*/
#define FEE_JSON


/** テストコード。
*/
public class Test_99
{
	/** Item
	*/
	public class Item
	{
		public System.Collections.Generic.Dictionary<System.Object,System.Object> dictionary;
	};

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
		UnityEngine.Debug.Log("----- Test_99 -----");

		{
			Item t_item_from = new Item();
			{
				t_item_from.dictionary = new System.Collections.Generic.Dictionary<System.Object,System.Object>();
				t_item_from.dictionary.Add(1,10);
				t_item_from.dictionary.Add(2,20);
				t_item_from.dictionary.Add(3,30);
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
			UnityEngine.Debug.Log("Test_99 : " + t_jsonstring);

			//チェック。
			if(Check(t_item_from,t_item_to) == false){
				UnityEngine.Debug.LogError("mismatch");
			}
		}
	}
}

