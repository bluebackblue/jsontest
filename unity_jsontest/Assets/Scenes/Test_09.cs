
/** テスト。
*/
#define FEE_JSON


/** Array。
*/
public class Test_09
{
	/** チェック。
	*/
	public static void Check(int[] a_from,int[] a_to)
	{
		if(a_to == null){
			UnityEngine.Debug.LogWarning("mismatch : null");
			return;
		}

		//int[]
		{
			if(a_from.Length != a_to.Length){
				UnityEngine.Debug.LogWarning("mismatch : " + "count : " + a_from.Length.ToString() + " : " + a_to.Length.ToString());
			}

			for(int ii=0;ii<a_from.Length;ii++){
				if(ii >= a_to.Length){
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
		UnityEngine.Debug.Log("----- Test_09 -----");

		{
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
			string t_jsonstring = t_jsonitem.ConvertJsonString();
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
			UnityEngine.Debug.Log("Test_09 : " + t_jsonstring);

			//チェック。
			Check(t_item_from,t_item_to);
		}
	}
}

