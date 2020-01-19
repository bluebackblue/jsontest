
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

	public class Item
	{
		/** 属性指定なし。
		*/
		public Type value_type;

		/** 数値としてＪＳＯＮ出力。
		*/
		[Fee.JsonItem.EnumInt]
		public Type value_type_int;

		/** 文字列としてＪＳＯＮ出力。
		*/
		[Fee.JsonItem.EnumString]
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
			UnityEngine.Debug.Log("Test_25 : " + t_jsonstring);

			//チェック。
			{

				if(Test.NullSizeCheck(t_item_from.list_type,t_item_to.list_type) == true){
					for(int ii=0;ii<t_item_from.list_type.Count;ii++){
						if(t_item_from.list_type[ii] != t_item_to.list_type[ii]){
							UnityEngine.Debug.LogWarning("mismatch : " + ii.ToString() + " : " + t_item_from.list_type[ii].ToString() + " : " + t_item_to.list_type[ii].ToString());
						}
					}
				}else{
					UnityEngine.Debug.LogWarning("mismatch");
				}

				if(Test.NullSizeCheck_Dictionary(t_item_from.dictionary_type,t_item_to.dictionary_type) == true){
					foreach(string t_key in t_item_from.dictionary_type.Keys){
						if(t_item_from.dictionary_type[t_key] != t_item_to.dictionary_type[t_key]){
							UnityEngine.Debug.LogWarning("mismatch : " + t_key + " : " + t_item_from.dictionary_type[t_key].ToString() + " : " + t_item_to.dictionary_type[t_key].ToString());
						}
					}
				}else{
					UnityEngine.Debug.LogWarning("mismatch");
				}

				if(Test.NullSizeCheck(t_item_from.list_item,t_item_to.list_item) == true){
					for(int ii=0;ii<t_item_from.list_item.Count;ii++){
						if(t_item_from.list_item[ii].value_type != t_item_to.list_item[ii].value_type){
							UnityEngine.Debug.LogWarning("mismatch : " + ii.ToString() + " : " + t_item_from.list_item[ii].value_type.ToString() + " : " + t_item_to.list_item[ii].value_type.ToString());
						}
					}
				}else{
					UnityEngine.Debug.LogWarning("mismatch");
				}

				if(Test.NullSizeCheck_Dictionary(t_item_from.dictionary_item,t_item_to.dictionary_item) == true){
					foreach(string t_key in t_item_from.dictionary_item.Keys){
						if(t_item_from.dictionary_item[t_key].value_type != t_item_to.dictionary_item[t_key].value_type){
							UnityEngine.Debug.LogWarning("mismatch : " + t_key + " : " + t_item_from.dictionary_item[t_key].value_type.ToString() + " : " + t_item_to.dictionary_item[t_key].value_type.ToString());
						}
					}
				}else{
					UnityEngine.Debug.LogWarning("mismatch");
				}
			}
		}
	}
}

