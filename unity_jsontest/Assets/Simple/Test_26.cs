

/** テスト。
*/
#define FEE_JSON


/** Simple
*/
namespace Simple
{
	/** System.Object。
	*/
	public class Test_26
	{
		/** Item
		*/
		public class Item
		{
			public System.Object value_bool;
			public System.Object value_sbyte;
			public System.Object value_byte;
			public System.Object value_short;
			public System.Object value_ushort;
			public System.Object value_int;
			public System.Object value_uint;
			public System.Object value_long;
			public System.Object value_ulong;
			public System.Object value_char;
			public System.Object value_float;
			public System.Object value_double;
			public System.Object value_decimal;

			public System.Object value_list;
			public System.Object value_dictionary;
			public System.Object value_array;
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

			t_result &= Simple.Check_Bool("value_bool",			(bool)a_from.value_bool,				(bool)a_to.value_bool);
			t_result &= Simple.Check_Ulong("value_sbyte",		(ulong)(sbyte)a_from.value_sbyte,		(ulong)a_to.value_sbyte);
			t_result &= Simple.Check_Ulong("value_byte",		(ulong)(byte)a_from.value_byte,			(ulong)a_to.value_byte);
			t_result &= Simple.Check_Ulong("value_short",		(ulong)(short)a_from.value_short,		(ulong)a_to.value_short);
			t_result &= Simple.Check_Ulong("value_ushort",		(ulong)(ushort)a_from.value_ushort,		(ulong)a_to.value_ushort);
			t_result &= Simple.Check_Ulong("value_int",			(ulong)(int)a_from.value_int,			(ulong)a_to.value_int);
			t_result &= Simple.Check_Ulong("value_uint",		(ulong)(uint)a_from.value_uint,			(ulong)a_to.value_uint);
			t_result &= Simple.Check_Ulong("value_long",		(ulong)(long)a_from.value_long,			(ulong)a_to.value_long);
			t_result &= Simple.Check_Ulong("value_ulong",		(ulong)a_from.value_ulong,				(ulong)a_to.value_ulong);
			t_result &= Simple.Check_Ulong("value_char",		(ulong)(char)a_from.value_char,			(ulong)a_to.value_char);
			t_result &= Simple.Check_Double("value_float",		(double)(float)a_from.value_float,		(double)a_to.value_float);
			t_result &= Simple.Check_Double("value_double",		(double)a_from.value_double,			(double)a_to.value_double);
			t_result &= Simple.Check_Decimal("value_decimal",	(decimal)a_from.value_decimal,			(decimal)a_to.value_decimal);

			//value_list
			t_result &= Simple.Check_Enumerator("value_list",(System.Collections.Generic.List<int>)a_from.value_list,(System.Collections.Generic.List<System.Object>)a_to.value_list,(string a_a_label,int a_a_index,in int a_a_from,in System.Object a_a_to)=>{
				bool t_t_result = true;
				t_t_result &= Simple.Check_Int(a_a_label,a_a_from,(int)(ulong)a_a_to);
				return t_t_result;
			});

			//value_dictionary
			t_result &= Simple.Check_Dictionary("value_dictionary",(System.Collections.Generic.Dictionary<string,int>)a_from.value_dictionary,(System.Collections.Generic.Dictionary<string,System.Object>)a_to.value_dictionary,(string a_a_label,int a_a_index,in int a_a_from,in System.Object a_a_to)=>{
				bool t_t_result = true;
				t_t_result &= Simple.Check_Int(a_a_label,a_a_from,(int)(ulong)a_a_to);
				return t_t_result;
			});

			//value_array
			t_result &= Simple.Check_Enumerator("value_array",(int[])a_from.value_array,(System.Collections.Generic.List<System.Object>)a_to.value_array,(string a_a_label,int a_a_index,in int a_a_from,in System.Object a_a_to)=>{
				bool t_t_result = true;
				t_t_result &= Simple.Check_Int(a_a_label,a_a_from,(int)(ulong)a_a_to);
				return t_t_result;
			});

			return t_result;
		}

		/** 更新。
		*/
		public static void Main(string a_label = nameof(Test_26))
		{
			UnityEngine.Debug.Log("----- " + a_label + " -----");

			try{
				Item t_item_from = new Item();
				{
					System.Collections.Generic.List<int> t_value_list = new System.Collections.Generic.List<int>();
					t_value_list.Add(1);
					t_value_list.Add(2);
					t_value_list.Add(3);
				
					System.Collections.Generic.Dictionary<string,int> t_value_dictionary = new System.Collections.Generic.Dictionary<string,int>();
					t_value_dictionary.Add("value_4",4);
					t_value_dictionary.Add("value_5",5);
					t_value_dictionary.Add("value_6",6);

					int[] t_value_array = new int[3]; 
					t_value_array[0] = 7;
					t_value_array[1] = 8;
					t_value_array[2] = 9;

					t_item_from.value_bool			= true;
					t_item_from.value_sbyte			= sbyte.MaxValue;
					t_item_from.value_byte			= byte.MaxValue;
					t_item_from.value_short			= short.MaxValue;
					t_item_from.value_ushort		= ushort.MaxValue;
					t_item_from.value_int			= int.MaxValue;
					t_item_from.value_uint			= uint.MaxValue;
					t_item_from.value_long			= long.MaxValue;
					t_item_from.value_ulong			= ulong.MaxValue;
					t_item_from.value_char			= char.MaxValue;
					t_item_from.value_float			= float.MaxValue;
					t_item_from.value_double		= double.MaxValue;
					t_item_from.value_decimal		= decimal.MaxValue;
					t_item_from.value_list			= t_value_list;
					t_item_from.value_dictionary	= t_value_dictionary;
					t_item_from.value_array			= t_value_array;
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

