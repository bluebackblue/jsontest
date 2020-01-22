
/** テスト。
*/
#define FEE_JSON


/** System.Arrayネスト。
*/
public class Test_15
{
	/** チェック。
	*/
	public static bool Check(int[][][][][][][][][][][][] a_from,int[][][][][][][][][][][][] a_to)
	{
		if(a_to == null){
			UnityEngine.Debug.LogWarning("mismatch : null");
			return false;
		}

		bool t_result = true;

		t_result &= Test.Check_Int("0.length",	a_from.Length,										a_to.Length);
		t_result &= Test.Check_Int("1.length",	a_from[0].Length,									a_to[0].Length);
		t_result &= Test.Check_Int("2.length",	a_from[0][0].Length,								a_to[0][0].Length);
		t_result &= Test.Check_Int("3.length",	a_from[0][0][0].Length,								a_to[0][0][0].Length);
		t_result &= Test.Check_Int("4.length",	a_from[0][0][0][0].Length,							a_to[0][0][0][0].Length);
		t_result &= Test.Check_Int("5.length",	a_from[0][0][0][0][0].Length,						a_to[0][0][0][0][0].Length);
		t_result &= Test.Check_Int("6.length",	a_from[0][0][0][0][0][0].Length,					a_to[0][0][0][0][0][0].Length);
		t_result &= Test.Check_Int("7.length",	a_from[0][0][0][0][0][0][0].Length,					a_to[0][0][0][0][0][0][0].Length);
		t_result &= Test.Check_Int("8.length",	a_from[0][0][0][0][0][0][0][0].Length,				a_to[0][0][0][0][0][0][0][0].Length);
		t_result &= Test.Check_Int("9.length",	a_from[0][0][0][0][0][0][0][0][0].Length,			a_to[0][0][0][0][0][0][0][0][0].Length);
		t_result &= Test.Check_Int("10.length",	a_from[0][0][0][0][0][0][0][0][0][0].Length,		a_to[0][0][0][0][0][0][0][0][0][0].Length);
		t_result &= Test.Check_Int("11.length",	a_from[0][0][0][0][0][0][0][0][0][0][0].Length,		a_to[0][0][0][0][0][0][0][0][0][0][0].Length);

		t_result &= Test.Check_Int("11.value",	a_from[0][0][0][0][0][0][0][0][0][0][0][0],			a_to[0][0][0][0][0][0][0][0][0][0][0][0]);

		return t_result;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_15 -----");

		{
			int[][][][][][][][][][][][] t_item_from = null;
			{
				t_item_from = new int[1][][][][][][][][][][][];
				t_item_from[0] = new int [1][][][][][][][][][][];
				t_item_from[0][0] = new int [1][][][][][][][][][];
				t_item_from[0][0][0] = new int [1][][][][][][][][];
				t_item_from[0][0][0][0] = new int [1][][][][][][][];
				t_item_from[0][0][0][0][0] = new int [1][][][][][][];
				t_item_from[0][0][0][0][0][0] = new int [1][][][][][];
				t_item_from[0][0][0][0][0][0][0] = new int [1][][][][];
				t_item_from[0][0][0][0][0][0][0][0] = new int [1][][][];
				t_item_from[0][0][0][0][0][0][0][0][0] = new int [1][][];
				t_item_from[0][0][0][0][0][0][0][0][0][0] = new int [1][];
				t_item_from[0][0][0][0][0][0][0][0][0][0][0] = new int [1];
				t_item_from[0][0][0][0][0][0][0][0][0][0][0][0] = -1;
			}

			//オブジェクト ==> ＪＳＯＮＩＴＥＭ。
			#if(FEE_JSON)
			Fee.JsonItem.JsonItem t_jsonitem = Fee.JsonItem.Convert.ObjectToJsonItem<int[][][][][][][][][][][][]>(t_item_from);
			#endif

			//ＪＳＯＮＩＴＥＭ ==> ＪＳＯＮ文字列。
			#if(FEE_JSON)
			string t_jsonstring = t_jsonitem.ConvertToJsonString();
			#else
			string t_jsonstring = UnityEngine.JsonUtility.ToJson(t_item_from);
			#endif

			//ＪＳＯＮ文字列 ==> オブジェクト。
			#if(FEE_JSON)
			int[][][][][][][][][][][][] t_item_to = Fee.JsonItem.Convert.JsonStringToObject<int[][][][][][][][][][][][]>(t_jsonstring);
			#else
			int[][][][][][][][][][][][] t_item_to = UnityEngine.JsonUtility.FromJson<int[][][][][][][][][][][][]>(t_jsonstring);
			#endif

			//ログ。
			UnityEngine.Debug.Log("Test_15 : " + t_jsonstring);

			//チェック。
			if(Check(t_item_from,t_item_to) == false){
				UnityEngine.Debug.LogError("mismatch");
			}
		}
	}
}

