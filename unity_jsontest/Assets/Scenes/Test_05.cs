
/** テスト。
*/
#define FEE_JSON


/** Enum。
*/
public class Test_05
{
	/** Item
	*/
	public class Item
	{
		/** Type
		*/
		public enum Type
		{
			/** TypeA
			*/
			TypeA = 10,

			/** TypeB
			*/
			TypeB = 20,

			/** TypeC
			*/
			TypeC = 30,
		}

		/** デフォルト。
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
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_05 -----");

		{
			Item t_item_from = new Item();
			{
				t_item_from.value_type = Item.Type.TypeA;
				t_item_from.value_type_int = Item.Type.TypeB;
				t_item_from.value_type_string = Item.Type.TypeC;
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
			UnityEngine.Debug.Log("Test_05 : " + t_jsonstring);

			//チェック。
			{
				if(t_item_from.value_type != t_item_to.value_type){
					UnityEngine.Debug.LogWarning("value_type : "		+ t_item_from.value_type.ToString()				+ " : " + t_item_to.value_type.ToString());
				}

				if(t_item_from.value_type_int != t_item_to.value_type_int){
					UnityEngine.Debug.LogWarning("value_type_int : "	+ t_item_from.value_type_int.ToString()			+ " : " + t_item_to.value_type_int.ToString());
				}

				if(t_item_from.value_type_string != t_item_to.value_type_string){
					UnityEngine.Debug.LogWarning("value_type_string : "	+ t_item_from.value_type_string.ToString()		+ " : " + t_item_to.value_type_string.ToString());
				}
			}
		}
	}
}

