
/** テスト。
*/
#define FEE_JSON


/** NEST
*/
#if(UNITY_WEBGL)
#define NEST_6
#else
#define NEST_12
#endif


/** ITEM_TYPE
*/
#if(NEST_12)
using ITEM_TYPE = System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>>>>>>>>;
#elif(NEST_7)
using ITEM_TYPE = System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>>>;
#elif(NEST_6)
using ITEM_TYPE = System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>>;
#elif(NEST_5)
using ITEM_TYPE = System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>;
#endif

/** Generic.Dictionary(key = string)ネスト。
*/
public class Test_14
{
	/** チェック。
	*/
	public static bool Check(ITEM_TYPE a_from,ITEM_TYPE a_to)
	{
		if(a_to == null){
			UnityEngine.Debug.LogWarning("mismatch : null");
			return false;
		}

		bool t_result = true;

		#if(NEST_12)
		t_result &= Test.Check_Int("0.count",	a_from.Count,																														a_to.Count);
		t_result &= Test.Check_Int("1.count",	a_from["list_0"].Count,																												a_to["list_0"].Count);
		t_result &= Test.Check_Int("2.count",	a_from["list_0"]["list_1"].Count,																									a_to["list_0"]["list_1"].Count);
		t_result &= Test.Check_Int("3.count",	a_from["list_0"]["list_1"]["list_2"].Count,																							a_to["list_0"]["list_1"]["list_2"].Count);
		t_result &= Test.Check_Int("4.count",	a_from["list_0"]["list_1"]["list_2"]["list_3"].Count,																				a_to["list_0"]["list_1"]["list_2"]["list_3"].Count);
		t_result &= Test.Check_Int("5.count",	a_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"].Count,																		a_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"].Count);
		t_result &= Test.Check_Int("6.count",	a_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"].Count,															a_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"].Count);
		t_result &= Test.Check_Int("7.count",	a_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"].Count,													a_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"].Count);
		t_result &= Test.Check_Int("8.count",	a_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"].Count,										a_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"].Count);
		t_result &= Test.Check_Int("9.count",	a_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"].Count,								a_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"].Count);
		t_result &= Test.Check_Int("10.count",	a_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"].Count,					a_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"].Count);
		t_result &= Test.Check_Int("11.count",	a_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"]["list_10"].Count,		a_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"]["list_10"].Count);
		t_result &= Test.Check_Int("11.value",	a_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"]["list_10"]["value"],		a_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["list_6"]["list_7"]["list_8"]["list_9"]["list_10"]["value"]);
		#elif(NEST_7)
		t_result &= Test.Check_Int("0.count",	a_from.Count,																														a_to.Count);
		t_result &= Test.Check_Int("1.count",	a_from["list_0"].Count,																												a_to["list_0"].Count);
		t_result &= Test.Check_Int("2.count",	a_from["list_0"]["list_1"].Count,																									a_to["list_0"]["list_1"].Count);
		t_result &= Test.Check_Int("3.count",	a_from["list_0"]["list_1"]["list_2"].Count,																							a_to["list_0"]["list_1"]["list_2"].Count);
		t_result &= Test.Check_Int("4.count",	a_from["list_0"]["list_1"]["list_2"]["list_3"].Count,																				a_to["list_0"]["list_1"]["list_2"]["list_3"].Count);
		t_result &= Test.Check_Int("5.count",	a_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"].Count,																		a_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"].Count);
		t_result &= Test.Check_Int("6.count",	a_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"].Count,															a_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"].Count);
		t_result &= Test.Check_Int("7.count",	a_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["value"],														a_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"]["value"]);
		#elif(NEST_6)
		t_result &= Test.Check_Int("0.count",	a_from.Count,																														a_to.Count);
		t_result &= Test.Check_Int("1.count",	a_from["list_0"].Count,																												a_to["list_0"].Count);
		t_result &= Test.Check_Int("2.count",	a_from["list_0"]["list_1"].Count,																									a_to["list_0"]["list_1"].Count);
		t_result &= Test.Check_Int("3.count",	a_from["list_0"]["list_1"]["list_2"].Count,																							a_to["list_0"]["list_1"]["list_2"].Count);
		t_result &= Test.Check_Int("4.count",	a_from["list_0"]["list_1"]["list_2"]["list_3"].Count,																				a_to["list_0"]["list_1"]["list_2"]["list_3"].Count);
		t_result &= Test.Check_Int("5.count",	a_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"].Count,																		a_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"].Count);
		t_result &= Test.Check_Int("6.count",	a_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["value"],																	a_to["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["value"]);
		#elif(NEST_5)
		t_result &= Test.Check_Int("0.count",	a_from.Count,																														a_to.Count);
		t_result &= Test.Check_Int("1.count",	a_from["list_0"].Count,																												a_to["list_0"].Count);
		t_result &= Test.Check_Int("2.count",	a_from["list_0"]["list_1"].Count,																									a_to["list_0"]["list_1"].Count);
		t_result &= Test.Check_Int("3.count",	a_from["list_0"]["list_1"]["list_2"].Count,																							a_to["list_0"]["list_1"]["list_2"].Count);
		t_result &= Test.Check_Int("4.count",	a_from["list_0"]["list_1"]["list_2"]["list_3"].Count,																				a_to["list_0"]["list_1"]["list_2"]["list_3"].Count);
		t_result &= Test.Check_Int("5.count",	a_from["list_0"]["list_1"]["list_2"]["list_3"]["value"],																			a_to["list_0"]["list_1"]["list_2"]["list_3"]["value"]);
		#endif

		return t_result;
	}

	/** 更新。
	*/
	public static void Main(string a_label = nameof(Test_14))
	{
		UnityEngine.Debug.Log("----- " + a_label + " -----");

		try{
			ITEM_TYPE t_item_from = new ITEM_TYPE();
			{
				#if(NEST_12)
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
				#elif(NEST_7)
				t_item_from.Add("list_0",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>>());
				t_item_from["list_0"].Add("list_1",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>());
				t_item_from["list_0"]["list_1"].Add("list_2",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>());
				t_item_from["list_0"]["list_1"]["list_2"].Add("list_3",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>());
				t_item_from["list_0"]["list_1"]["list_2"]["list_3"].Add("list_4",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>());
				t_item_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"].Add("list_5",new System.Collections.Generic.Dictionary<string,int>());
				t_item_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"]["list_5"].Add("value",-1);
				#elif(NEST_6)
				t_item_from.Add("list_0",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>>());
				t_item_from["list_0"].Add("list_1",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>());
				t_item_from["list_0"]["list_1"].Add("list_2",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>());
				t_item_from["list_0"]["list_1"]["list_2"].Add("list_3",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>());
				t_item_from["list_0"]["list_1"]["list_2"]["list_3"].Add("list_4",new System.Collections.Generic.Dictionary<string,int>());
				t_item_from["list_0"]["list_1"]["list_2"]["list_3"]["list_4"].Add("value",-1);
				#elif(NEST_5)
				t_item_from.Add("list_0",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>>());
				t_item_from["list_0"].Add("list_1",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>>());
				t_item_from["list_0"]["list_1"].Add("list_2",new System.Collections.Generic.Dictionary<string,System.Collections.Generic.Dictionary<string,int>>());
				t_item_from["list_0"]["list_1"]["list_2"].Add("list_3",new System.Collections.Generic.Dictionary<string,int>());
				t_item_from["list_0"]["list_1"]["list_2"]["list_3"].Add("value",-1);
				#endif
			}

			//オブジェクト ==> ＪＳＯＮＩＴＥＭ。
			#if(FEE_JSON)
			Fee.JsonItem.JsonItem t_jsonitem = Fee.JsonItem.Convert.ObjectToJsonItem<ITEM_TYPE>(t_item_from);
			#endif

			//ＪＳＯＮＩＴＥＭ ==> ＪＳＯＮ文字列。
			#if(FEE_JSON)
			string t_jsonstring = t_jsonitem.ConvertToJsonString();
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
			UnityEngine.Debug.Log(a_label + " : " + t_jsonstring);

			//チェック。
			if(Check(t_item_from,t_item_to) == false){
				UnityEngine.Debug.LogError("mismatch");
			}
		}catch(System.Exception t_exception){
			UnityEngine.Debug.LogError(a_label + " : exception : " + t_exception.Message);
		}
	}
}

