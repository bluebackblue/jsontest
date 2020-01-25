
/** テスト。
*/
#define FEE_JSON


/** NEST
*/
#define NEST_7


/** ITEM_TYPE
*/
#if(NEST_12)
using ITEM_TYPE = System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>>>>>>>>>;
#elif(NEST_7)
using ITEM_TYPE = System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>>>>;
#elif(NEST_6)
using ITEM_TYPE = System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>>>;
#elif(NEST_5)
using ITEM_TYPE = System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>>;
#endif

/** Generic.Listネスト。
*/
public class Test_13
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
		t_result &= Test.Check_Int("0.count",	a_from.Count,									a_to.Count);
		t_result &= Test.Check_Int("1.count",	a_from[0].Count,								a_to[0].Count);
		t_result &= Test.Check_Int("2.count",	a_from[0][0].Count,								a_to[0][0].Count);
		t_result &= Test.Check_Int("3.count",	a_from[0][0][0].Count,							a_to[0][0][0].Count);
		t_result &= Test.Check_Int("4.count",	a_from[0][0][0][0].Count,						a_to[0][0][0][0].Count);
		t_result &= Test.Check_Int("5.count",	a_from[0][0][0][0][0].Count,					a_to[0][0][0][0][0].Count);
		t_result &= Test.Check_Int("6.count",	a_from[0][0][0][0][0][0].Count,					a_to[0][0][0][0][0][0].Count);
		t_result &= Test.Check_Int("7.count",	a_from[0][0][0][0][0][0][0].Count,				a_to[0][0][0][0][0][0][0].Count);
		t_result &= Test.Check_Int("8.count",	a_from[0][0][0][0][0][0][0][0].Count,			a_to[0][0][0][0][0][0][0][0].Count);
		t_result &= Test.Check_Int("9.count",	a_from[0][0][0][0][0][0][0][0][0].Count,		a_to[0][0][0][0][0][0][0][0][0].Count);
		t_result &= Test.Check_Int("10.count",	a_from[0][0][0][0][0][0][0][0][0][0].Count,		a_to[0][0][0][0][0][0][0][0][0][0].Count);
		t_result &= Test.Check_Int("11.count",	a_from[0][0][0][0][0][0][0][0][0][0][0].Count,	a_to[0][0][0][0][0][0][0][0][0][0][0].Count);
		t_result &= Test.Check_Int("11.value",	a_from[0][0][0][0][0][0][0][0][0][0][0][0],		a_to[0][0][0][0][0][0][0][0][0][0][0][0]);
		#elif(NEST_7)
		t_result &= Test.Check_Int("0.count",	a_from.Count,									a_to.Count);
		t_result &= Test.Check_Int("1.count",	a_from[0].Count,								a_to[0].Count);
		t_result &= Test.Check_Int("2.count",	a_from[0][0].Count,								a_to[0][0].Count);
		t_result &= Test.Check_Int("3.count",	a_from[0][0][0].Count,							a_to[0][0][0].Count);
		t_result &= Test.Check_Int("4.count",	a_from[0][0][0][0].Count,						a_to[0][0][0][0].Count);
		t_result &= Test.Check_Int("5.count",	a_from[0][0][0][0][0].Count,					a_to[0][0][0][0][0].Count);
		t_result &= Test.Check_Int("6.count",	a_from[0][0][0][0][0][0].Count,					a_to[0][0][0][0][0][0].Count);
		t_result &= Test.Check_Int("6.value",	a_from[0][0][0][0][0][0][0],					a_to[0][0][0][0][0][0][0]);
		#elif(NEST_6)
		t_result &= Test.Check_Int("0.count",	a_from.Count,									a_to.Count);
		t_result &= Test.Check_Int("1.count",	a_from[0].Count,								a_to[0].Count);
		t_result &= Test.Check_Int("2.count",	a_from[0][0].Count,								a_to[0][0].Count);
		t_result &= Test.Check_Int("3.count",	a_from[0][0][0].Count,							a_to[0][0][0].Count);
		t_result &= Test.Check_Int("4.count",	a_from[0][0][0][0].Count,						a_to[0][0][0][0].Count);
		t_result &= Test.Check_Int("5.count",	a_from[0][0][0][0][0].Count,					a_to[0][0][0][0][0].Count);
		t_result &= Test.Check_Int("5.value",	a_from[0][0][0][0][0][0],						a_to[0][0][0][0][0][0]);
		#elif(NEST_5)
		t_result &= Test.Check_Int("0.count",	a_from.Count,									a_to.Count);
		t_result &= Test.Check_Int("1.count",	a_from[0].Count,								a_to[0].Count);
		t_result &= Test.Check_Int("2.count",	a_from[0][0].Count,								a_to[0][0].Count);
		t_result &= Test.Check_Int("3.count",	a_from[0][0][0].Count,							a_to[0][0][0].Count);
		t_result &= Test.Check_Int("4.count",	a_from[0][0][0][0].Count,						a_to[0][0][0][0].Count);
		t_result &= Test.Check_Int("4.value",	a_from[0][0][0][0][0],							a_to[0][0][0][0][0]);
		#endif

		return t_result;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_13 -----");

		{
			ITEM_TYPE t_item_from = new ITEM_TYPE();
			{
				#if(NEST_12)
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
				#elif(NEST_7)
				t_item_from.Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>>>());
				t_item_from[0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>>());
				t_item_from[0][0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>());
				t_item_from[0][0][0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>());
				t_item_from[0][0][0][0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<int>>());
				t_item_from[0][0][0][0][0].Add(new System.Collections.Generic.List<int>());
				t_item_from[0][0][0][0][0][0].Add(new int());
				t_item_from[0][0][0][0][0][0][0] = -1;
				#elif(NEST_6)
				t_item_from.Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>>());
				t_item_from[0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>());
				t_item_from[0][0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>());
				t_item_from[0][0][0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<int>>());
				t_item_from[0][0][0][0].Add(new System.Collections.Generic.List<int>());
				t_item_from[0][0][0][0][0].Add(new int());
				t_item_from[0][0][0][0][0][0] = -1;
				#elif(NEST_5)
				t_item_from.Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>>());
				t_item_from[0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<int>>>());
				t_item_from[0][0].Add(new System.Collections.Generic.List<System.Collections.Generic.List<int>>());
				t_item_from[0][0][0].Add(new System.Collections.Generic.List<int>());
				t_item_from[0][0][0][0].Add(new int());
				t_item_from[0][0][0][0][0] = -1;
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
			UnityEngine.Debug.Log("Test_13 : " + t_jsonstring);

			//チェック。
			if(Check(t_item_from,t_item_to) == false){
				UnityEngine.Debug.LogError("mismatch");
			}
		}
	}
}

