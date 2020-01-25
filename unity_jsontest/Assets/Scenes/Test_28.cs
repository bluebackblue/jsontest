
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

		/*
		Test.Check_Enumerator("arraylist",a_from.arraylist,a_to.arraylist,(string a_a_label,int a_a_index,in System.Object a_a_from,in System.Object a_a_to) => {
			bool t_t_result = true;

			switch(a_a_index){
			case 0:
				{
					t_t_result &= Test.Check_String("0:value_string",((Item_Value)a_a_from).value_string,(string)(((System.Collections.Generic.Dictionary<string,System.Object>)a_a_to)["value_string"]));
					t_t_result &= Test.Check_Bool("1:value_bool",((Item_Value)a_a_from).value_bool,(bool)(((System.Collections.Generic.Dictionary<string,System.Object>)a_a_to)["value_bool"]));
				}break;
			case 1:
				{
					t_t_result &= Test.Check_Int("1",(int)a_a_from,(int)(ulong)a_a_to);
				}break;
			case 2:
				{
					t_t_result &= Test.Check_String("2",(string)a_a_from,(string)a_a_to);
				}break;
			case 3:
				{
					t_t_result &= Test.Check_Byte("3",(byte)a_a_from,(byte)(ulong)a_a_to);
				}break;
			case 4:
				{
					t_t_result &= Test.Check_Enumerator("4",(System.Collections.Generic.List<int>)a_a_from,(System.Collections.Generic.List<System.Object>)a_a_to,(string a_a_a_label,int a_a_a_index,in int a_a_a_from,in System.Object a_a_a_to) => {
						bool t_t_t_result = true;
						t_t_t_result &= Test.Check_Int(a_a_a_label,(int)a_a_a_from,(int)(ulong)a_a_a_to);
						return t_t_t_result;
					});
				}break;
			case 5:
				{
					t_t_result &= Test.Check_Dictionary("5",(System.Collections.Generic.Dictionary<string,int>)a_a_from,(System.Collections.Generic.Dictionary<string,System.Object>)a_a_to,(string a_a_a_label,int a_a_a_index,in int a_a_a_from,in System.Object a_a_a_to) => {
						bool t_t_t_result = true;
						t_t_t_result &= Test.Check_Int(a_a_a_label,(int)a_a_a_from,(int)(ulong)a_a_a_to);
						return t_t_t_result;
					});
				}break;
			case 6:
				{
					t_t_result &= Test.Check_Enumerator("6",(int[])a_a_from,(System.Collections.Generic.List<System.Object>)a_a_to,(string a_a_a_label,int a_a_a_index,in int a_a_a_from,in System.Object a_a_a_to) => {
						bool t_t_t_result = true;
						t_t_t_result &= Test.Check_Int(a_a_a_label,(int)a_a_a_from,(int)(ulong)a_a_a_to);
						return t_t_t_result;
					});
				}break;
			}

			return t_t_result;
		});
		*/

		return t_result;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_28 -----");

		{
			Item t_item_from = new Item();
			{
				System.Collections.Generic.Dictionary<int,int> t_list_int = new System.Collections.Generic.Dictionary<int,int>();
				t_list_int.Add(1,100);
				t_list_int.Add(2,200);
				t_list_int.Add(3,300);

				System.Collections.Generic.Dictionary<Type_Key,int> t_list_type = new System.Collections.Generic.Dictionary<Type_Key,int>();
				t_list_type.Add(Type_Key.Key_A,100);
				t_list_type.Add(Type_Key.Key_B,200);
				t_list_type.Add(Type_Key.Key_C,300);
				
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
			UnityEngine.Debug.Log("Test_28 : " + t_jsonstring);

			//チェック。
			if(Check(t_item_from,t_item_to) == false){
				UnityEngine.Debug.LogError("mismatch");
			}
		}
	}
}

