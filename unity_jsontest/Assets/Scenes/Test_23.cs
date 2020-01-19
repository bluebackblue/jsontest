
/** テスト。
*/
#define FEE_JSON


/** Queue。
*/
public class Test_23
{
	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_23 -----");

		{
			System.Collections.Generic.Queue<int> t_item_from = new System.Collections.Generic.Queue<int>();
			{
				t_item_from.Enqueue(1);
				t_item_from.Enqueue(2);
				t_item_from.Enqueue(3);
			}

			//オブジェクト ==> ＪＳＯＮＩＴＥＭ。
			#if(FEE_JSON)
			Fee.JsonItem.JsonItem t_jsonitem = Fee.JsonItem.Convert.ObjectToJsonItem<System.Collections.Generic.Queue<int>>(t_item_from);
			#endif

			//ＪＳＯＮＩＴＥＭ ==> ＪＳＯＮ文字列。
			#if(FEE_JSON)
			string t_jsonstring = t_jsonitem.ConvertJsonString();
			#else
			string t_jsonstring = UnityEngine.JsonUtility.ToJson(t_item_from);
			#endif

			//ＪＳＯＮ文字列 ==> オブジェクト。
			#if(FEE_JSON)
			System.Collections.Generic.Queue<int> t_item_to = Fee.JsonItem.Convert.JsonStringToObject<System.Collections.Generic.Queue<int>>(t_jsonstring);
			#else
			System.Collections.Generic.Queue<int> t_item_to = UnityEngine.JsonUtility.FromJson<System.Collections.Generic.Queue<int>>(t_jsonstring);
			#endif
		
			//ログ。
			UnityEngine.Debug.Log("Test_23 : " + t_jsonstring);

			//チェック。
			{
				if(Test.NullSizeCheck(t_item_from,t_item_to) == true){
					System.Collections.IEnumerator t_from = t_item_from.GetEnumerator();
					System.Collections.IEnumerator t_to = t_item_to.GetEnumerator();

					while(true){
						{
							bool t_ret_from = t_from.MoveNext();
							bool t_ret_to = t_to.MoveNext();
							if((t_ret_from == false)&&(t_ret_to == false)){
								break;
							}
						}

						int t_value_from = (int)t_from.Current;
						int t_value_to = (int)t_to.Current;

						if(t_value_from != t_value_to){
							UnityEngine.Debug.LogWarning("mismatch");
						}
					}
				}else{
					UnityEngine.Debug.LogWarning("mismatch");
				}
			}
		}
	}
}

