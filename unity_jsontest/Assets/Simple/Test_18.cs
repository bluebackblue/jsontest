

/** テスト。
*/
#define FEE_JSON


/** Simple
*/
namespace Simple
{
	/** 継承。
	*/
	public class Test_18
	{
		/** Item_Base_Base_Base
		*/
		public class Item_Base_Base_Base
		{
			/** 4
			*/
			readonly public int pub_4;
			readonly protected int pro_4;
			readonly private int pri_4;

			/** constructor
			*/
			public Item_Base_Base_Base()
			{
			}

			/** constructor
			*/
			public Item_Base_Base_Base(int a_base)
			{
				this.pub_4 = 14 + a_base;
				this.pro_4 = 24 + a_base;
				this.pri_4 = 34 + a_base;
			}

			/** Check
			*/
			public static bool Check(Item_Base_Base_Base a_from,Item_Base_Base_Base a_to)
			{
				bool t_result = true;
				t_result &= Simple.Check_Int("pub_4",a_from.pub_4,a_to.pub_4);
				t_result &= Simple.Check_Int("pro_4",a_from.pub_4,a_to.pub_4);
				t_result &= Simple.Check_Int("pri_4",a_from.pub_4,a_to.pub_4);
				return t_result;
			}
		}

		/** Item_Base_Base
		*/
		public class Item_Base_Base : Item_Base_Base_Base
		{
			/** 3
			*/
			readonly public int pub_3;
			readonly protected int pro_3;
			readonly private int pri_3;

			/** constructor
			*/
			public Item_Base_Base()
			{
			}

			/** constructor
			*/
			public Item_Base_Base(int a_base)
				:
				base(a_base)
			{
				this.pub_3 = 13 + a_base;
				this.pro_3 = 23 + a_base;
				this.pri_3 = 33 + a_base;
			}

			/** Check
			*/
			public static bool Check(Item_Base_Base a_from,Item_Base_Base a_to)
			{
				bool t_result = true;
				t_result &= Simple.Check_Int("pub_3",a_from.pub_3,a_to.pub_3);
				t_result &= Simple.Check_Int("pro_3",a_from.pub_3,a_to.pub_3);
				t_result &= Simple.Check_Int("pri_3",a_from.pub_3,a_to.pub_3);
				return t_result & Item_Base_Base_Base.Check(a_from,a_to);
			}
		}

		/** Item_Base
		*/
		public class Item_Base : Item_Base_Base
		{
			/** 2
			*/
			readonly public int pub_2;
			readonly protected int pro_2;
			readonly private int pri_2;

			/** constructor
			*/
			public Item_Base()
			{
			}

			/** constructor
			*/
			public Item_Base(int a_base)
				:
				base(a_base)
			{
				this.pub_2 = 12 + a_base;
				this.pro_2 = 22 + a_base;
				this.pri_2 = 32 + a_base;
			}

			/** Check
			*/
			public static bool Check(Item_Base a_from,Item_Base a_to)
			{
				bool t_result = true;
				t_result &= Simple.Check_Int("pub_2",a_from.pub_2,a_to.pub_2);
				t_result &= Simple.Check_Int("pro_2",a_from.pub_2,a_to.pub_2);
				t_result &= Simple.Check_Int("pri_2",a_from.pub_2,a_to.pub_2);
				return t_result & Item_Base_Base.Check(a_from,a_to);
			}
		}

		/** Item
		*/
		public class Item : Item_Base
		{
			/** 1
			*/
			readonly public int pub_1;
			readonly protected int pro_1;
			readonly private int pri_1;

			/** constructor
			*/
			public Item()
			{
			}

			/** constructor
			*/
			public Item(int a_base)
				:
				base(a_base)
			{
				this.pub_1 = 11 + a_base;
				this.pro_1 = 21 + a_base;
				this.pri_1 = 31 + a_base;
			}

			/** Check
			*/
			public static bool Check(Item a_from,Item a_to)
			{
				bool t_result = true;
				t_result &= Simple.Check_Int("pub_1",a_from.pub_1,a_to.pub_1);
				t_result &= Simple.Check_Int("pro_1",a_from.pub_1,a_to.pub_1);
				t_result &= Simple.Check_Int("pri_1",a_from.pub_1,a_to.pub_1);
				return t_result & Item_Base.Check(a_from,a_to);
			}
		};

		/** チェック。
		*/
		public static bool Check(Item a_from,Item a_to)
		{
			if(a_to == null){
				UnityEngine.Debug.LogWarning("mismatch : null");
				return false;
			}

			bool t_result = true;

			if(Item.Check(a_from,a_to) == false){
				t_result = false;
				UnityEngine.Debug.LogWarning("mismatch");
			}

			return t_result;
		}

		/** 更新。
		*/
		public static void Main(string a_label = nameof(Test_18))
		{
			UnityEngine.Debug.Log("----- " + a_label + " -----");

			try{
				Item t_item_from = new Item(1000);
				{
				}

				//オブジェクト ==> ＪＳＯＮＩＴＥＭ。
				#if(FEE_JSON)
				Fee.JsonItem.JsonItem t_jsonitem = Fee.JsonItem.Convert.ObjectToJsonItem<Item>(t_item_from);
				#endif

				//ＪＳＯＮＩＴＥＭ ==> ＪＳＯＮ文字列。
				#if(FEE_JSON)
				string t_jsonstring = t_jsonitem.ConvertToJsonString();
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
				UnityEngine.Debug.Log(a_label + " : " + t_jsonstring);

				//チェック。
				if(Check(t_item_from,t_item_to) == false){
					UnityEngine.Debug.LogError("mismatch");
				}
			}catch(System.Exception t_exception){
				UnityEngine.Debug.LogError(a_label + " : exception : " + t_exception.Message);
			}
		}
	}
}

