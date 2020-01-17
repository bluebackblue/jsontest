
/** テスト。
*/
#define FEE_JSON


/** Array。
*/
public class Test_09
{
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
			{
				if(Test.NullCheckArray(t_item_from,t_item_to) == true){
					for(int ii=0;ii<t_item_from.Length;ii++){
						if(t_item_from[ii] != t_item_to[ii]){
							UnityEngine.Debug.LogWarning(ii.ToString() + " : " + t_item_from[ii] + " : " + t_item_to[ii]);
						}
					}
				}else{
					UnityEngine.Debug.LogWarning("null");
				}
			}
		}
	}
}

