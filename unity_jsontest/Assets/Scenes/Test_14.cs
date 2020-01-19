
/** テスト。
*/
#define FEE_JSON


/** ITEM_TYPE
*/
using ITEM_TYPE = System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>>>>>>>>;


/** Dictionaryネスト。
*/
public class Test_14
{
	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_14 -----");

		{
			ITEM_TYPE t_item_from = new ITEM_TYPE();
			{
				t_item_from.Add("list_0",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>>>>>>>());
				t_item_from["list_0"].Add("list_1",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>>>>>>());
				t_item_from["list_0"]["list_1"].Add("list_2",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>>>>>());
				t_item_from["list_0"]["list_1"]["list_2"].Add("list_3",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>>>>());
				t_item_from["list_0"]["list_1"]["list_2"]["list_3"].Add("list_4",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>>>());
				t_item_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"].Add("list_5",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>>());
				t_item_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"].Add("list_6",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>());
				t_item_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"].Add("list_7",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>());
				t_item_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"].Add("list_8",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>());
				t_item_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"].Add("list_9",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>());
				t_item_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"].Add("list_10",new System.Collections.Generic.Dictionary<string,int>());
				t_item_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"]["list_10"].Add("value",-1);
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
			UnityEngine.Debug.Log("Test_14 : " + t_jsonstring);

			//チェック。
			{
				if(t_item_from.Count != t_item_to.Count){
					UnityEngine.Debug.LogWarning("mismatch : item0.value : "		+ t_item_from.Count.ToString()																																+ " : " + t_item_to.Count.ToString());
				}

				if(t_item_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"].Count != t_item_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"].Count){
					UnityEngine.Debug.LogWarning("mismatch : item10.value : "		+ t_item_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"].Count.ToString()							+ " : " + t_item_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"].Count.ToString());
				}

				if(t_item_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"]["list_10"].Count != t_item_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"]["list_10"].Count){
					UnityEngine.Debug.LogWarning("mismatch : item11.value : "		+ t_item_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"]["list_10"].Count.ToString()				+ " : " + t_item_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"]["list_10"].Count.ToString());
				}

				if(t_item_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"]["list_10"]["value"] != t_item_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"]["list_10"]["value"]){
					UnityEngine.Debug.LogWarning("mismatch : item11 : "			+ t_item_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"]["list_10"]["value"].ToString()				+ " : " + t_item_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"]["list_10"]["value"].ToString());
				}
			}
		}
	}
}

