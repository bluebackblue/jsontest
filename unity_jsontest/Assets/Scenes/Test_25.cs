
/** テスト。
*/
#define FEE_JSON


/** Enum(属性指定)。
*/
public class Test_25
{
	/** Type
	*/
	public enum Type
	{
		/** TypeA
		*/
		Type_A,

		/** Type_B
		*/
		Type_B,

		/** Type_C
		*/
		Type_C = 100,
	}

	/** Item_Type
	*/
	public class Item_Type
	{
		/** value_type
		*/
		public Type value_type;

		/** constructor
		*/
		public Item_Type()
		{
		}

		/** constructor
		*/
		public Item_Type(Type a_value_type){
			this.value_type = a_value_type;
		}
	}

	/** Item
	*/
	public class Item
	{
		/** 属性指定なし。
		*/
		public Type value_type;

		/** 文字列としてＪＳＯＮ出力。
		*/
		[Fee.JsonItem.EnumString]
		public Type value_type_int;

		/** 数値としてＪＳＯＮ出力。
		*/
		[Fee.JsonItem.EnumInt]
		public Type value_type_string;

		/** list_type
		*/
		[Fee.JsonItem.EnumString]
		public System.Collections.Generic.List<Type> list_type;

		/** dictionary_type
		*/
		[Fee.JsonItem.EnumString]
		public System.Collections.Generic.Dictionary<string,Type> dictionary_type;

		/** list_item
		*/
		[Fee.JsonItem.EnumString]
		public System.Collections.Generic.List<Item_Type> list_item;

		/** dictionary_item
		*/
		[Fee.JsonItem.EnumString]
		public System.Collections.Generic.Dictionary<string,Item_Type> dictionary_item;
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

		t_result &= Test.Check_Enum("value_type",			a_from.value_type,			a_to.value_type);
		t_result &= Test.Check_Enum("value_type_int",		a_from.value_type_int,		a_to.value_type_int);
		t_result &= Test.Check_Enum("value_type_string",	a_from.value_type_string,	a_to.value_type_string);

		//list_type
		t_result &= Test.Check_Enumerator("list_type",a_from.list_type,a_to.list_type,(string a_a_label,in Type a_a_from,in Type a_a_to) => {
			bool t_t_result = true;	
			t_t_result &= Test.Check_Enum(a_a_label,a_a_from,a_a_to);
			return t_t_result;
		});

		//dictionary_type
		t_result &= Test.Check_Dictionary("dictionary_type",a_from.dictionary_type,a_to.dictionary_type,(string a_a_llabel,in Type a_a_from,in Type a_a_to) => {
			bool t_t_result = true;	
			t_t_result &= Test.Check_Enum(a_a_llabel,a_a_from,a_a_to);
			return t_t_result;
		});

		//list_item
		t_result &= Test.Check_Enumerator("list_item",a_from.list_item,a_to.list_item,(string a_a_label,in Item_Type a_a_from,in Item_Type a_a_to) => {
			bool t_t_result = true;	
			t_t_result &= Test.Check_Enum(a_a_label,a_a_from.value_type,a_a_to.value_type);
			return t_t_result;
		});

		//dictionary_item
		t_result &= Test.Check_Dictionary("dictionary_item",a_from.dictionary_item,a_to.dictionary_item,(string a_a_llabel,in Item_Type a_a_from,in Item_Type a_a_to) => {
			bool t_t_result = true;	
			t_t_result &= Test.Check_Enum(a_a_llabel,a_a_from.value_type,a_a_to.value_type);
			return t_t_result;
		});

		return t_result;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_25 -----");

		{
			Item t_item_from = new Item();
			{
				t_item_from.value_type = Type.Type_A;
				
				t_item_from.value_type_int = Type.Type_B;
				
				t_item_from.value_type_string = Type.Type_C;

				t_item_from.list_type = new System.Collections.Generic.List<Type>();
				t_item_from.list_type.Add(Type.Type_A);
				t_item_from.list_type.Add(Type.Type_B);
				t_item_from.list_type.Add(Type.Type_C);

				t_item_from.dictionary_type = new System.Collections.Generic.Dictionary<string,Type>();
				t_item_from.dictionary_type.Add("value_1",Type.Type_A);
				t_item_from.dictionary_type.Add("value_2",Type.Type_B);
				t_item_from.dictionary_type.Add("value_3",Type.Type_C);

				t_item_from.list_item = new System.Collections.Generic.List<Item_Type>();
				t_item_from.list_item.Add(new Item_Type(Type.Type_A));
				t_item_from.list_item.Add(new Item_Type(Type.Type_B));
				t_item_from.list_item.Add(new Item_Type(Type.Type_C));

				t_item_from.dictionary_item = new System.Collections.Generic.Dictionary<string,Item_Type>();
				t_item_from.dictionary_item.Add("value_1",new Item_Type(Type.Type_A));
				t_item_from.dictionary_item.Add("value_2",new Item_Type(Type.Type_B));
				t_item_from.dictionary_item.Add("value_3",new Item_Type(Type.Type_C));
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
			UnityEngine.Debug.Log("Test_25 : " + t_jsonstring);

			//チェック。
			if(Check(t_item_from,t_item_to) == false){
				UnityEngine.Debug.LogError("mismatch");
			}
		}
	}
}

