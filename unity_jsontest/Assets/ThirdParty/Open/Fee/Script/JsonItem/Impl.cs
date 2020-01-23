

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief ＪＳＯＮ。実装。
*/


/** Unreachable code detected.
*/
#pragma warning disable 0162


/** Fee.JsonItem
*/
namespace Fee.JsonItem
{
	/** Impl
	*/
	public class Impl
	{
		public static char[] STRING_FALSE_1 = {'F','A','L','S','E'};
		public static char[] STRING_FALSE_2 = {'f','a','l','s','e'};
		public static char[] STRING_TRUE_1 = {'T','R','U','E'};
		public static char[] STRING_TRUE_2 = {'t','r','u','e'};
		public static char[] STRING_NULL_1 = {'n','u','l','l'};
		public static char[] STRING_NULL_2 = {'N','U','L','L'};

		/** 最初の一文字からタイプを推測。
		*/
		public static ValueType GetValueTypeFromChar(char a_char)
		{
			switch(a_char){
			case '"':
			case '\'':
				{
					return ValueType.StringData;
				}break;
			case '{':
				{
					return ValueType.AssociativeArray;
				}break;
			case '[':
				{
					return ValueType.IndexArray;
				}break;
			case '<':
				{
					return ValueType.BinaryData;
				}break;
			case 't':
			case 'T':
				{
					return ValueType.Calc_BoolDataTrue;
				}break;
			case 'f':
			case 'F':
				{
					return ValueType.Calc_BoolDataFalse;
				}break;
			case '-':
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				{
					return ValueType.Calc_UnknownNumber;
				}break;
			case 'n':
				{
					return ValueType.Null;
				}break;
			default:
				{
					//不明な開始文字。
					Tool.Assert(false);

					return ValueType.Null;
				}break;
			}
		}

		/** 整数チェック。

			System.Text.RegularExpressions.Regex.IsMatch(a_string,"^[\\+\\-]?[0-9]+\\.[0-9]+$");

		*/
		public static bool IsFloat(string a_string)
		{
			for(int ii=0;ii<a_string.Length;ii++){
				if(a_string[ii] == Config.FLOATING_SEPARATOR){
					return true;
				}
			}
			return false;
		}

		/** 特殊文字 ==> ＪＳＯＮ文字列。
		*/
		public static void ConvertSpecialStringToJsonString(string a_string,System.Text.StringBuilder a_stringbuilder)
		{
			if(a_string != null){
				for(int ii=0;ii<a_string.Length;ii++){
					StringConvert.SpecialStringToJsonItemEscapeString.Convert(a_string,ii,a_stringbuilder);
				}
			}else{
				Tool.Assert(false);
			}
		}

		/** ＪＳＯＮ文字列 ==> 特殊文字。
		*/
		public static void ConvertJsonStringToSpecialString(string a_string,int a_index_start,int a_index_end,System.Text.StringBuilder a_stringbuilder)
		{
			int t_index = a_index_start;

			while(t_index <= a_index_end){
				if(a_string[t_index] == '\\'){
					if((t_index + 1) < a_string.Length){
						int t_use_index = StringConvert.EscapeCodeStringToSpecialString.Convert(a_string,t_index + 1,a_stringbuilder);
						Tool.Assert(t_index > 0);
					}
				}else{
					//そのまま。
					a_stringbuilder.Append(a_string[t_index]);
					t_index++;
				}
			}
		}

		/** GetCharLength
		*/
		public static int GetCharLength(string a_string,int a_index)
		{
			if(a_index < a_string.Length){
				if(a_string[a_index] == '\\'){
					if((a_index + 1) < a_string.Length){
						switch(a_string[a_index + 1]){
						case 'u':
							{
								if((a_index + 5) < a_string.Length){
									//ＵＴＦ１６。

									//\u0000
									return 6;
								}else{
									//後ろにコードがあるはずだった。
									Tool.Assert(false);
									return a_string.Length - a_index;
								}
							}
						default:
							{
								//それ以外。
							}return 2;
						}
					}else{
						//「\\」の後ろがない。
						Tool.Assert(false);
						return 1;
					}
				}else{
					//通常文字。
					return 1;
				}
			}else{
				//範囲外。
				Tool.Assert(false);
				return 0;
			}
		}

		/** 文字列JSONの長さ。
		*/
		public static int GetLength_StringData(string a_string,int a_index)
		{
			int t_index = a_index;

			if(t_index < a_string.Length){
				if((a_string[t_index] == '"')||(a_string[t_index] == '\'')){
					t_index++;
					while(t_index < a_string.Length){
						if((a_string[t_index] == '"')||(a_string[t_index] == '\'')){
							//終端。
							return t_index - a_index + 1;
						}else{
							//次の文字へ。
							int t_use_index = Impl.GetCharLength(a_string,t_index);
							if(t_use_index > 0){
								t_index += t_use_index;
							}else{
								//予想外の文字コード。
								Tool.Assert(false);

								return 0;
							}
						}
					}
				
					//予想外の終端。
					Tool.Assert(false);

					return 0;
				}else{
					//文字列以外。
					Tool.Assert(false);

					return 0;
				}
			}else{
				//範囲外。
				Tool.Assert(false);

				return 0;
			}
		}

		/** 数字JSONの長さ。
		*/
		public static int GetLength_Number(string a_string,int a_index)
		{
			if(a_index < a_string.Length){
				int t_index = a_index;
				while(a_index < a_string.Length){
					switch(a_string[t_index]){
					case '}':
					case ']':
					case ',':
						{
							//終端。
							return t_index - a_index;
						}//break;
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
					case '.':
					case '+':
					case '-':
					case 'e':
					case 'E':
						{
							//数値。
							t_index++;
						}break;
					default:
						{
							//不明。
							Tool.Assert(false);

							return 0;
						}//break;	
					}
				}
			
				//終端。
				return t_index - a_index;
			}else{
				//範囲外。
				Tool.Assert(false);

				return 0;
			}
		}

		/** 連想リストJSONの長さ。
		*/
		public static int GetLength_AssociateArray(string a_string,int a_index)
		{
			if(a_index < a_string.Length){
				if(a_string[a_index] == '{'){
					int t_nest = 1;
					int t_index = a_index + 1;
				
					while(t_index < a_string.Length){
						if(a_string[t_index] == '}'){
							if(t_nest <= 1){
								//終端。
								return t_index - a_index + 1;
							}else{
								//ネスト。
								t_nest--;
								t_index++;
							}
						}else if(a_string[t_index] == '{'){
							//ネスト。
							t_nest++;
							t_index++;
						}else if((a_string[t_index] == '"')||(a_string[t_index] == '\'')){
							//文字列。
							int t_add = GetLength_StringData(a_string,t_index);
							if(t_add > 0){
								t_index += t_add;
							}else{
								//予想外の文字コード。
								Tool.Assert(false);

								return 0;
							}
						}else{
							//次へ。
							t_index++;
						}
					}
				
					//終端がない。
					Tool.Assert(false);

					return 0;
				}else{
					//連想配列以外。
					Tool.Assert(false);

					return 0;
				}
			}else{
				//範囲外。
				Tool.Assert(false);

				return 0;
			}
		}

		/** インデックスリストJSONの長さ。
		*/
		public static int GetLength_IndexArray(string a_string,int a_index)
		{
			if(a_index < a_string.Length){
				if(a_string[a_index] == '['){
					int t_nest = 1;
					int t_index = a_index + 1;
				
					while(t_index < a_string.Length){
						if(a_string[t_index] == ']'){
							if(t_nest <= 1){
								//終端。
								return t_index - a_index + 1;
							}else{
								//ネスト。
								t_nest--;
								t_index++;
							}
						}else if(a_string[t_index] == '['){
							//ネスト。
							t_nest++;
							t_index++;
						}else if((a_string[t_index] == '"')||(a_string[t_index] == '\'')){
							//文字列。
							int t_add = GetLength_StringData(a_string,t_index);
							if(t_add > 0){
								t_index += t_add;
							}else{
								//予想外の文字コード。
								Tool.Assert(false);

								return 0;
							}
						}else{
							//次へ。
							t_index++;
						}
					}
				
					//終端がない。
					Tool.Assert(false);

					return 0;	
				}else{
					//配列以外。
					Tool.Assert(false);

					return 0;
				}
			}else{
				//範囲外。
				Tool.Assert(false);

				return 0;
			}
		}

		/** TRUEJSONの長さ。
		*/
		public static int GetLength_BoolTrue(string a_string,int a_index)
		{

			for(int ii=0;ii<STRING_TRUE_1.Length;ii++){
				int t_index = a_index + ii;

				if(t_index < a_string.Length){
					if((a_string[t_index] == STRING_TRUE_1[ii])||(a_string[t_index] == STRING_TRUE_2[ii])){
					}else{
						//TRUE以外。
						Tool.Assert(false);
						
						return 0;
					}
				}else{
					//TRUE以外。
					Tool.Assert(false);

					return 0;
				}
			}

			{
				int t_index = a_index + STRING_TRUE_1.Length;

				if(t_index < a_string.Length){
					if((a_string[t_index] == '}')||(a_string[t_index] == ']')||(a_string[t_index] == ',')){
						//終端。
						return STRING_TRUE_1.Length;
					}else{
						//TRUE以外。
						Tool.Assert(false);

						return 0;					
					}
				}else{
					//TRUE以外。
					Tool.Assert(false);

					return 0;
				}
			}
		}

		/** FALSEJSONの長さ。
		*/
		public static int GetLength_BoolFalse(string a_string,int a_index)
		{
			for(int ii=0;ii<STRING_FALSE_1.Length;ii++){
				int t_index = a_index + ii;

				if(t_index < a_string.Length){
					if((a_string[t_index] == STRING_FALSE_1[ii])||(a_string[t_index] == STRING_FALSE_2[ii])){
					}else{
						//FALSE以外。
						Tool.Assert(false);
						
						return 0;
					}
				}else{
					//FALSE以外。
					Tool.Assert(false);

					return 0;
				}
			}

			{
				int t_index = a_index + STRING_FALSE_1.Length;

				if(t_index < a_string.Length){
					if((a_string[t_index] == '}')||(a_string[t_index] == ']')||(a_string[t_index] == ',')){
						//終端。
						return STRING_FALSE_1.Length;
					}else{
						//FALSE以外。
						Tool.Assert(false);

						return 0;					
					}
				}else{
					//FALSE以外。
					Tool.Assert(false);

					return 0;
				}
			}
		}

		/** BinaryDataの長さ。
		*/
		public static int GetLength_BinaryData(string a_string,int a_index)
		{
			if(a_index < a_string.Length){
				if(a_string[a_index] == '<'){
					int t_index = a_index + 1;
					while(t_index < a_string.Length){
						switch(a_string[t_index]){
						case '>':
							{
								//終端。
								return t_index - a_index + 1;
							}//break;
						case '0':
						case '1':
						case '2':
						case '3':
						case '4':
						case '5':
						case '6':
						case '7':
						case '8':
						case '9':
						case 'a':
						case 'A':
						case 'b':
						case 'B':
						case 'c':
						case 'C':
						case 'd':
						case 'D':
						case 'e':
						case 'E':
						case 'f':
						case 'F':
							{
								//次へ。
								t_index++;
							}break;
						default:
							{
								//不明。
								Tool.Assert(false);

								return 0;
							}//break;
						}
					}
				
					//終端がない。
					Tool.Assert(false);

					return 0;	
				}else{
					//バイナリデータ以外。
					Tool.Assert(false);

					return 0;
				}
			}else{
				//範囲外。
				Tool.Assert(false);

				return 0;
			}
		}

		/** NULLJSONの長さ。
		*/
		public static int GetLength_Null(string a_string,int a_index)
		{
			for(int ii=0;ii<STRING_NULL_1.Length;ii++){
				int t_index = a_index + ii;

				if(t_index < a_string.Length){
					if((a_string[t_index] == STRING_NULL_1[ii])||(a_string[t_index] == STRING_NULL_2[ii])){
					}else{
						//null以外。
						Tool.Assert(false);
						
						return 0;
					}
				}else{
					//null以外。
					Tool.Assert(false);

					return 0;
				}
			}

			{
				int t_index = a_index + STRING_NULL_1.Length;

				if(t_index < a_string.Length){
					if((a_string[t_index] == '}')||(a_string[t_index] == ']')||(a_string[t_index] == ',')){
						//終端。
						return STRING_NULL_1.Length;
					}else{
						//null以外。
						Tool.Assert(false);

						return 0;					
					}
				}else{
					return STRING_NULL_1.Length;
				}
			}
		}

		/** JSON文字からインデックスリストの作成[*,*,*]。
		*/
		public static void CreateIndexArrayFromJsonString(string a_jsonstring,ref System.Collections.Generic.List<JsonItem> a_out_list)
		{
			int t_index = 0;
			while(t_index < a_jsonstring.Length){
				if(a_jsonstring[t_index] == ']'){
					//終端。
					Tool.Assert(t_index + 1 == a_jsonstring.Length);
					return;
				}else if(a_jsonstring[t_index] == ','){
					//次の項目あり。
					t_index++;
				}else if(a_jsonstring[t_index] == '['){
					if(t_index == 0){
						//開始。
						t_index++;
						continue;
					}else if(t_index == 1){
						//インデックスリストの中にインデックスリスト。
					}else{
						//不明。
						Tool.Assert(false);
						return;
					}
				}
		
				//値。
				int t_value_size = 0;
				switch(GetValueTypeFromChar(a_jsonstring[t_index])){
				case ValueType.StringData:
					{
						t_value_size = GetLength_StringData(a_jsonstring,t_index);
					}break;
				case ValueType.Calc_UnknownNumber:
				case ValueType.SignedNumber:
				case ValueType.UnsignedNumber:
				case ValueType.FloatingNumber:
					{
						t_value_size = GetLength_Number(a_jsonstring,t_index);
					}break;
				case ValueType.AssociativeArray:
					{
						t_value_size = GetLength_AssociateArray(a_jsonstring,t_index);
					}break;
				case ValueType.IndexArray:
					{
						t_value_size = GetLength_IndexArray(a_jsonstring,t_index);
					}break;
				case ValueType.Calc_BoolDataTrue:
					{
						t_value_size = GetLength_BoolTrue(a_jsonstring,t_index);
					}break;
				case ValueType.Calc_BoolDataFalse:
					{
						t_value_size = GetLength_BoolFalse(a_jsonstring,t_index);
					}break;
				case ValueType.BinaryData:
					{
						t_value_size = GetLength_BinaryData(a_jsonstring,t_index);
					}break;
				case ValueType.Null:
					{
						t_value_size = GetLength_Null(a_jsonstring,t_index);
					}break;
				default:
					{
						//不明。
						Tool.Assert(false);
						return;
					}//break;
				}
			
				//リストの最後に追加。
				if(t_value_size > 0){

					JsonItem t_additem = new JsonItem();

					{
						t_additem.SetJsonString(a_jsonstring.Substring(t_index,t_value_size));
					}

					a_out_list.Add(t_additem);

					t_index += t_value_size;
				}else{
					Tool.Assert(false);
					return;
				}
			}
		
			//不明。
			Tool.Assert(false);
			return;
		}

		/** JSON文字から連想配列の作成。
		*/
		public static void CreateAssociativeArrayFromJsonString(string a_jsonstring,ref System.Collections.Generic.Dictionary<string,JsonItem> a_out_list)
		{
			int t_index = 0;
			while(t_index < a_jsonstring.Length){
				if(a_jsonstring[t_index] == '}'){
					//終端。
					Tool.Assert((t_index + 1) == a_jsonstring.Length);

					return;
				}else if(a_jsonstring[t_index] == ','){
					//次の項目あり。
					t_index++;
				}else if(a_jsonstring[t_index] == '{'){
					if(t_index == 0){
						//開始。
						t_index++;
						continue;
					}else{
						//不明。
						Tool.Assert(false);
						return;
					}
				}
			
				//名前。
				string t_name_string;
				if((a_jsonstring[t_index] == '"')||(a_jsonstring[t_index] == '\'')){
					int t_name_size = GetLength_StringData(a_jsonstring,t_index);
					if(t_name_size >= 2){
						t_name_string = a_jsonstring.Substring(t_index + 1,t_name_size - 2);
						t_index += t_name_size;
					}else{
						//不明。
						Tool.Assert(false);
						return;
					}
				}else{
					//不明。
					Tool.Assert(false);
					return;
				}
			
				//「:」。
				if(a_jsonstring[t_index] == ':'){
					t_index++;
				}else{
					//不明。
					Tool.Assert(false);
					return;
				}
			
				//値。
				int t_value_size = 0;
				switch(GetValueTypeFromChar(a_jsonstring[t_index])){
				case ValueType.StringData:
					{
						t_value_size = GetLength_StringData(a_jsonstring,t_index);
					}break;
				case ValueType.Calc_UnknownNumber:
				case ValueType.SignedNumber:
				case ValueType.UnsignedNumber:
				case ValueType.FloatingNumber:
					{
						t_value_size = GetLength_Number(a_jsonstring,t_index);
					}break;
				case ValueType.AssociativeArray:
					{
						t_value_size = GetLength_AssociateArray(a_jsonstring,t_index);
					}break;
				case ValueType.IndexArray:
					{
						t_value_size = GetLength_IndexArray(a_jsonstring,t_index);
					}break;
				case ValueType.Calc_BoolDataTrue:
					{
						t_value_size = GetLength_BoolTrue(a_jsonstring,t_index);
					}break;
				case ValueType.Calc_BoolDataFalse:
					{
						t_value_size = GetLength_BoolFalse(a_jsonstring,t_index);
					}break;
				case ValueType.BinaryData:
					{
						t_value_size = GetLength_BinaryData(a_jsonstring,t_index);
					}break;
				case ValueType.Null:
					{
						t_value_size = GetLength_Null(a_jsonstring,t_index);
					}break;
				case ValueType.BoolData:
				default:
					{
						//不明。
						Tool.Assert(false);
						return;
					}//break;
				}
			
				//リストに追加。
				if(t_value_size > 0){

					JsonItem t_additem = new JsonItem();

					{
						t_additem.SetJsonString(a_jsonstring.Substring(t_index,t_value_size));
					}

					a_out_list.Add(t_name_string,t_additem);

					t_index += t_value_size;
				}else{
					Tool.Assert(false);
					return;
				}
			}
		
			//不明。
			Tool.Assert(false);
			return;
		}

		/** JSON文字からバイナリデータの作成。
		*/
		public static void CreateBinaryDataFromJsonString(string a_jsonstring,ref System.Collections.Generic.List<byte> a_out_list)
		{
			int t_index = 0;
			while(t_index < a_jsonstring.Length){
				if(a_jsonstring[t_index] == '>'){
					//終端。
					Tool.Assert((t_index + 1) == a_jsonstring.Length);
					return;
				}else if(a_jsonstring[t_index] == '<'){
					if(t_index == 0){
						//開始。
						t_index++;
						continue;
					}else{
						//不明。
						Tool.Assert(false);
						return;
					}
				}else{

					if(t_index + 1 < a_jsonstring.Length){

						byte t_binary_1;
						byte t_binary_2;
						Fee.StringConvert.HexStringToByte.Convert_NoCheck(a_jsonstring[t_index + 0],out t_binary_1);
						Fee.StringConvert.HexStringToByte.Convert_NoCheck(a_jsonstring[t_index + 1],out t_binary_2);

						byte t_binary = (byte)(t_binary_1 << 8 | t_binary_2);
						a_out_list.Add(t_binary);

						t_index += 2;
					}else{
						//不明。
						Tool.Assert(false);
						return;

					}
				}
			}

			//範囲外。
			Tool.Assert(false);
			return;
		}

	}
}

