

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief 文字コンバート。
*/


/** Fee.StringConvert
*/
namespace Fee.StringConvert
{
	/** 特殊文字 ==> JsonItem用エスケープ文字列。

		"\n" ==> "\\n"

	*/
	public class SpecialStringToJsonItemEscapeString
	{
		/** TABLE
		*/
		public readonly static string[] TABLE = new string[0x80]
		{
			null,

			"\\0",	//\0
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,

			"\\n",	//\n
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,

			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,

			null,
			null,
			null,
			null,
			"\\\"",	//ダブルクォーテーション。
			null,
			null,
			null,
			null,
			"\\\'",	//シングルクォーテーション。

			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,

			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,

			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,

			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,

			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,

			null,
			null,	
			"\\\\",	//バックスラッシュ。
			null,
			null,
			null,
			null,
			null,
			null,
			null,

			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,

			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,

			null,
			null,
			null,
			null,
			null,
			null,
			null,
		};
		/** Convert
		*/
		public static string Convert(char a_char)
		{
			var t_code = (
				(
					(a_char + 1) << (
						(
							0x0003 & (
								(a_char >> 14) |
								(a_char >> 12) | 
								(a_char >> 10) | 
								(a_char >> 8) |
								(a_char >> 7)
							)
						) << 3
					)
				) & 0x7F
			);
			return TABLE[t_code];
		}

		/** 遅い。
		*/
		public static void Convert_T(string a_string,int a_offset,System.Text.StringBuilder a_stringbuilder)
		{
			string t_string = Convert(a_string[a_offset]);
			if(t_string != null){
				a_stringbuilder.Append(t_string);
			}else{
				a_stringbuilder.Append(a_string[a_offset]);
			}
		}

		/** Convert
		*/
		public static void Convert(string a_string,int a_offset,System.Text.StringBuilder a_stringbuilder)
		{
			switch(a_string[a_offset]){
			case '\0':
				{
					a_stringbuilder.Append("\\0");
				}break;
			case '\n':
				{
					a_stringbuilder.Append("\\n");
				}break;
			case '\"':
				{
					a_stringbuilder.Append("\\\"");
				}break;
			case '\'':
				{
					a_stringbuilder.Append("\\\'");
				}break;
			case '\\':
				{
					a_stringbuilder.Append("\\\\");
				}break;
			default:
				{
					a_stringbuilder.Append(a_string[a_offset]);
				}break;
			}
		}
	}
}

