﻿

/** Simple
*/
namespace Simple
{
	/** Simple
	*/
	public class Simple : UnityEngine.MonoBehaviour
	{
		/** Start
		*/
		void Start()
		{
			Fee.ReflectionTool.Config.LOG_ENABLE = true;
		
			Fee.JsonItem.Config.LOG_ENABLE = true;
			Fee.JsonItem.Config.DEFAULT_CONVERTTOJSONSTRING_OPTION = Fee.JsonItem.ConvertToJsonStringOption.NoFloatingNumberSuffix | Fee.JsonItem.ConvertToJsonStringOption.NoSignedNumberSuffix | Fee.JsonItem.ConvertToJsonStringOption.NoUnsignedNumberSuffix;

			this.StartCoroutine(this.TestCoroutine());
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
			Test_27.Main();
			Test_28.Main();

			Test_99.Main();

			yield break;
		}

		/** CallBack_Check
		*/
		public delegate bool CallBack_Check<T,U>(string a_label,int a_index,in T a_from,in U a_to);

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
		public static bool Check_Dictionary<K,VA,VB>(string a_label,System.Collections.Generic.IDictionary<K,VA> a_from,System.Collections.Generic.IDictionary<K,VB> a_to,CallBack_Check<VA,VB> a_callback)
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
				foreach(System.Collections.Generic.KeyValuePair<K,VA> t_from_pair in a_from){
					VB t_to_value;
					if(a_to.TryGetValue(t_from_pair.Key,out t_to_value) == false){
						//存在しない。
						t_result = false;
						UnityEngine.Debug.LogWarning("mismatch : " + a_label + " : notexist");
						break;
					}else{
						VA t_from_value = t_from_pair.Value;
						if(a_callback(a_label,-1,in t_from_value,in t_to_value) == false){
							t_result = false;
						}
					}
				}
			}

			return t_result;
		}

		/** Check_Enumerator
		*/
		public static bool Check_Enumerator<T,U>(string a_label,System.Collections.IEnumerable a_from,System.Collections.IEnumerable a_to,CallBack_Check<T,U> a_callback)
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
					U t_to_value = (U)t_to.Current;
					if(a_callback(a_label,t_index,in t_from_value,in t_to_value) == false){
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
}

