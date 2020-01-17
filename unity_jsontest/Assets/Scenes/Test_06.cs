
/** テスト。
*/
#define FEE_JSON


/** 構造体。
*/
public class Test_06
{
	/** Item
	*/
	public struct Item
	{
		public int value;
	};

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_06 -----");

		//構造体。
		{
			Item t_item_from = new Item();
			{
				t_item_from.value = 1;
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
			UnityEngine.Debug.Log("Test_06 : " + t_jsonstring);

			//チェック。
			{
				if(t_item_from.value != t_item_to.value){
					UnityEngine.Debug.LogWarning("value_type : " + t_item_from.value.ToString() + " : " + t_item_to.value.ToString());
				}
			}
		}

	}
}

