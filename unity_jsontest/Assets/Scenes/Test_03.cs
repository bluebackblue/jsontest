
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
			{
				//文字。
				{
					string t_log = "value_string : " + Test.ToBinaryString(t_item_from.value_string) + " : " + Test.ToBinaryString(t_item_to.value_string);
					if(t_item_from.value_string == t_item_to.value_string){
						UnityEngine.Debug.Log(t_log);
					}else{
						UnityEngine.Debug.LogWarning(t_log);
					}
				}

				//ベル。
				{
					string t_log = "value_bell : " + Test.ToBinaryString(t_item_from.value_bell) + " : " + Test.ToBinaryString(t_item_to.value_bell);
					if(t_item_from.value_bell == t_item_to.value_bell){
						UnityEngine.Debug.Log(t_log);
					}else{
						UnityEngine.Debug.LogWarning(t_log);
					}
				}

				//ヌル。
				{
					string t_log = "value_null : " + Test.ToBinaryString(t_item_from.value_null) + " : " + Test.ToBinaryString(t_item_to.value_null);
					if(t_item_from.value_null == t_item_to.value_null){
						UnityEngine.Debug.Log(t_log);
					}else{
						UnityEngine.Debug.LogWarning(t_log);
					}
				}

				//バックスペース。
				{
					string t_log = "value_backspace : " + Test.ToBinaryString(t_item_from.value_backspace) + " : " + Test.ToBinaryString(t_item_to.value_backspace);
					if(t_item_from.value_backspace == t_item_to.value_backspace){
						UnityEngine.Debug.Log(t_log);
					}else{
						UnityEngine.Debug.LogWarning(t_log);
					}
				}

				//ラインフィード。
				{
					string t_log = "value_linefeed : " + Test.ToBinaryString(t_item_from.value_linefeed) + " : " + Test.ToBinaryString(t_item_to.value_linefeed);
					if(t_item_from.value_linefeed == t_item_to.value_linefeed){
						UnityEngine.Debug.Log(t_log);
					}else{
						UnityEngine.Debug.LogWarning(t_log);
					}
				}

				//タブ。
				{
					string t_log = "value_tab : " + Test.ToBinaryString(t_item_from.value_tab) + " : " + Test.ToBinaryString(t_item_to.value_tab);
					if(t_item_from.value_tab == t_item_to.value_tab){
						UnityEngine.Debug.Log(t_log);
					}else{
						UnityEngine.Debug.LogWarning(t_log);
					}
				}

				//ダブルクォーテーション。
				{
					string t_log = "value_double_quotation : " + Test.ToBinaryString(t_item_from.value_double_quotation) + " : " + Test.ToBinaryString(t_item_to.value_double_quotation);
					if(t_item_from.value_double_quotation == t_item_to.value_double_quotation){
						UnityEngine.Debug.Log(t_log);
					}else{
						UnityEngine.Debug.LogWarning(t_log);
					}
				}

				//シングルクォーテーション。
				{
					string t_log = "value_single_quotation : " + Test.ToBinaryString(t_item_from.value_single_quotation) + " : " + Test.ToBinaryString(t_item_to.value_single_quotation);
					if(t_item_from.value_single_quotation == t_item_to.value_single_quotation){
						UnityEngine.Debug.Log(t_log);
					}else{
						UnityEngine.Debug.LogWarning(t_log);
					}
				}

				//バックスラッシュ。
				{
					string t_log = "value_back_slash : " + Test.ToBinaryString(t_item_from.value_back_slash) + " : " + Test.ToBinaryString(t_item_to.value_back_slash);
					if(t_item_from.value_back_slash == t_item_to.value_back_slash){
						UnityEngine.Debug.Log(t_log);
					}else{
						UnityEngine.Debug.LogWarning(t_log);
					}
				}

				//キャリッジリターン。
				{
					string t_log = "value_carriage_return : " + Test.ToBinaryString(t_item_from.value_carriage_return) + " : " + Test.ToBinaryString(t_item_to.value_carriage_return);
					if(t_item_from.value_carriage_return == t_item_to.value_carriage_return){
						UnityEngine.Debug.Log(t_log);
					}else{
						UnityEngine.Debug.LogWarning(t_log);
					}
				}

				//スラッシュ。
				{
					string t_log = "value_slash : " + Test.ToBinaryString(t_item_from.value_slash) + " : " + Test.ToBinaryString(t_item_to.value_slash);
					if(t_item_from.value_slash == t_item_to.value_slash){
						UnityEngine.Debug.Log(t_log);
					}else{
						UnityEngine.Debug.LogWarning(t_log);
					}
				}

				//ニューページ。
				{
					string t_log = "value_new_page : " + Test.ToBinaryString(t_item_from.value_new_page) + " : " + Test.ToBinaryString(t_item_to.value_new_page);
					if(t_item_from.value_new_page == t_item_to.value_new_page){
						UnityEngine.Debug.Log(t_log);
					}else{
						UnityEngine.Debug.LogWarning(t_log);
					}
				}
			}
		}
	}
}

