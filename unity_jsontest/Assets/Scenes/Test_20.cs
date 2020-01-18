
/** テスト。
*/
#define FEE_JSON


/** 要素をオブジェクト化できないGeneric。
*/
public class Test_20
{
	/** Item_Key
	*/
	public class Item_Key
	{
		public int key;
		public Item_Key(){
		}
		public Item_Key(int a_key)
		{
			this.key = a_key;
		}
	}

	/** Item
	*/
	public class Item
	{
		public System.Collections.Generic.Dictionary<Item_Key,int> dictionary;
		public System.Collections.Generic.LinkedList<int> linked_list;
		public System.Collections.Generic.HashSet<int> hash_set;
		public System.Collections.Generic.Queue<int> queue;
		public System.Collections.Generic.SortedSet<int> sorted_set;
		public System.Collections.Generic.Stack<int> stack;
	};

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_20 -----");

		{
			Item t_item_from = new Item();
			{
				t_item_from.dictionary = new System.Collections.Generic.Dictionary<Item_Key,int>();
				t_item_from.dictionary.Add(new Item_Key(1),1);
				t_item_from.dictionary.Add(new Item_Key(2),2);
				t_item_from.dictionary.Add(new Item_Key(3),3);

				t_item_from.linked_list = new System.Collections.Generic.LinkedList<int>();
				t_item_from.linked_list.AddLast(1);
				t_item_from.linked_list.AddLast(2);
				t_item_from.linked_list.AddLast(3);

				t_item_from.hash_set = new System.Collections.Generic.HashSet<int>();
				t_item_from.hash_set.Add(1);
				t_item_from.hash_set.Add(2);
				t_item_from.hash_set.Add(3);

				t_item_from.queue = new System.Collections.Generic.Queue<int>();
				t_item_from.queue.Enqueue(1);
				t_item_from.queue.Enqueue(2);
				t_item_from.queue.Enqueue(3);

				t_item_from.sorted_set = new System.Collections.Generic.SortedSet<int>();
				t_item_from.sorted_set.Add(1);
				t_item_from.sorted_set.Add(2);
				t_item_from.sorted_set.Add(3);

				t_item_from.stack = new System.Collections.Generic.Stack<int>();
				t_item_from.stack.Push(1);
				t_item_from.stack.Push(2);
				t_item_from.stack.Push(3);
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
			UnityEngine.Debug.Log("Test_20 : " + t_jsonstring);

			//チェック。
			{
				if(t_item_from.dictionary.Count != t_item_to.dictionary.Count){
					UnityEngine.Debug.LogWarning("dictionary_int : " + t_item_from.dictionary.Count.ToString() + " : " + t_item_to.dictionary.Count.ToString());
				}
				if(t_item_from.linked_list.Count != t_item_to.linked_list.Count){
					UnityEngine.Debug.LogWarning("linked_list : " + t_item_from.linked_list.Count.ToString() + " : " + t_item_to.linked_list.Count.ToString());
				}
				if(t_item_from.hash_set.Count != t_item_to.hash_set.Count){
					UnityEngine.Debug.LogWarning("hash_set : " + t_item_from.hash_set.Count.ToString() + " : " + t_item_to.hash_set.Count.ToString());
				}
				if(t_item_from.queue.Count != t_item_to.queue.Count){
					UnityEngine.Debug.LogWarning("queue : " + t_item_from.queue.Count.ToString() + " : " + t_item_to.queue.Count.ToString());
				}
				if(t_item_from.sorted_set.Count != t_item_to.sorted_set.Count){
					UnityEngine.Debug.LogWarning("sorted_set : " + t_item_from.sorted_set.Count.ToString() + " : " + t_item_to.sorted_set.Count.ToString());
				}
				if(t_item_from.stack.Count != t_item_to.stack.Count){
					UnityEngine.Debug.LogWarning("stack : " + t_item_from.stack.Count.ToString() + " : " + t_item_to.stack.Count.ToString());
				}
			}
		}
	}
}

