
/** テスト。
*/
#define FEE_JSON


/** List。
*/
public class Test_08
{
	/** チェック。
	*/
	public static void Check(System.Collections.Generic.List<int> a_from,System.Collections.Generic.List<int> a_to)
	{
		if(a_to == null){
			UnityEngine.Debug.LogWarning("mismatch : null");
			return;
		}

		//Generic.List<int>
		{
			if(a_from.Count != a_to.Count){
				UnityEngine.Debug.LogWarning("mismatch : " + "count : " + a_from.Count.ToString() + " : " + a_to.Count.ToString());
			}

			for(int ii=0;ii<a_from.Count;ii++){
				if(ii >= a_to.Count){
					UnityEngine.Debug.LogWarning("mismatch : " + ii.ToString() + " : notexist");
				}else{
					Test.Check_Int(ii.ToString(),a_from[ii],a_to[ii]);
				}
			}
		}
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_08 -----");

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
			//{}
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
			Check(t_item_from,t_item_to);
		}
	}
}

