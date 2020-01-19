
/** テスト。
*/
#define FEE_JSON


/** HashSet。
*/
public class Test_22
{
	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_22 -----");

		{
			System.Collections.Generic.HashSet<int> t_item_from = new System.Collections.Generic.HashSet<int>();
			{
				t_item_from.Add(1);
				t_item_from.Add(2);
				t_item_from.Add(3);
			}

			//オブジェクト ==> ＪＳＯＮＩＴＥＭ。
			#if(FEE_JSON)
			Fee.JsonItem.JsonItem t_jsonitem = Fee.JsonItem.Convert.ObjectToJsonItem<System.Collections.Generic.HashSet<int>>(t_item_from);
			#endif

			//ＪＳＯＮＩＴＥＭ ==> ＪＳＯＮ文字列。
			#if(FEE_JSON)
			string t_jsonstring = t_jsonitem.ConvertJsonString();
			#else
			string t_jsonstring = UnityEngine.JsonUtility.ToJson(t_item_from);
			#endif

			//ＪＳＯＮ文字列 ==> オブジェクト。
			#if(FEE_JSON)
			System.Collections.Generic.HashSet<int> t_item_to = Fee.JsonItem.Convert.JsonStringToObject<System.Collections.Generic.HashSet<int>>(t_jsonstring);
			#else
			System.Collections.Generic.HashSet<int> t_item_to = UnityEngine.JsonUtility.FromJson<System.Collections.Generic.HashSet<int>>(t_jsonstring);
			#endif
		
			//ログ。
			UnityEngine.Debug.Log("Test_22 : " + t_jsonstring);

			//チェック。
			{
				if(Test.NullSizeCheck_HashSet(t_item_from,t_item_to) == true){
					//順不同。
				}else{
					UnityEngine.Debug.LogWarning("mismatch");
				}
			}
		}
	}
}

