
/** テスト。
*/
#define FEE_JSON


/** Dictionary(key = string)。
*/
public class Test_07
{
	/** チェック。
	*/
	public static void Check(System.Collections.Generic.Dictionary<string,int> a_from,System.Collections.Generic.Dictionary<string,int> a_to)
	{
		if(a_to == null){
			UnityEngine.Debug.LogWarning("mismatch : null");
			return;
		}

		//Generic.Dictionary
		{
			if(a_from.Count != a_to.Count){
				UnityEngine.Debug.LogWarning("mismatch : " + "count : " + a_from.Count.ToString() + " : " + a_to.Count.ToString());
			}

			foreach(System.Collections.Generic.KeyValuePair<string,int> t_from_pair in a_from){
				int t_to_value;
				if(a_to.TryGetValue(t_from_pair.Key,out t_to_value) == false){
					UnityEngine.Debug.LogWarning("mismatch : " + t_from_pair.Key + " : notexist");
				}else{
					int t_from_value = t_from_pair.Value;
					Test.Check_Int(t_from_pair.Key,t_from_value,t_to_value);
				}
			}
		}

	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_07 -----");

		{
			System.Collections.Generic.Dictionary<string,int> t_item_from = new System.Collections.Generic.Dictionary<string,int>();
			{
				t_item_from.Add("value_1",1);
				t_item_from.Add("value_2",2);
				t_item_from.Add("value_3",3);
			}

			//オブジェクト ==> ＪＳＯＮＩＴＥＭ。
			#if(FEE_JSON)
			Fee.JsonItem.JsonItem t_jsonitem = Fee.JsonItem.Convert.ObjectToJsonItem<System.Collections.Generic.Dictionary<string,int>>(t_item_from);
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
			System.Collections.Generic.Dictionary<string,int> t_item_to = Fee.JsonItem.Convert.JsonStringToObject<System.Collections.Generic.Dictionary<string,int>>(t_jsonstring);
			#else
			System.Collections.Generic.Dictionary<string,int> t_item_to = UnityEngine.JsonUtility.FromJson<System.Collections.Generic.Dictionary<string,int>>(t_jsonstring);
			#endif
		
			//ログ。
			UnityEngine.Debug.Log("Test_07 : " + t_jsonstring);

			//チェック。
			Check(t_item_from,t_item_to);
		}
	}
}

