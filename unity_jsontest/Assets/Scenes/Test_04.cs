
/** テスト。
*/
#define FEE_JSON


/** 文字２。
*/
public class Test_04
{
	/** Item
	*/
	public class Item
	{
		/** 文字。
		*/
		public string value;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_04 -----");

		//ＵＴＦ１６。
		{
			string t_jsonstring = "{\"value\":\"\\u3042\"}";

			//ＪＳＯＮ文字列 ==> オブジェクト。
			#if(FEE_JSON)
			Item t_item_to = Fee.JsonItem.Convert.JsonStringToObject<Item>(t_jsonstring);
			#else
			Item t_item_to = UnityEngine.JsonUtility.FromJson<Item>(t_jsonstring);
			#endif

			//ログ。
			UnityEngine.Debug.Log("Test_04 : 1 : " + t_jsonstring);

			//チェック。
			{
				string t_log = "value : " + Test.ToBinaryString("あ") + " : " + Test.ToBinaryString(t_item_to.value);
				if("あ" == t_item_to.value){
					UnityEngine.Debug.Log(t_log);
				}else{
					UnityEngine.Debug.LogWarning("mismatch : " + t_log);
				}
			}
		}

		//対応していないエスケープシーケンス。
		{
			string t_jsonstring = "{\"value\":\"\\x3042\"}";

			//ＪＳＯＮ文字列 ==> オブジェクト。
			#if(FEE_JSON)
			Item t_item_to = Fee.JsonItem.Convert.JsonStringToObject<Item>(t_jsonstring);
			#else
			//ArgumentException: JSON parse error: Invalid escape character in string.
			Item t_item_to = UnityEngine.JsonUtility.FromJson<Item>(t_jsonstring);
			#endif

			//ログ。
			UnityEngine.Debug.Log("Test_04 : 2 : " + t_jsonstring);

			//チェック。
			{
				string t_log = "value : " + Test.ToBinaryString("\x3042") + " : " + Test.ToBinaryString(t_item_to.value);
				if("\x3042" == t_item_to.value){
					UnityEngine.Debug.Log(t_log);
				}else{
					UnityEngine.Debug.LogWarning("mismatch : " + t_log);
				}
			}
		}
	}
}

