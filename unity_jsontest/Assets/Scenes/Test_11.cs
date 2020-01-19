
/** テスト。
*/
#define FEE_JSON


/** クラスネスト。
*/
public class Test_11
{
	/** Item
	*/
	public class Item
	{
		/** value
		*/
		public int value;

		/** item_class
		*/
		public Item item;

		/** constructor
		*/
		public Item()
		{
		}

		/** constructor
		*/
		public Item(int a_value,Item a_item)
		{
			this.value = a_value;
			this.item = a_item;
		}
	}

	/** 比較。
	*/
	public static bool Compare(Item a_item_a,Item a_item_b)
	{
		if((a_item_a == null)&&(a_item_b == null)){
			return true;
		}

		if((a_item_a == null)||(a_item_b == null)){
			return false;
		}

		if(a_item_a.value != a_item_b.value){
			return false;
		}

		if(Compare(a_item_a.item,a_item_b.item) == false){
			return false;
		}

		return true;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_11 -----");

		{
			Item t_item_from = new Item(0,null);
			{
				Item t_current_item = t_item_from;
				for(int ii=0;ii<13;ii++){
					t_current_item.value = ii;
					t_current_item.item = new Item(-1,null);
					t_current_item = t_current_item.item;
				}
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
			UnityEngine.Debug.Log("Test_11 : " + t_jsonstring);

			//チェック。
			{
				if(Compare(t_item_from,t_item_to) == false){
					UnityEngine.Debug.LogWarning("mismatch");
				}
			}
		}
	}
}

