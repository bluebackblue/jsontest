﻿

/** テスト。
*/
#define FEE_JSON


/** Simple
*/
namespace Simple
{
	/** System.Array。
	*/
	public class Test_09
	{
		/** チェック。
		*/
		public static bool Check(int[] a_from,int[] a_to)
		{
			if(a_to == null){
				UnityEngine.Debug.LogWarning("mismatch : null");
				return false;
			}

			bool t_result = true;

			t_result &= Simple.Check_Enumerator("",a_from,a_to,(string a_a_label,int a_a_index,in int a_a_from,in int a_a_to) => {
				bool t_t_result = true;
				t_t_result &= Simple.Check_Int(a_a_label,a_a_from,a_a_to);
				return t_t_result;
			});

			return t_result;
		}

		/** 更新。
		*/
		public static void Main(string a_label = nameof(Test_09))
		{
			UnityEngine.Debug.Log("----- " + a_label + " -----");

			try{
				int[] t_item_from = new int[3]{
					1,
					2,
					3,
				};

				//オブジェクト ==> ＪＳＯＮＩＴＥＭ。
				#if(FEE_JSON)
				Fee.JsonItem.JsonItem t_jsonitem = Fee.JsonItem.Convert.ObjectToJsonItem<int[]>(t_item_from);
				#endif

				//ＪＳＯＮＩＴＥＭ ==> ＪＳＯＮ文字列。
				#if(FEE_JSON)
				string t_jsonstring = t_jsonitem.ConvertToJsonString();
				#else
				string t_jsonstring = UnityEngine.JsonUtility.ToJson(t_item_from);
				#endif

				//ＪＳＯＮ文字列 ==> オブジェクト。
				#if(FEE_JSON)
				int[] t_item_to = Fee.JsonItem.Convert.JsonStringToObject<int[]>(t_jsonstring);
				#else
				int[] t_item_to = UnityEngine.JsonUtility.FromJson<int[]>(t_jsonstring);
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
}

