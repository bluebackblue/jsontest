
/** テスト。
*/
#define FEE_JSON


/** ITEM_TYPE
*/
using ITEM_TYPE = Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<Test_12.Item<int>>>>>>>>>>>>;


/** 構造体ネスト。
*/
public class Test_12
{
	/** Item
	*/
	public struct Item<T>
	{
		/** value
		*/
		public int value;

		/** item
		*/
		public T item;
	}

	/** チェック。
	*/
	public static bool Check(in ITEM_TYPE a_from,in ITEM_TYPE a_to)
	{
		/*
		if(a_to == null){
			UnityEngine.Debug.LogWarning("mismatch : null");
			return;
		}
		*/

		bool t_result = true;

		t_result &= Test.Check_Int("0.value",	a_from.value,															a_to.value);
		t_result &= Test.Check_Int("1.value",	a_from.item.value,														a_to.item.value);
		t_result &= Test.Check_Int("2.value",	a_from.item.item.value,													a_to.item.item.value);
		t_result &= Test.Check_Int("3.value",	a_from.item.item.item.value,											a_to.item.item.item.value);
		t_result &= Test.Check_Int("4.value",	a_from.item.item.item.item.value,										a_to.item.item.item.item.value);
		t_result &= Test.Check_Int("5.value",	a_from.item.item.item.item.item.value,									a_to.item.item.item.item.item.value);
		t_result &= Test.Check_Int("6.value",	a_from.item.item.item.item.item.item.value,								a_to.item.item.item.item.item.item.value);
		t_result &= Test.Check_Int("7.value",	a_from.item.item.item.item.item.item.item.value,						a_to.item.item.item.item.item.item.item.value);
		t_result &= Test.Check_Int("8.value",	a_from.item.item.item.item.item.item.item.item.value,					a_to.item.item.item.item.item.item.item.item.value);
		t_result &= Test.Check_Int("9.value",	a_from.item.item.item.item.item.item.item.item.item.value,				a_to.item.item.item.item.item.item.item.item.item.value);
		t_result &= Test.Check_Int("10.value",	a_from.item.item.item.item.item.item.item.item.item.item.value,			a_to.item.item.item.item.item.item.item.item.item.item.value);
		t_result &= Test.Check_Int("11.value",	a_from.item.item.item.item.item.item.item.item.item.item.item.value,	a_to.item.item.item.item.item.item.item.item.item.item.item.value);

		t_result &= Test.Check_Int("11.item",	a_from.item.item.item.item.item.item.item.item.item.item.item.item,		a_to.item.item.item.item.item.item.item.item.item.item.item.item);

		return t_result;
	}

	/** 更新。
	*/
	public static void Main()
	{
		UnityEngine.Debug.Log("----- Test_12 -----");

		{
			ITEM_TYPE t_item_from = new ITEM_TYPE();
			{
				t_item_from.value = 0;
				t_item_from.item.value = 1;
				t_item_from.item.item.value = 2;
				t_item_from.item.item.item.value = 3;
				t_item_from.item.item.item.item.value = 4;
				t_item_from.item.item.item.item.item.value = 5;
				t_item_from.item.item.item.item.item.item.value = 6;
				t_item_from.item.item.item.item.item.item.item.value = 7;
				t_item_from.item.item.item.item.item.item.item.item.value = 8;
				t_item_from.item.item.item.item.item.item.item.item.item.value = 9;
				t_item_from.item.item.item.item.item.item.item.item.item.item.value = 10;
				t_item_from.item.item.item.item.item.item.item.item.item.item.item.value = -1;
				t_item_from.item.item.item.item.item.item.item.item.item.item.item.item = -1;
			}

			//オブジェクト ==> ＪＳＯＮＩＴＥＭ。
			#if(FEE_JSON)
			Fee.JsonItem.JsonItem t_jsonitem = Fee.JsonItem.Convert.ObjectToJsonItem<ITEM_TYPE>(t_item_from);
			#endif

			//ＪＳＯＮＩＴＥＭ ==> ＪＳＯＮ文字列。
			#if(FEE_JSON)
			string t_jsonstring = t_jsonitem.ConvertJsonString();
			#else
			string t_jsonstring = UnityEngine.JsonUtility.ToJson(t_item_from);
			#endif

			//ＪＳＯＮ文字列 ==> オブジェクト。
			#if(FEE_JSON)
			ITEM_TYPE t_item_to = Fee.JsonItem.Convert.JsonStringToObject<ITEM_TYPE>(t_jsonstring);
			#else
			ITEM_TYPE t_item_to = UnityEngine.JsonUtility.FromJson<ITEM_TYPE>(t_jsonstring);
			#endif

			//ログ。
			UnityEngine.Debug.Log("Test_12 : " + t_jsonstring);

			//チェック。
			if(Check(t_item_from,t_item_to) == false){
				UnityEngine.Debug.LogError("mismatch");
			}
		}
	}
}

