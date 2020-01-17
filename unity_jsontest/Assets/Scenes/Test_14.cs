
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
				t_item_from.Add("list0",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>>>>>>>());
				t_item_from["list0"].Add("list1",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>>>>>>());
				t_item_from["list0"]["list1"].Add("list2",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>>>>>());
				t_item_from["list0"]["list1"]["list2"].Add("list3",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>>>>());
				t_item_from["list0"]["list1"]["list2"]["list3"].Add("list4",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>>>());
				t_item_from["list0"]["list1"]["list2"]["list3"]["list4"].Add("list5",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>>());
				t_item_from["list0"]["list1"]["list2"]["list3"]["list4"]["list5"].Add("list6",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>());
				t_item_from["list0"]["list1"]["list2"]["list3"]["list4"]["list5"]["list6"].Add("list7",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>());
				t_item_from["list0"]["list1"]["list2"]["list3"]["list4"]["list5"]["list6"]["list7"].Add("list8",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>());
				t_item_from["list0"]["list1"]["list2"]["list3"]["list4"]["list5"]["list6"]["list7"]["list8"].Add("list9",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>());
				t_item_from["list0"]["list1"]["list2"]["list3"]["list4"]["list5"]["list6"]["list7"]["list8"]["list9"].Add("list10",new System.Collections.Generic.Dictionary<string,int>());
				t_item_from["list0"]["list1"]["list2"]["list3"]["list4"]["list5"]["list6"]["list7"]["list8"]["list9"]["list10"].Add("value",-1);
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
					UnityEngine.Debug.LogWarning("item0.value : "		+ t_item_from.Count.ToString()				+ " : " + t_item_to.Count.ToString());
				}

				if(t_item_from["list0"]["list1"]["list2"]["list3"]["list4"]["list5"]["list6"]["list7"]["list8"]["list9"].Count != t_item_to["list0"]["list1"]["list2"]["list3"]["list4"]["list5"]["list6"]["list7"]["list8"]["list9"].Count){
					UnityEngine.Debug.LogWarning("item10.value : "		+ t_item_from["list0"]["list1"]["list2"]["list3"]["list4"]["list5"]["list6"]["list7"]["list8"]["list9"].Count.ToString()				+ " : " + t_item_to["list0"]["list1"]["list2"]["list3"]["list4"]["list5"]["list6"]["list7"]["list8"]["list9"].Count.ToString());
				}

				if(t_item_from["list0"]["list1"]["list2"]["list3"]["list4"]["list5"]["list6"]["list7"]["list8"]["list9"]["list10"].Count != t_item_to["list0"]["list1"]["list2"]["list3"]["list4"]["list5"]["list6"]["list7"]["list8"]["list9"]["list10"].Count){
					UnityEngine.Debug.LogWarning("item11.value : "		+ t_item_from["list0"]["list1"]["list2"]["list3"]["list4"]["list5"]["list6"]["list7"]["list8"]["list9"]["list10"].Count.ToString()				+ " : " + t_item_to["list0"]["list1"]["list2"]["list3"]["list4"]["list5"]["list6"]["list7"]["list8"]["list9"]["list10"].Count.ToString());
				}

				if(t_item_from["list0"]["list1"]["list2"]["list3"]["list4"]["list5"]["list6"]["list7"]["list8"]["list9"]["list10"]["value"] != t_item_to["list0"]["list1"]["list2"]["list3"]["list4"]["list5"]["list6"]["list7"]["list8"]["list9"]["list10"]["value"]){
					UnityEngine.Debug.LogWarning("item11 : "		+ t_item_from["list0"]["list1"]["list2"]["list3"]["list4"]["list5"]["list6"]["list7"]["list8"]["list9"]["list10"]["value"].ToString()				+ " : " + t_item_to["list0"]["list1"]["list2"]["list3"]["list4"]["list5"]["list6"]["list7"]["list8"]["list9"]["list10"]["value"].ToString());
				}
			}
		}
	}
}

