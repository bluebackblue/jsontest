
/** テスト。
*/
#define FEE_JSON


/** リスト。
*/
public class Test_19
{
	/** Item
	*/
	public class Item
	{
		//public System.Collections.Generic.Dictionary<int,int> dic_int;

		//public System.Collections.Generic.LinkedList<int> linkedlist;
	
		public System.Collections.Generic.HashSet<int> hashset;

		public Item()
		{
		}
	};

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_19 -----");

		{
			Item t_item_from = new Item();
			{
				/*
				t_item_from.dic_string = new System.Collections.Generic.Dictionary<string,int>();
				t_item_from.dic_string.Add("item1",1);
				t_item_from.dic_string.Add("item2",2);
				t_item_from.dic_string.Add("item3",3);
				*/

				/*
				t_item_from.list = new System.Collections.Generic.List<int>();
				t_item_from.list.Add(1);
				t_item_from.list.Add(2);
				t_item_from.list.Add(3);
				*/

				/*
				t_item_from.dic_int = new System.Collections.Generic.Dictionary<int,int>();
				t_item_from.dic_int.Add(1,1);
				t_item_from.dic_int.Add(2,2);
				t_item_from.dic_int.Add(3,3);
				*/

				/*
				t_item_from.linkedlist = new System.Collections.Generic.LinkedList<int>();
				t_item_from.linkedlist.AddLast(1);
				t_item_from.linkedlist.AddLast(2);
				t_item_from.linkedlist.AddLast(3);
				*/

				t_item_from.hashset = new System.Collections.Generic.HashSet<int>();
				t_item_from.hashset.Add(1);
				t_item_from.hashset.Add(2);
				t_item_from.hashset.Add(3);
			}

			//オブジェクト ==> ＪＳＯＮＩＴＥＭ。
			#if(FEE_JSON)
			Fee.JsonItem.JsonItem t_jsonitem = Fee.JsonItem.Convert.ObjectToJsonItem<Item>(t_item_from);
			#endif

			//ＪＳＯＮＩＴＥＭ ==> ＪＳＯＮ文字列。
			#if(FEE_JSON)
			string t_jsonstring = t_jsonitem.ConvertJsonString();
			#else
			string t_jsonstring = UnityEngine.JsonUtility.ToJson(t_item_from);
			#endif

			//ＪＳＯＮ文字列 ==> オブジェクト。
			#if(FEE_JSON)
			Item t_item_to = Fee.JsonItem.Convert.JsonStringToObject<Item>(t_jsonstring);
			#else
			Item t_item_to = UnityEngine.JsonUtility.FromJson<Item>(t_jsonstring);
			#endif

			//ログ。
			UnityEngine.Debug.Log("Test_19 : " + t_jsonstring);

			//チェック。
			{
				/*
				if(t_item_from.Compare(t_item_to) == false){
					UnityEngine.Debug.LogWarning("mis match");
				}
				*/
			}
		}

	}
}

