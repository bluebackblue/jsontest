
/** テスト。
*/
#define FEE_JSON


/** Enum(内部型)。
*/
public class Test_26
{
	/** Item
	*/
	public class Item
	{



	}

	/** チェック。
	*/
	public static void Check(Item a_item_from,Item a_item_to)
	{
		if(a_item_to == null){
			UnityEngine.Debug.LogWarning("mismatch : null");
			return;
		}

		/*
		Test.Check_Enum("value_type",			a_item_from.value_type,			a_item_to.value_type);
		Test.Check_Enum("value_type_int",		a_item_from.value_type_int,		a_item_to.value_type_int);
		Test.Check_Enum("value_type_string",	a_item_from.value_type_string,	a_item_to.value_type_string);
		*/
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_26 -----");

		{
			Item t_item_from = new Item();
			{
				/*
				t_item_from.value_type = Item.Type.TypeA;
				t_item_from.value_type_int = Item.Type.TypeB;
				t_item_from.value_type_string = Item.Type.TypeC;
				*/
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
			Check(t_item_from,t_item_to);
		}
	}
}

