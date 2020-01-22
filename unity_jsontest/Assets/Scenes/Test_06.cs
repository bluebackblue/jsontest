
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

	/** チェック。
	*/
	public static bool Check(in Item a_from,in Item a_to)
	{
		/*
		if(a_to == null){
			UnityEngine.Debug.LogWarning("mismatch : null");
			return;
		}
		*/
		bool t_result = true;

		t_result &= Test.Check_Int("value",a_from.value,a_to.value);

		return t_result;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_06 -----");

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
			UnityEngine.Debug.Log("Test_06 : " + t_jsonstring);

			//チェック。
			if(Check(t_item_from,t_item_to) == false){
				UnityEngine.Debug.LogError("mismatch");
			}
		}
	}
}

