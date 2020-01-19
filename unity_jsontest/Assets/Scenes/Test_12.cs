
/** テスト。
*/
#define FEE_JSON


/** ITEM_TYPE
*/
using ITEM_TYPE = Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<int>>>>>>>>>>>>;


/** 構造体ネスト。
*/
public class Test_12
{
	/** Item
	*/
	public struct Item<T>
	{
		public int value;
		public T item;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_12 -----");

		{
			ITEM_TYPE t_item_from = new ITEM_TYPE();
			{
				t_item_from.value = 0;
				t_item_from.item.value = 1;
				t_item_from.item.item.value = 2;
				t_item_from.item.item.item.value = 3;
				t_item_from.item.item.item.item.value = 4;
				t_item_from.item.item.item.item.item.value = 5;
				t_item_from.item.item.item.item.item.item.value = 6;
				t_item_from.item.item.item.item.item.item.item.value = 7;
				t_item_from.item.item.item.item.item.item.item.item.value = 8;
				t_item_from.item.item.item.item.item.item.item.item.item.value = 9;
				t_item_from.item.item.item.item.item.item.item.item.item.item.value = 10;
				t_item_from.item.item.item.item.item.item.item.item.item.item.item.value = -1;
				t_item_from.item.item.item.item.item.item.item.item.item.item.item.item = -1;
			}

			//オブジェクト ==> ＪＳＯＮＩＴＥＭ。
			#if(FEE_JSON)
			Fee.JsonItem.JsonItem t_jsonitem = Fee.JsonItem.Convert.ObjectToJsonItem<ITEM_TYPE>(t_item_from);
			#endif

			//ＪＳＯＮＩＴＥＭ ==> ＪＳＯＮ文字列。
			#if(FEE_JSON)
			string t_jsonstring = t_jsonitem.ConvertJsonString();
			#else
			string t_jsonstring = UnityEngine.JsonUtility.ToJson(t_item_from);
			#endif

			//ＪＳＯＮ文字列 ==> オブジェクト。
			#if(FEE_JSON)
			ITEM_TYPE t_item_to = Fee.JsonItem.Convert.JsonStringToObject<ITEM_TYPE>(t_jsonstring);
			#else
			ITEM_TYPE t_item_to = UnityEngine.JsonUtility.FromJson<ITEM_TYPE>(t_jsonstring);
			#endif

			//ログ。
			UnityEngine.Debug.Log("Test_12 : " + t_jsonstring);

			//チェック。
			{
				if(t_item_from.value != t_item_to.value){
					UnityEngine.Debug.LogWarning("mismatch : item0.value : "		+ t_item_from.value.ToString()																	+ " : " + t_item_to.value.ToString());
				}

				if(t_item_from.item.item.item.item.item.item.item.item.item.item.value != t_item_to.item.item.item.item.item.item.item.item.item.item.value){
					UnityEngine.Debug.LogWarning("mismatch : item10.value : "		+ t_item_from.item.item.item.item.item.item.item.item.item.item.value.ToString()				+ " : " + t_item_to.item.item.item.item.item.item.item.item.item.item.value.ToString());
				}

				if(t_item_from.item.item.item.item.item.item.item.item.item.item.item.value != t_item_to.item.item.item.item.item.item.item.item.item.item.item.value){
					UnityEngine.Debug.LogWarning("mismatch : item11.value : "		+ t_item_from.item.item.item.item.item.item.item.item.item.item.item.value.ToString()			+ " : " + t_item_to.item.item.item.item.item.item.item.item.item.item.item.value.ToString());
				}

				if(t_item_from.item.item.item.item.item.item.item.item.item.item.item.item != t_item_to.item.item.item.item.item.item.item.item.item.item.item.item){
					UnityEngine.Debug.LogWarning("mismatch : item11 : "				+ t_item_from.item.item.item.item.item.item.item.item.item.item.item.item.ToString()			+ " : " + t_item_to.item.item.item.item.item.item.item.item.item.item.item.item.ToString());
				}
			}
		}
	}
}

