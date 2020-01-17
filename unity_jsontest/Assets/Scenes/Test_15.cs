
/** テスト。
*/
#define FEE_JSON


/** 配列ネスト。
*/
public class Test_15
{
	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_14 -----");

		{
			int[][][][][][][][][][][][] t_item_from = null;
			{
				t_item_from = new int[1][][][][][][][][][][][];
				t_item_from[0] = new int [1][][][][][][][][][][];
				t_item_from[0][0] = new int [1][][][][][][][][][];
				t_item_from[0][0][0] = new int [1][][][][][][][][];
				t_item_from[0][0][0][0] = new int [1][][][][][][][];
				t_item_from[0][0][0][0][0] = new int [1][][][][][][];
				t_item_from[0][0][0][0][0][0] = new int [1][][][][][];
				t_item_from[0][0][0][0][0][0][0] = new int [1][][][][];
				t_item_from[0][0][0][0][0][0][0][0] = new int [1][][][];
				t_item_from[0][0][0][0][0][0][0][0][0] = new int [1][][];
				t_item_from[0][0][0][0][0][0][0][0][0][0] = new int [1][];
				t_item_from[0][0][0][0][0][0][0][0][0][0][0] = new int [1];
				t_item_from[0][0][0][0][0][0][0][0][0][0][0][0] = -1;
			}

			//オブジェクト ==> ＪＳＯＮＩＴＥＭ。
			#if(FEE_JSON)
			Fee.JsonItem.JsonItem t_jsonitem = Fee.JsonItem.Convert.ObjectToJsonItem<int[][][][][][][][][][][][]>(t_item_from);
			#endif

			//ＪＳＯＮＩＴＥＭ ==> ＪＳＯＮ文字列。
			#if(FEE_JSON)
			string t_jsonstring = t_jsonitem.ConvertJsonString();
			#else
			string t_jsonstring = UnityEngine.JsonUtility.ToJson(t_item_from);
			#endif

			//ＪＳＯＮ文字列 ==> オブジェクト。
			#if(FEE_JSON)
			int[][][][][][][][][][][][] t_item_to = Fee.JsonItem.Convert.JsonStringToObject<int[][][][][][][][][][][][]>(t_jsonstring);
			#else
			int[][][][][][][][][][][][] t_item_to = UnityEngine.JsonUtility.FromJson<int[][][][][][][][][][][][]>(t_jsonstring);
			#endif

			//ログ。
			UnityEngine.Debug.Log("Test_14 : " + t_jsonstring);

			//チェック。
			{
				if(t_item_from.Length != t_item_to.Length){
					UnityEngine.Debug.LogWarning("item0.value : "		+ t_item_from.Length.ToString()				+ " : " + t_item_to.Length.ToString());
				}

				if(t_item_from[0][0][0][0][0][0][0][0][0][0].Length != t_item_to[0][0][0][0][0][0][0][0][0][0].Length){
					UnityEngine.Debug.LogWarning("item10.value : "		+ t_item_from[0][0][0][0][0][0][0][0][0][0].Length.ToString()				+ " : " + t_item_to[0][0][0][0][0][0][0][0][0][0].Length.ToString());
				}

				if(t_item_from[0][0][0][0][0][0][0][0][0][0][0].Length != t_item_to[0][0][0][0][0][0][0][0][0][0][0].Length){
					UnityEngine.Debug.LogWarning("item11.value : "		+ t_item_from[0][0][0][0][0][0][0][0][0][0][0].Length.ToString()				+ " : " + t_item_to[0][0][0][0][0][0][0][0][0][0][0].Length.ToString());
				}

				if(t_item_from[0][0][0][0][0][0][0][0][0][0][0][0] != t_item_to[0][0][0][0][0][0][0][0][0][0][0][0]){
					UnityEngine.Debug.LogWarning("item11 : "		+ t_item_from[0][0][0][0][0][0][0][0][0][0][0][0].ToString()				+ " : " + t_item_to[0][0][0][0][0][0][0][0][0][0][0][0].ToString());
				}
			}
		}
	}
}

