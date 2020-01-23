

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
	/** １６進数文字列 ==> Byte。

		"F" ==> 15

	*/
	public class HexStringToByte
	{
		/** TABLE
		*/
		private readonly static byte[] TABLE = new byte[64]{
			0,1,2,3,4,5,6,7,8,9,	//'0' -- '9'

			255,255,255,255,255,255,255,

			10,11,12,13,14,15,		//'A' -- 'F'

			255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,

			10,11,12,13,14,15,		//'a' -- 'f'

			255,255,255,255,255,255,255,255,255
		};

		/** Convert_NoCheck

			(0 - 9 / A - F / a - f)以外のcharが渡された場合、正しく機能しない。

		*/
		public static void Convert_NoCheck(char a_char,out byte a_out_byte)
		{
			a_out_byte = TABLE[(a_char - 48) & 0x3F];
		}

		/** Convert_NoCheck

			(0 - 9 / A - F / a - f)以外のcharが渡された場合、正しく機能しない。

		*/
		public static void Convert_NoCheck(string a_string,int a_offset,out byte a_out_byte)
		{
			Convert_NoCheck(a_string[a_offset],out a_out_byte);
		}

		/** 遅い。
		*/
		public static void Convert_NoCheck_S(string a_string,int a_offset,out byte a_out_byte)
		{
			switch(a_string[a_offset]){
			case '0':a_out_byte = 0;break;
			case '1':a_out_byte = 1;break;
			case '2':a_out_byte = 2;break;
			case '3':a_out_byte = 3;break;
			case '4':a_out_byte = 4;break;
			case '5':a_out_byte = 5;break;
			case '6':a_out_byte = 6;break;
			case '7':a_out_byte = 7;break;
			case '8':a_out_byte = 8;break;
			case '9':a_out_byte = 9;break;
			case 'a':a_out_byte = 10;break;
			case 'A':a_out_byte = 10;break;
			case 'b':a_out_byte = 11;break;
			case 'B':a_out_byte = 11;break;
			case 'c':a_out_byte = 12;break;
			case 'C':a_out_byte = 12;break;
			case 'd':a_out_byte = 13;break;
			case 'D':a_out_byte = 13;break;
			case 'e':a_out_byte = 14;break;
			case 'E':a_out_byte = 14;break;
			case 'f':a_out_byte = 15;break;
			case 'F':a_out_byte = 15;break;
			default:
				{
					a_out_byte = 255;
				}break;
			}
		}
	}
}

