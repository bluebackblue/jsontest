﻿
/** テスト。
*/
#define FEE_JSON


/** LinkedList。
*/
public class Test_21
{
	/** チェック。
	*/
	public static bool Check(System.Collections.Generic.LinkedList<int> a_from,System.Collections.Generic.LinkedList<int> a_to)
	{
		if(a_to == null){
			UnityEngine.Debug.LogWarning("mismatch : null");
			return false;
		}

		bool t_result = true;

		t_result &= Test.Check_Enumerator("",a_from,a_to,(string a_a_label,in int a_a_from,in int a_a_to) =>{
			bool t_t_result = true;	
			t_t_result &= Test.Check_Int(a_a_label,a_a_from,a_a_to);
			return t_t_result;
		});

		return t_result;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_21 -----");

		{
			System.Collections.Generic.LinkedList<int> t_item_from = new System.Collections.Generic.LinkedList<int>();
			{
				t_item_from.AddLast(1);
				t_item_from.AddLast(2);
				t_item_from.AddLast(3);
			}

			//オブジェクト ==> ＪＳＯＮＩＴＥＭ。
			#if(FEE_JSON)
			Fee.JsonItem.JsonItem t_jsonitem = Fee.JsonItem.Convert.ObjectToJsonItem<System.Collections.Generic.LinkedList<int>>(t_item_from);
			#endif

			//ＪＳＯＮＩＴＥＭ ==> ＪＳＯＮ文字列。
			#if(FEE_JSON)
			string t_jsonstring = t_jsonitem.ConvertToJsonString();
			#else
			string t_jsonstring = UnityEngine.JsonUtility.ToJson(t_item_from);
			#endif

			//ＪＳＯＮ文字列 ==> オブジェクト。
			#if(FEE_JSON)
			System.Collections.Generic.LinkedList<int> t_item_to = Fee.JsonItem.Convert.JsonStringToObject<System.Collections.Generic.LinkedList<int>>(t_jsonstring);
			#else
			System.Collections.Generic.LinkedList<int> t_item_to = UnityEngine.JsonUtility.FromJson<System.Collections.Generic.LinkedList<int>>(t_jsonstring);
			#endif
		
			//ログ。
			UnityEngine.Debug.Log("Test_21 : " + t_jsonstring);

			//チェック。
			if(Check(t_item_from,t_item_to) == false){
				UnityEngine.Debug.LogError("mismatch");
			}
		}
	}
}

