
/** テスト。
*/
#define FEE_JSON


/** Dictionary
*/
public class Test_07
{
	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_07 -----");

		{
			System.Collections.Generic.Dictionary<string,int> t_item_from = new System.Collections.Generic.Dictionary<string,int>();
			{
				t_item_from.Add("value_1",1);
				t_item_from.Add("value_2",2);
				t_item_from.Add("value_3",3);
			}

			//オブジェクト ==> ＪＳＯＮＩＴＥＭ。
			#if(FEE_JSON)
			Fee.JsonItem.JsonItem t_jsonitem = Fee.JsonItem.Convert.ObjectToJsonItem<System.Collections.Generic.Dictionary<string,int>>(t_item_from);
			#endif

			//ＪＳＯＮＩＴＥＭ ==> ＪＳＯＮ文字列。
			#if(FEE_JSON)
			string t_jsonstring = t_jsonitem.ConvertJsonString();
			#else
			string t_jsonstring = UnityEngine.JsonUtility.ToJson(t_item_from);
			#endif

			//ＪＳＯＮ文字列 ==> オブジェクト。
			#if(FEE_JSON)
			System.Collections.Generic.Dictionary<string,int> t_item_to = Fee.JsonItem.Convert.JsonStringToObject<System.Collections.Generic.Dictionary<string,int>>(t_jsonstring);
			#else
			System.Collections.Generic.Dictionary<string,int> t_item_to = UnityEngine.JsonUtility.FromJson<System.Collections.Generic.Dictionary<string,int>>(t_jsonstring);
			#endif
		
			//ログ。
			UnityEngine.Debug.Log("Test_07 : 3 : " + t_jsonstring);

			//チェック。
			{
				if(Test.NullCheckDictionary(t_item_from,t_item_to) == true){
					foreach(string t_key in t_item_from.Keys){
						if(t_item_from[t_key] != t_item_to[t_key]){
							UnityEngine.Debug.LogWarning(t_key + " : " + t_item_from[t_key] + " : " + t_item_to[t_key]);
						}
					}
				}else{
					UnityEngine.Debug.LogWarning("null");
				}
			}
		}
	}
}

