
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

	/** チェック。
	*/
	public static bool Check(Item a_from,Item a_to)
	{
		if(a_to == null){
			UnityEngine.Debug.LogWarning("mismatch : null");
			return false;
		}

		bool t_result = true;

		//member
		t_result &= Check_Member(a_from,a_to);

		return t_result;
	}

	/** Check_Member
	*/
	public static bool Check_Member(Item a_from,Item a_to)
	{
		if((a_from == null)&&(a_to == null)){
			return true;
		}

		if(a_from == null){
			UnityEngine.Debug.LogWarning("mismatch : from == null");
			return false;
		}else if(a_to == null){
			UnityEngine.Debug.LogWarning("mismatch : to == null");
			return false;
		}

		bool t_result = true;

		//value
		t_result &= Test.Check_Int("value",a_from.value,a_to.value);

		//item
		t_result &= Check_Member(a_from.item,a_to.item);

		return t_result;
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
			if(Check(t_item_from,t_item_to) == false){
				UnityEngine.Debug.LogError("mismatch");
			}
		}
	}
}

