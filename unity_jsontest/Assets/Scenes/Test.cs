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

		this.StartCoroutine(this.TestCoroutine());
    }

	/** TestCoroutine
	*/
	public System.Collections.IEnumerator TestCoroutine()
	{
		/*
		//最大値。
		Test_01.Main();

		//最小値。
		Test_02.Main();

		//文字１。
		Test_03.Main();

		//文字２。
		Test_04.Main();

		//Enum。
		Test_05.Main();

		//構造体。
		Test_06.Main();

		//Dictionary(key = string)。
		Test_07.Main();

		//List。
		Test_08.Main();

		//Array。
		Test_09.Main();

		//Ignore。
		Test_10.Main();

		//クラスネスト。
		Test_11.Main();

		//構造体ネスト。
		Test_12.Main();
		
		//Listネスト。
		Test_13.Main();

		//Dictionaryネスト。
		Test_14.Main();

		//Arrayネスト。
		Test_15.Main();

		//null処理１。
		Test_16.Main();

		//null処理２。
		Test_17.Main();

		//継承。
		Test_18.Main();

		//IDictionary(key = string)
		Test_19.Main();

		//Stack。
		Test_20.Main();

		//LinkedList。
		Test_21.Main();

		//HashSet。
		Test_22.Main();

		//Queue。
		Test_23.Main();

		//SortedSet。
		Test_24.Main();

		//Enum(要素の文字列処理)。
		Test_25.Main();

		//要素をオブジェクト化できないGeneric。
		Test_99.Main();
		*/

		Test_13.Main();

		yield break;
	}

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
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + ":" + a_to.ToString());
			return false;
		}
		return true;
	}
	/** Check_Sbyte
	*/
	public static bool Check_Sbyte(string a_label,sbyte a_from,sbyte a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + ":" + a_to.ToString());
			return false;
		}
		return true;
	}
	/** Check_Byte
	*/
	public static bool Check_Byte(string a_label,byte a_from,byte a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + ":" + a_to.ToString());
			return false;
		}
		return true;
	}
	/** Check_Short
	*/
	public static bool Check_Short(string a_label,short a_from,short a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + ":" + a_to.ToString());
			return false;
		}
		return true;
	}
	/** Check_Ushort
	*/
	public static bool Check_Ushort(string a_label,ushort a_from,ushort a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + ":" + a_to.ToString());
			return false;
		}
		return true;
	}
	/** Check_Int
	*/
	public static bool Check_Int(string a_label,int a_from,int a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + ":" + a_to.ToString());
			return false;
		}
		return true;
	}
	/** Check_Uint
	*/
	public static bool Check_Uint(string a_label,uint a_from,uint a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + ":" + a_to.ToString());
			return false;
		}
		return true;
	}
	/** Check_Long
	*/
	public static bool Check_Long(string a_label,long a_from,long a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + ":" + a_to.ToString());
			return false;
		}
		return true;
	}
	/** Check_Ulong
	*/
	public static bool Check_Ulong(string a_label,ulong a_from,ulong a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + ":" + a_to.ToString());
			return false;
		}
		return true;
	}
	/** Check_Char
	*/
	public static bool Check_Char(string a_label,char a_from,char a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + ":" + a_to.ToString());
			return false;
		}
		return true;
	}
	/** Check_Float
	*/
	public static bool Check_Float(string a_label,float a_from,float a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + ":" + a_to.ToString());
			return false;
		}
		return true;
	}
	/** Check_Double
	*/
	public static bool Check_Double(string a_label,double a_from,double a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + ":" + a_to.ToString());
			return false;
		}
		return true;
	}
	/** Check_Decimal
	*/
	public static bool Check_Decimal(string a_label,decimal a_from,decimal a_to)
	{
		if(a_from != a_to){
			UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from.ToString() + ":" + a_to.ToString());
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
				UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + "null" + ":" + a_to);
			}else if(a_to == null){
				UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from + ":" + "null");
			}else{
				UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : " + a_from + ":" + a_to);
			}
			return false;
		}
		return true;
	}

	public static bool Check_Enum<T>(string a_label,T a_from,T a_to)
		where T : System.Enum
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
		}

		return true;
	}















	/** 片方だけＮＵＬＬ、サイズが違う。のチェック。
	*/
	public static bool NullSizeCheck(System.Collections.IEnumerable a_list_a,System.Collections.IEnumerable a_list_b)
	{
		if((a_list_a == null)&&(a_list_b == null)){
			//両方NULL。
			return true;
		}else if((a_list_a == null)||(a_list_b == null)){
			//片方だけNULL。
			return false;
		}else{
			System.Collections.IEnumerator t_a = a_list_a.GetEnumerator();
			System.Collections.IEnumerator t_b = a_list_b.GetEnumerator();

			while(true){
				{
					bool t_ret_a = t_a.MoveNext();
					bool t_ret_b = t_b.MoveNext();

					if((t_ret_a == false)&&(t_ret_b == false)){
						break;
					}

					if((t_ret_a == false)||(t_ret_b == false)){
						//片方のリストのサイズが違う。
						return false;
					}
				}

				if((t_a.Current == null)&&(t_b.Current == null)){
					//要素の両方がNULL。
				}else if((t_a.Current == null)||(t_b.Current== null)){
					//要素が片方だけNULL。
					return false;
				}
			}
		}

		return true;
	}

	/** NullSizeCheck_Dictionary
	*/
	public static bool NullSizeCheck_Dictionary<A,B>(System.Collections.Generic.IDictionary<A,B> a_list_a,System.Collections.Generic.IDictionary<A,B> a_list_b)
	{
		if((a_list_a == null)&&(a_list_b == null)){
			//両方NULL。
			return true;
		}else if((a_list_a == null)||(a_list_b == null)){
			//片方だけNULL。
			return false;
		}else{
			if(a_list_a.Count != a_list_b.Count){
				//サイズが違う。
				return false;
			}else{
				foreach(System.Collections.Generic.KeyValuePair<A,B> t_pair_a in a_list_a){
					B t_value_b;
					if(a_list_b.TryGetValue(t_pair_a.Key,out t_value_b) == false){
						//片方にしかキーがない。
						return false;
					}else{
						if((t_pair_a.Value == null)&&(t_value_b == null)){
						}else if((t_pair_a.Value == null)||(t_value_b == null)){
							//片方がNULL。
							return false;
						}
					}
				}
			}
		}

		return true;
	}

	/** NullSizeCheck_HashSet
	*/
	public static bool NullSizeCheck_HashSet<A>(System.Collections.Generic.HashSet<A> a_list_a,System.Collections.Generic.HashSet<A> a_list_b)
	{
		if((a_list_a == null)&&(a_list_b == null)){
			//両方NULL。
			return true;
		}else if((a_list_a == null)||(a_list_b == null)){
			//片方だけNULL。
			return false;
		}else{
			if(a_list_a.Count != a_list_b.Count){
				//サイズが違う。
				return false;
			}else{
				foreach(A t_item_a in a_list_a){
					if(a_list_b.Contains(t_item_a) == false){
						//片方にしかない。
						return false;
					}
				}
			}
		}

		return true;
	}
}

