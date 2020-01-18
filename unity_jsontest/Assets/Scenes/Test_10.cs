﻿
/** テスト。
*/
#define FEE_JSON


/** Ignore。
*/
public class Test_10
{
	/** Item
	*/
	public class Item
	{
		/** ＪＳＯＮ文字列化しない。
		*/
		[Fee.JsonItem.Ignore]
		public int ignore_1;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_10 -----");

		{
			Item t_item_from = new Item();
			{
				//ignore_1
				t_item_from.ignore_1 = 999;
			};

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
			UnityEngine.Debug.Log("Test_10 : " + t_jsonstring);

			//チェック。
			{
			}
		}
	}
}

