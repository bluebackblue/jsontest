
/** テスト。
*/
#define FEE_JSON


/** テストコード。
*/
public class Test_99
{
	/** Item_Key
	*/
	public class Item_Key
	{
		/** key
		*/
		public int key;

		/** constructor
		*/
		public Item_Key(){
		}

		/** constructor
		*/
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

		public System.Collections.ArrayList arraylist;
	};

	/** チェック。
	*/
	public static bool Check(Item a_item_from,Item a_item_to)
	{
		if(a_item_to == null){
			UnityEngine.Debug.LogWarning("mismatch : null");
			return false;
		}

		bool t_result = true;
		return t_result;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_99 -----");

		{
			Item t_item_from = new Item();
			{
				t_item_from.dictionary = new System.Collections.Generic.Dictionary<Item_Key,int>();
				t_item_from.dictionary.Add(new Item_Key(1),1);
				t_item_from.dictionary.Add(new Item_Key(2),2);
				t_item_from.dictionary.Add(new Item_Key(3),3);

				t_item_from.arraylist = new System.Collections.ArrayList();
				t_item_from.arraylist.Add(1);
				t_item_from.arraylist.Add("2");
				t_item_from.arraylist.Add(new Item_Key(3));
				t_item_from.arraylist.Add(new int[]{1,2,3});
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
			UnityEngine.Debug.Log("Test_99 : " + t_jsonstring);

			//チェック。
			if(Check(t_item_from,t_item_to) == false){
				UnityEngine.Debug.LogError("mismatch");
			}
		}
	}
}

