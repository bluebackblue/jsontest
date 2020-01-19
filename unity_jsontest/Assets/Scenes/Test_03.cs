
/** テスト。
*/
#define FEE_JSON


/** 文字１。
*/
public class Test_03
{
	/** Item
	*/
	public class Item
	{
		/** 文字。
		*/
		public string value_string;

		/** ベル。
		*/
		public string value_bell;

		/** ヌル。
		*/
		public string value_null;

		/** バックスペース。
		*/
		public string value_backspace;

		/** ラインフィード
		*/
		public string value_linefeed;

		/** タブ
		*/
		public string value_tab;

		/** ダブルクォーテーション。
		*/
		public string value_double_quotation;

		/** シングルクォーテーション。
		*/
		public string value_single_quotation;

		/** バックスラッシュ。
		*/
		public string value_back_slash;

		/** キャリッジリターン。
		*/
		public string value_carriage_return;

		/** スラッシュ。
		*/
		public string value_slash;

		/** ニューページ。
		*/
		public string value_new_page;
	}

	/** チェック。
	*/
	public static void Check(Item a_from,Item a_to)
	{
		if(a_to == null){
			UnityEngine.Debug.LogWarning("mismatch : null");
			return;
		}

		//文字。
		Test.Check_String("value_string",			a_from.value_string,			a_to.value_string);

		//ベル。
		Test.Check_String("value_bell",				a_from.value_bell,				a_to.value_bell);

		//ヌル。
		Test.Check_String("value_null",				a_from.value_null,				a_to.value_null);

		//バックスペース。
		Test.Check_String("value_backspace",		a_from.value_backspace,			a_to.value_backspace);

		//ラインフィード。
		Test.Check_String("value_linefeed",			a_from.value_linefeed,			a_to.value_linefeed);

		//タブ。
		Test.Check_String("value_tab",				a_from.value_tab,				a_to.value_tab);

		//ダブルクォーテーション。
		Test.Check_String("value_double_quotation",	a_from.value_double_quotation,	a_to.value_double_quotation);

		//シングルクォーテーション。
		Test.Check_String("value_single_quotation",	a_from.value_single_quotation,	a_to.value_single_quotation);

		//バックスラッシュ。
		Test.Check_String("value_back_slash",		a_from.value_back_slash,		a_to.value_back_slash);

		//キャリッジリターン。
		Test.Check_String("value_carriage_return",	a_from.value_carriage_return,	a_to.value_carriage_return);

		//スラッシュ。
		Test.Check_String("value_slash",			a_from.value_slash,				a_to.value_slash);

		//ニューページ。
		Test.Check_String("value_new_page",			a_from.value_new_page,			a_to.value_new_page);
	}


	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_03 -----");

		{
			Item t_item_from = new Item();
			{
				//文字。
				t_item_from.value_string = "aあア亜ぁｱA\u3042";

				//ベル。
				t_item_from.value_bell = "-\a-";

				//ヌル。
				t_item_from.value_null = "-\0-";

				//バックスペース。
				t_item_from.value_backspace = "-\b-";

				//ラインフィード。
				t_item_from.value_linefeed = "-\r-";

				//タブ。
				t_item_from.value_tab = "-\t-";

				//ダブルクォーテーション。
				t_item_from.value_double_quotation = "-\"-";

				//シングルクォーテーション。
				t_item_from.value_single_quotation = "-'-";

				//バックスラッシュ。
				t_item_from.value_back_slash = "-\\-";

				//キャリッジリターン。
				t_item_from.value_carriage_return = "-\n-";

				//スラッシュ。
				t_item_from.value_slash = "-/-";

				//ニューページ。
				t_item_from.value_new_page = "-\f-";
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
			UnityEngine.Debug.Log("Test_03 : " + t_jsonstring);

			//チェック。
			Check(t_item_from,t_item_to);
		}
	}
}

