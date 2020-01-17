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

		//Dictionary。
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
		*/

		//継承。
		Test_18.Main();


		yield break;
	}

	/** ToBinaryString
	*/
	public static string ToBinaryString(char a_char)
	{
		return string.Format("{0:X4}",(ushort)a_char);
	}

	/** CharToBinaryString
	*/
	public static string ToBinaryString(char[] a_char_array)
	{
		string t_result = "";

		foreach(char t_char in a_char_array){
			t_result += Test.ToBinaryString(t_char) + " ";
		}

		return t_result;
	}

	/** StringToBinaryString
	*/
	public static string ToBinaryString(string a_string)
	{
		return Test.ToBinaryString(a_string.ToCharArray());
	}

	/** NullCheckDictionary
	*/
	public static bool NullCheckDictionary<A,B>(System.Collections.Generic.Dictionary<A,B> a_list_a,System.Collections.Generic.Dictionary<A,B> a_list_b)
	{
		if((a_list_a == null)&&(a_list_b == null)){
			return true;
		}else if((a_list_a == null)||(a_list_b == null)){
			return false;
		}else{
			if(a_list_a.Count != a_list_b.Count){
				return false;
			}else{
				foreach(System.Collections.Generic.KeyValuePair<A,B> t_pair_a in a_list_a){
					B t_value_b;
					if(a_list_b.TryGetValue(t_pair_a.Key,out t_value_b) == false){
						return false;
					}else{
						if((t_pair_a.Value == null)&&(t_value_b == null)){
						}else if((t_pair_a.Value == null)||(t_value_b == null)){
							return false;
						}
					}
				}
			}
		}
		return true;
	}

	/** NullCheckList
	*/
	public static bool NullCheckList<A>(System.Collections.Generic.List<A> a_list_a,System.Collections.Generic.List<A> a_list_b)
	{
		if((a_list_a == null)&&(a_list_b == null)){
			return true;
		}else if((a_list_a == null)||(a_list_b == null)){
			return false;
		}else{
			if(a_list_a.Count != a_list_b.Count){
				return false;
			}else{
				for(int ii=0;ii<a_list_a.Count;ii++){
					if((a_list_a[ii] == null)&&(a_list_b[ii] == null)){
					}else if((a_list_a[ii] == null)||(a_list_b[ii] == null)){
						return false;
					}
				}
			}
		}
		return true;
	}

	/** NullCheckArray
	*/
	public static bool NullCheckArray<A>(A[] a_list_a,A[] a_list_b)
	{
		if((a_list_a == null)&&(a_list_b == null)){
			return true;
		}else if((a_list_a == null)||(a_list_b == null)){
			return false;
		}else{
			if(a_list_a.Length != a_list_b.Length){
				return false;
			}else{
				for(int ii=0;ii<a_list_a.Length;ii++){
					if((a_list_a[ii] == null)&&(a_list_b[ii] == null)){
					}else if((a_list_a[ii] == null)||(a_list_b[ii] == null)){
						return false;
					}
				}
			}
		}
		return true;
	}
}

