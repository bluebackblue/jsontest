

/** テスト。
*/
#define FEE_JSON


/** Simple
*/
namespace Simple
{
	/** 文字２。
	*/
	public class Test_04
	{
		/** Item
		*/
		public class Item
		{
			/** ＵＴＦ１６。
			*/
			public string value_u;

			/** 対応していないエスケープシーケンス。
			*/
			public string value_x;
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

			t_result &= Simple.Check_String("value_u",a_from.value_u,a_to.value_u);
			t_result &= Simple.Check_String("value_x",a_from.value_x,a_to.value_x);

			return t_result;
		}

		/** 更新。
		*/
		public static void Main(string a_label = nameof(Test_04))
		{
			UnityEngine.Debug.Log("----- " + a_label + " -----");

			try{
				Item t_item_from = new Item();
				{
					t_item_from.value_u = "\u3042";
					t_item_from.value_x = "\x3042";
				}

				string t_jsonstring = "{\"value_u\":\"\\u3042\",\"value_x\":\"\\x3042\"}";

				//ＪＳＯＮ文字列 ==> オブジェクト。
				#if(FEE_JSON)
				Item t_item_to = Fee.JsonItem.Convert.JsonStringToObject<Item>(t_jsonstring);
				#else
				//ArgumentException: JSON parse error: Invalid escape character in string.
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

