
/** テスト。
*/
#define FEE_JSON


/** リスト。
*/
public class Test_08
{
	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_08 -----");

		//配列。
		{
			System.Collections.Generic.List<int> t_item_from = new System.Collections.Generic.List<int>();
			{
				t_item_from.Add(1);
				t_item_from.Add(2);
				t_item_from.Add(3);
			}

			//オブジェクト ==> ＪＳＯＮＩＴＥＭ。
			#if(FEE_JSON)
			Fee.JsonItem.JsonItem t_jsonitem = Fee.JsonItem.Convert.ObjectToJsonItem<System.Collections.Generic.List<int>>(t_item_from);
			#endif

			//ＪＳＯＮＩＴＥＭ ==> ＪＳＯＮ文字列。
			#if(FEE_JSON)
			string t_jsonstring = t_jsonitem.ConvertJsonString();
			#else
			string t_jsonstring = UnityEngine.JsonUtility.ToJson(t_item_from);
			#endif

			//ＪＳＯＮ文字列 ==> オブジェクト。
			#if(FEE_JSON)
			System.Collections.Generic.List<int> t_item_to = Fee.JsonItem.Convert.JsonStringToObject<System.Collections.Generic.List<int>>(t_jsonstring);
			#else
			System.Collections.Generic.List<int> t_item_to = UnityEngine.JsonUtility.FromJson<System.Collections.Generic.List<int>>(t_jsonstring);
			#endif
		
			//ログ。
			UnityEngine.Debug.Log("Test_08 : " + t_jsonstring);

			//チェック。
			{
				if(Test.NullCheckList(t_item_from,t_item_to) == true){
					for(int ii=0;ii<t_item_from.Count;ii++){
						if(t_item_from[ii] != t_item_to[ii]){
							UnityEngine.Debug.LogWarning(ii.ToString() + " : " + t_item_from[ii] + " : " + t_item_to[ii]);
						}
					}
				}else{
					UnityEngine.Debug.LogWarning("null");
				}
			}
		}
	}
}

