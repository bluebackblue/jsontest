
/** テスト。
*/
#define FEE_JSON


/** ITEM_TYPE
*/
using ITEM_TYPE = System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>>>>>>>>>;


/** Listネスト。
*/
public class Test_13
{
	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_13 -----");

		{
			ITEM_TYPE t_item_from = new ITEM_TYPE();
			{
				t_item_from.Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>>>>>>>>());
				t_item_from[0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>>>>>>>());
				t_item_from[0][0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>>>>>>());
				t_item_from[0][0][0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>>>>>());
				t_item_from[0][0][0][0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>>>>());
				t_item_from[0][0][0][0][0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>>>());
				t_item_from[0][0][0][0][0][0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>>());
				t_item_from[0][0][0][0][0][0][0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>());
				t_item_from[0][0][0][0][0][0][0][0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>());
				t_item_from[0][0][0][0][0][0][0][0][0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<int>>());
				t_item_from[0][0][0][0][0][0][0][0][0][0].Add(new System.Collections.Generic.List<int>());
				t_item_from[0][0][0][0][0][0][0][0][0][0][0].Add(new int());
				t_item_from[0][0][0][0][0][0][0][0][0][0][0][0] = -1;
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
			UnityEngine.Debug.Log("Test_13 : " + t_jsonstring);

			//チェック。
			{
				if(t_item_from.Count != t_item_to.Count){
					UnityEngine.Debug.LogWarning("mismatch : item0.value : "		+ t_item_from.Count.ToString()												+ " : " + t_item_to.Count.ToString());
				}

				if(t_item_from[0][0][0][0][0][0][0][0][0][0].Count != t_item_to[0][0][0][0][0][0][0][0][0][0].Count){
					UnityEngine.Debug.LogWarning("mismatch : item10.value : "		+ t_item_from[0][0][0][0][0][0][0][0][0][0].Count.ToString()				+ " : " + t_item_to[0][0][0][0][0][0][0][0][0][0].Count.ToString());
				}

				if(t_item_from[0][0][0][0][0][0][0][0][0][0][0].Count != t_item_to[0][0][0][0][0][0][0][0][0][0][0].Count){
					UnityEngine.Debug.LogWarning("mismatch : item11.value : "		+ t_item_from[0][0][0][0][0][0][0][0][0][0][0].Count.ToString()				+ " : " + t_item_to[0][0][0][0][0][0][0][0][0][0][0].Count.ToString());
				}

				if(t_item_from[0][0][0][0][0][0][0][0][0][0][0][0] != t_item_to[0][0][0][0][0][0][0][0][0][0][0][0]){
					UnityEngine.Debug.LogWarning("mismatch : item11 : "				+ t_item_from[0][0][0][0][0][0][0][0][0][0][0][0].ToString()				+ " : " + t_item_to[0][0][0][0][0][0][0][0][0][0][0][0].ToString());
				}
			}
		}
	}
}

