
/** テスト。
*/
#define FEE_JSON


/** 継承。
*/
public class Test_18
{
	/** Item_Base_Base_Base
	*/
	public class Item_Base_Base_Base
	{
		readonly public int pub_4;
		readonly protected int pro_4;
		readonly private int pri_4;

		public Item_Base_Base_Base()
		{
			this.pub_4 = 14;
			this.pro_4 = 24;
			this.pri_4 = 34;
		}

		public bool Compare(object obj)
		{
			Item_Base_Base t_item = obj as Item_Base_Base;

			if(t_item == null){
				return false;
			}

			if(this.pub_4 != t_item.pub_4){
				return false;
			}
			if(this.pro_4 != t_item.pro_4){
				return false;
			}
			if(this.pri_4 != t_item.pri_4){
				return false;
			}

			return true;
		}
	}

	/** Item_Base_Base
	*/
	public class Item_Base_Base : Item_Base_Base_Base
	{
		readonly public int pub_3;
		readonly protected int pro_3;
		readonly private int pri_3;

		public Item_Base_Base()
			:
			base()
		{
			this.pub_3 = 13;
			this.pro_3 = 23;
			this.pri_3 = 33;
		}

		public new bool Compare(object obj)
		{
			Item_Base_Base t_item = obj as Item_Base_Base;

			if(t_item == null){
				return false;
			}

			if(this.pub_3 != t_item.pub_3){
				return false;
			}
			if(this.pro_3 != t_item.pro_3){
				return false;
			}
			if(this.pri_3 != t_item.pri_3){
				return false;
			}

			return base.Compare(obj);
		}
	}

	/** Item_Base
	*/
	public abstract class Item_Base : Item_Base_Base
	{
		readonly public int pub_2;
		readonly protected int pro_2;
		readonly private int pri_2;

		public Item_Base()
			:
			base()
		{
			this.pub_2 = 12;
			this.pro_2 = 22;
			this.pri_2 = 32;
		}

		public new bool Compare(object obj)
		{
			Item_Base t_item = obj as Item_Base;

			if(t_item == null){
				return false;
			}

			if(this.pub_2 != t_item.pub_2){
				return false;
			}
			if(this.pro_2 != t_item.pro_2){
				return false;
			}
			if(this.pri_2 != t_item.pri_2){
				return false;
			}

			return base.Compare(obj);
		}
	}


	/** Item
	*/
	public class Item : Item_Base
	{
		readonly public int pub_1;
		readonly protected int pro_1;
		readonly private int pri_1;

		public Item()
			:
			base()
		{
			this.pub_1 = 11;
			this.pro_1 = 21;
			this.pri_1 = 31;
		}

		public new bool Compare(object obj)
		{
			Item t_item = obj as Item;

			if(t_item == null){
				return false;
			}

			if(this.pub_1 != t_item.pub_1){
				return false;
			}
			if(this.pro_1 != t_item.pro_1){
				return false;
			}
			if(this.pri_1 != t_item.pri_1){
				return false;
			}

			return base.Compare(obj);
		}
	};

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_18 -----");

		{
			Item t_item_from = new Item();
			{
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
			UnityEngine.Debug.Log("Test_18 : " + t_jsonstring);

			//チェック。
			{
				if(t_item_from.Compare(t_item_to) == false){
					UnityEngine.Debug.LogWarning("mis match");
				}
			}
		}

	}
}

