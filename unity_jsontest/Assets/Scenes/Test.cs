using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Test
*/
public class Test : MonoBehaviour
{
	/** Start
	*/
    void Start()
    {
		Fee.ReflectionTool.Config.LOG_ENABLE = true;
		Fee.ReflectionTool.ReflectionTool.CreateInstance();

		Test_AB();
    }

	/** TestCoroutine
	*/
	public System.Collections.IEnumerator TestCoroutine()
	{
		Test_01.Main();
		Test_02.Main();
		Test_03.Main();
		Test_04.Main();
		Test_05.Main();
		Test_06.Main();
		Test_07.Main();
		Test_08.Main();
		Test_09.Main();
		Test_10.Main();
		Test_11.Main();
		Test_12.Main();
		Test_13.Main();
		Test_14.Main();
		Test_15.Main();
		Test_16.Main();
		Test_17.Main();
		Test_18.Main();
		Test_19.Main();
		Test_20.Main();
		Test_21.Main();
		Test_22.Main();
		Test_23.Main();
		Test_24.Main();
		Test_25.Main();
		Test_26.Main();

		yield break;
	}

	/** CreateString
	*/
	public static string CreateString()
	{
		/*
		string[] t_list = new string[]{
			"0",
			"1",
			"2",
			"3",
			"4",
			"5",
			"6",
			"7",
			"8",
			"9",
			"A",
			"B",
			"C",
			"D",
			"E",
			"F",
		};
		*/
		string[] t_list = new string[]{
			"\n",
			"\0",
			"\"",
			"\'",
			"\n",
			"\\",
			"a",
			"あ",
			"\t",
		};

		string t_string = "";
		for(int xx=0;xx<1000;xx++){
		for(int ii=0;ii<t_list.Length;ii++){
			t_string += t_list[ii];
		}
		}
		return t_string;
	}

	public static void Test_AB()
	{
		string t_string = CreateString();

		Test_A(t_string);
		Test_S(t_string);
	}

	public static void Test_A(string a_string)
	{
		//byte t_byte = 0;
		System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();

		{
			float t_time_start = Time.realtimeSinceStartup;

			for(int xx=0;xx<1000;xx++){
				for(int ii=0;ii<a_string.Length;ii++){
					/*
					byte t_out_byte;
					Fee.StringConvert.HexStringToByte.Convert_NoCheck(a_string,ii,out t_out_byte);
					t_byte += t_out_byte;
					*/

					Fee.StringConvert.SpecialStringToJsonItemEscapeString.Convert_T(a_string,ii,t_stringbuilder);
				}
			}

			float t_time_end = Time.realtimeSinceStartup;

			//UnityEngine.Debug.Log((t_time_end - t_time_start).ToString("0.0000") + " : " + t_byte.ToString());
			UnityEngine.Debug.Log((t_time_end - t_time_start).ToString("0.0000") + " : " + t_stringbuilder.ToString());}
	}

	public static void Test_S(string a_string)
	{
		//byte t_byte = 0;
		System.Text.StringBuilder t_stringbuilder = new System.Text.StringBuilder();

		{
			float t_time_start = Time.realtimeSinceStartup;

			for(int xx=0;xx<1000;xx++){
				for(int ii=0;ii<a_string.Length;ii++){
					/*
					byte t_out_byte;
					Fee.StringConvert.HexStringToByte.Convert_NoCheck_S(a_string,ii,out t_out_byte);
					t_byte += t_out_byte;
					*/
					Fee.StringConvert.SpecialStringToJsonItemEscapeString.Convert(a_string,ii,t_stringbuilder);
				}
			}

			float t_time_end = Time.realtimeSinceStartup;

			//UnityEngine.Debug.Log((t_time_end - t_time_start).ToString("0.0000") + " : " + t_byte.ToString());
			UnityEngine.Debug.Log((t_time_end - t_time_start).ToString("0.0000") + " : " + t_stringbuilder.ToString());
		}
	}

	/** CallBack_Check
	*/
	public delegate bool CallBack_Check<T>(string a_label,in T a_from,in T a_to);

	/** バイト配列文字列。
	*/
	public static string ToBinaryString(char a_char)
	{
		return string.Format("{0:X4}",(ushort)a_char);
	}

	/** バイト配列文字列。
	*/
	public static string ToBinaryString(char[] a_char_array)
	{
		string t_result = "";

		foreach(char t_char in a_char_array){
			t_result += Test.ToBinaryString(t_char) + " ";
		}

		return t_result;
	}

	/** バイト配列文字列。
	*/
	public static string ToBinaryString(string a_string)
	{
		return Test.ToBinaryString(a_string.ToCharArray());
	}

	/** Check_Bool
	*/
	public static bool Check_Bool(string a_label,bool a_from,bool a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + " => " + a_to.ToString());
			return false;
		}
		return true;
	}

	/** Check_Sbyte
	*/
	public static bool Check_Sbyte(string a_label,sbyte a_from,sbyte a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + " => " + a_to.ToString());
			return false;
		}
		return true;
	}

	/** Check_Byte
	*/
	public static bool Check_Byte(string a_label,byte a_from,byte a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + " => " + a_to.ToString());
			return false;
		}
		return true;
	}

	/** Check_Short
	*/
	public static bool Check_Short(string a_label,short a_from,short a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + " => " + a_to.ToString());
			return false;
		}
		return true;
	}

	/** Check_Ushort
	*/
	public static bool Check_Ushort(string a_label,ushort a_from,ushort a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + " => " + a_to.ToString());
			return false;
		}
		return true;
	}

	/** Check_Int
	*/
	public static bool Check_Int(string a_label,int a_from,int a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + " => " + a_to.ToString());
			return false;
		}
		return true;
	}

	/** Check_Uint
	*/
	public static bool Check_Uint(string a_label,uint a_from,uint a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + " => " + a_to.ToString());
			return false;
		}
		return true;
	}

	/** Check_Long
	*/
	public static bool Check_Long(string a_label,long a_from,long a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + " => " + a_to.ToString());
			return false;
		}
		return true;
	}

	/** Check_Ulong
	*/
	public static bool Check_Ulong(string a_label,ulong a_from,ulong a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + " => " + a_to.ToString());
			return false;
		}
		return true;
	}

	/** Check_Char
	*/
	public static bool Check_Char(string a_label,char a_from,char a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + " => " + a_to.ToString());
			return false;
		}
		return true;
	}

	/** Check_Float
	*/
	public static bool Check_Float(string a_label,float a_from,float a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + " => " + a_to.ToString());
			return false;
		}
		return true;
	}

	/** Check_Double
	*/
	public static bool Check_Double(string a_label,double a_from,double a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + " => " + a_to.ToString());
			return false;
		}
		return true;
	}

	/** Check_Decimal
	*/
	public static bool Check_Decimal(string a_label,decimal a_from,decimal a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + " => " + a_to.ToString());
			return false;
		}
		return true;
	}

	/** Check_String
	*/
	public static bool Check_String(string a_label,string a_from,string a_to)
	{
		if(a_from != a_to){
			if(a_from == null){
				UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + "null" + " => " + a_to);
			}else if(a_to == null){
				UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from + " => " + "null");
			}else{
				UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from + " => " + a_to);
			}
			return false;
		}
		return true;
	}

	/** Check_Enum
	*/
	public static bool Check_Enum(string a_label,System.Enum a_from,System.Enum a_to)
	{
		switch(a_from.GetTypeCode()){
		case System.TypeCode.Byte:
			{
				return Check_Byte(a_label,(byte)((System.Object)a_from),(byte)((System.Object)a_to));
			}//break;
		case System.TypeCode.SByte:
			{
				return Check_Sbyte(a_label,(sbyte)((System.Object)a_from),(sbyte)((System.Object)a_to));
			}//break;
		case System.TypeCode.Int16:
			{
				return Check_Short(a_label,(short)((System.Object)a_from),(short)((System.Object)a_to));
			}//break;
		case System.TypeCode.UInt16:
			{
				return Check_Ushort(a_label,(ushort)((System.Object)a_from),(ushort)((System.Object)a_to));
			}//break;
		case System.TypeCode.Int32:
			{
				return Check_Int(a_label,(int)((System.Object)a_from),(int)((System.Object)a_to));
			}//break;
		case System.TypeCode.UInt32:
			{
				return Check_Uint(a_label,(uint)((System.Object)a_from),(uint)((System.Object)a_to));
			}//break;
		case System.TypeCode.Int64:
			{
				return Check_Long(a_label,(long)((System.Object)a_from),(long)((System.Object)a_to));
			}//break;
		case System.TypeCode.UInt64:
			{
				return Check_Ulong(a_label,(ulong)((System.Object)a_from),(ulong)((System.Object)a_to));
			}//break;
		default:
			{
				UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : unknown");
			}break;
		}

		return true;
	}

	/** Check_Dictionary
	*/
	public static bool Check_Dictionary<K,T>(string a_label,System.Collections.Generic.IDictionary<K,T> a_from,System.Collections.Generic.IDictionary<K,T> a_to,CallBack_Check<T> a_callback)
	{
		if((a_from == null)&&(a_to == null)){
			return true;
		}else if(a_from == null){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : from == null");
			return false;
		}else if(a_to == null){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : to == null");
			return false;
		}

		bool t_result = true;

		if(a_from.Count != a_to.Count){
			//サイズが違う。
			t_result = false;
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : counterror");
		}else{
			foreach(System.Collections.Generic.KeyValuePair<K,T> t_from_pair in a_from){
				T t_to_value;
				if(a_to.TryGetValue(t_from_pair.Key,out t_to_value) == false){
					//存在しない。
					t_result = false;
					UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : notexist");
					break;
				}else{
					T t_from_value = t_from_pair.Value;
					if(a_callback(a_label,in t_from_value,in t_to_value) == false){
						t_result = false;
					}
				}
			}
		}

		return t_result;
	}

	/** Check_Enumerator
	*/
	public static bool Check_Enumerator<T>(string a_label,System.Collections.IEnumerable a_from,System.Collections.IEnumerable a_to,CallBack_Check<T> a_callback)
	{
		if((a_from == null)&&(a_to == null)){
			return true;
		}else if(a_from == null){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : from == null");
			return false;
		}else if(a_to == null){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : to == null");
			return false;
		}

		bool t_result = true;

		System.Collections.IEnumerator t_from = a_from.GetEnumerator();
		System.Collections.IEnumerator t_to = a_to.GetEnumerator();

		int t_index = 0;
		while(true){
			{
				if(t_from != null){
					if(t_from.MoveNext() == false){
						t_from = null;
					}
				}
				if(t_to != null){
					if(t_to.MoveNext() == false){
						t_to = null;
					}
				}
				if((t_from == null)&&(t_to == null)){
					break;
				}
			}

			if(t_from == null){
				//サイズが違う。
				t_result = false;
				UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : counterror");
				break;
			}else if(t_to == null){
				//サイズが違う。
				t_result = false;
				UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : counterror");
				break;
			}else{
				T t_from_value = (T)t_from.Current;
				T t_to_value = (T)t_to.Current;
				if(a_callback(a_label,in t_from_value,in t_to_value) == false){
					t_result = false;
					break;
				}
			}

			t_index++;
		}

		return t_result;
	}

	/** Check_HashSet
	*/
	public static bool Check_HashSet<T>(string a_label,System.Collections.Generic.HashSet<T> a_from,System.Collections.Generic.HashSet<T> a_to)
	{
		if((a_from == null)&&(a_to == null)){
			return true;
		}else if(a_from == null){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : from == null");
			return false;
		}else if(a_to == null){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : to == null");
			return false;
		}

		bool t_result = true;

		if(a_from.Count != a_to.Count){
			//サイズが違う。
			t_result = false;
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : counterror");
		}

		foreach(T t_from_value in a_from){
			if(a_to.Contains(t_from_value) == false){
				//存在しない。
				t_result = false;
				UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : notexist");
				break;
			}
		}

		return t_result;
	}

	/** どちらかがＮＵＬＬのオブジェクトのチェック。
	*/
	public static bool Check_NullObject(string a_label,System.Object a_from,System.Object a_to)
	{
		if((a_from == null)&&(a_to == null)){
			//両方ＮＵＬＬ。
			return true;
		}else if(a_from == null){
			//ＦＲＯＭがＮＵＬＬ。
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + "null");
			return false;
		}else if(a_to == null){
			//ＴＯがＮＵＬＬ。
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + "null");
			return false;
		}

		UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : unknown");
		return false;
	}
}

