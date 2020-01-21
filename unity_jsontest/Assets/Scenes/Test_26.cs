
/** テスト。
*/
#define FEE_JSON


/** TODO。
*/
public class Test_26
{
	/** Item
	*/
	public class Item
	{
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
			UnityEngine.Debug.Log("Test_05 : " + t_jsonstring);

			//チェック。
			if(Check(t_item_from,t_item_to) == false){
				UnityEngine.Debug.LogError("mismatch");
			}
		}
	}
}

