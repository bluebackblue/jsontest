
/** テスト。
*/
#define FEE_JSON


/** Generic.Dictionary(key != string)
*/
public class Test_28
{
	/** Type_Key
	*/
	public enum Type_Key
	{
		Key_A,
		Key_B,
		Key_C
	}

	/** Item_Key
	*/
	public class Item_Key
	{
		public int key;
		public override int GetHashCode()
		{
			return this.key.GetHashCode();
		}
		public override bool Equals(object a_object)
		{
			return this.key == ((Item_Key)a_object).key;
		}
		public Item_Key()
		{
		}
		public Item_Key(int a_key)
		{
			this.key = a_key;
		}
	}

	/** Item_Value
	*/
	public class Item_Value
	{
		public string value_string;
		public bool value_bool;
		public Item_Value(string a_value_string,bool a_value_bool)
		{
			this.value_string = a_value_string;
			this.value_bool = a_value_bool;
		}
	}

	/** Item
	*/
	public class Item
	{
		[Fee.JsonItem.EnumString]
		public System.Collections.Generic.Dictionary<Type_Key,int> list_type;
		public System.Collections.Generic.Dictionary<int,int> list_int;
		public System.Collections.Generic.Dictionary<Item_Key,int> list_class;
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

		t_result &= Test.Check_Dictionary("list_type",a_from.list_type,a_to.list_type,(string a_a_label,int a_a_index,in int a_a_from,in int a_a_to) => {
			bool t_t_result = true;
			t_t_result &= Test.Check_Int(a_a_label,a_a_from,a_a_to);
			return t_t_result;
		});

		t_result &= Test.Check_Dictionary("list_int",a_from.list_int,a_to.list_int,(string a_a_label,int a_a_index,in int a_a_from,in int a_a_to) => {
			bool t_t_result = true;
			t_t_result &= Test.Check_Int(a_a_label,a_a_from,a_a_to);
			return t_t_result;
		});

		t_result &= Test.Check_Dictionary("list_class",a_from.list_class,a_to.list_class,(string a_a_label,int a_a_index,in int a_a_from,in int a_a_to) => {
			bool t_t_result = true;
			t_t_result &= Test.Check_Int(a_a_label,a_a_from,a_a_to);
			return t_t_result;
		});

		return t_result;
	}

	/** 更新。
	*/
	public static void Main(string a_label = nameof(Test_28))
	{
		UnityEngine.Debug.Log("----- " + a_label + " -----");

		try{
			Item t_item_from = new Item();
			{
				System.Collections.Generic.Dictionary<Type_Key,int> t_list_type = new System.Collections.Generic.Dictionary<Type_Key,int>();
				t_list_type.Add(Type_Key.Key_A,100);
				t_list_type.Add(Type_Key.Key_B,200);
				t_list_type.Add(Type_Key.Key_C,300);

				System.Collections.Generic.Dictionary<int,int> t_list_int = new System.Collections.Generic.Dictionary<int,int>();
				t_list_int.Add(1,100);
				t_list_int.Add(2,200);
				t_list_int.Add(3,300);

				System.Collections.Generic.Dictionary<Item_Key,int> t_list_class = new System.Collections.Generic.Dictionary<Item_Key,int>();
				t_list_class.Add(new Item_Key(1),100);
				t_list_class.Add(new Item_Key(2),200);
				t_list_class.Add(new Item_Key(3),300);

				t_item_from.list_int = t_list_int;
				t_item_from.list_type = t_list_type;
				t_item_from.list_class = t_list_class;
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

