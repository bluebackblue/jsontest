

/** テスト。
*/
#define FEE_JSON


/** Simple
*/
namespace Simple
{
	/** テストコード。
	*/
	public class Test_99
	{
		/** Test_MonoBehaviour
		*/
		public class Test_MonoBehaviour : UnityEngine.MonoBehaviour
		{
			public bool flag;
			private Test_MonoBehaviour(){}
			public void Awake()
			{
				this.flag = true;
			}
		}

		/** Item
		*/
		public class Item
		{
			[Fee.JsonItem.Ignore]
			public UnityEngine.Material material;

			[Fee.JsonItem.Ignore]
			public UnityEngine.MonoBehaviour monobehaviour;
		};

		/** チェック。
		*/
		public static bool Check(Item a_item_from,Item a_item_to)
		{
			if(a_item_to == null){
				UnityEngine.Debug.LogWarning("mismatch : null");
				return false;
			}

			bool t_result = true;
			return t_result;
		}

		/** 更新。
		*/
		public static void Main(string a_label = nameof(Test_99))
		{
			UnityEngine.Debug.Log("----- " + a_label + " -----");

			try{
				Item t_item_from = new Item();
				{
					//material
					t_item_from.material = new UnityEngine.Material(UnityEngine.Shader.Find("Fee/Render2D/Add"));

					//monobehaviour
					UnityEngine.GameObject t_gameobject = new UnityEngine.GameObject("gameobject");
					t_item_from.monobehaviour = t_gameobject.AddComponent<Test_MonoBehaviour>();
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

