

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief ＪＳＯＮ。ＪＳＯＮ化。
*/


/** Fee.JsonItem
*/
namespace Fee.JsonItem
{
	/** ObjectToJson_SystemObject
	*/
	public class ObjectToJson_SystemObject
	{
		/** Convert
		*/
		public static JsonItem Convert(System.Object a_instance,ObjectToJson_Work.ObjectOption a_objectoption,int a_nest,System.Collections.Generic.List<ObjectToJson_Work> a_workpool = null)
		{
			int t_nest = a_nest + 1;
			if(t_nest >= 5){
				Tool.LogError("ObjectToJson_SystemObject","nest = " + t_nest.ToString());
			}

			System.Collections.Generic.List<ObjectToJson_Work> t_workpool = a_workpool;

			if(t_workpool == null){
				t_workpool = new System.Collections.Generic.List<ObjectToJson_Work>();				
			}

			JsonItem t_return = null;
			bool t_search_member = false;

			if(a_instance != null){
				System.Type t_type = a_instance.GetType();

				if(t_type == typeof(int)){
					//20:int
					int t_value_raw = (int)a_instance;
					t_return = new JsonItem(new Value_Number<int>(t_value_raw));
				}else if(t_type == typeof(float)){
					//13:float
					float t_value_raw = (float)a_instance;
					t_return = new JsonItem(new Value_Number<float>(t_value_raw));
				}else if(t_type == typeof(bool)){
					//11:bool
					bool t_value_raw = (bool)a_instance;
					t_return = new JsonItem(new Value_Number<bool>(t_value_raw));
				}else if(t_type == typeof(long)){
					//22:long
					long t_value_raw = (long)a_instance;
					t_return = new JsonItem(new Value_Number<long>(t_value_raw));
				}else if(t_type == typeof(char)){
					//12:char
					char t_value_raw = (char)a_instance;
					t_return = new JsonItem(new Value_Number<char>(t_value_raw));
				}else if(t_type == typeof(double)){
					//14:double
					double t_value_raw = (double)a_instance;
					t_return = new JsonItem(new Value_Number<double>(t_value_raw));
				}else if(t_type == typeof(decimal)){
					//15:decimal
					decimal t_value_raw = (decimal)a_instance;
					t_return = new JsonItem(new Value_Number<decimal>(t_value_raw));
				}else if(t_type == typeof(sbyte)){
					//16:sbyte
					sbyte t_value_raw = (sbyte)a_instance;
					t_return = new JsonItem(new Value_Number<sbyte>(t_value_raw));
				}else if(t_type == typeof(byte)){
					//17:byte
					byte t_value_raw = (byte)a_instance;
					t_return = new JsonItem(new Value_Number<byte>(t_value_raw));
				}else if(t_type == typeof(short)){
					//18:short
					short t_value_raw = (short)a_instance;
					t_return = new JsonItem(new Value_Number<short>(t_value_raw));
				}else if(t_type == typeof(ushort)){
					//19:ushort
					ushort t_value_raw = (ushort)a_instance;
					t_return = new JsonItem(new Value_Number<ushort>(t_value_raw));
				}else if(t_type == typeof(uint)){
					//21:uint
					uint t_value_raw = (uint)a_instance;
					t_return = new JsonItem(new Value_Number<uint>(t_value_raw));
				}else if(t_type == typeof(ulong)){
					//23:ulong
					ulong t_value_raw = (ulong)a_instance;
					t_return = new JsonItem(new Value_Number<ulong>(t_value_raw));
				}else if(t_type == typeof(string)){
					//2:文字データ。

					string t_value_raw = a_instance as string;

					if(t_value_raw != null){

						t_return = new JsonItem(new Value_StringData(t_value_raw));

					}else{
						//NULL処理。

						t_return = null;
						//t_return = new JsonItem();
					}
				}else if(t_type.IsArray == true){
					//x[]

					System.Array t_array_raw = (System.Array)a_instance;
	
					JsonItem t_jsonitem = new JsonItem(new Value_IndexArray());
					t_jsonitem.ReSize(t_array_raw.Length);
					for(int ii=0;ii<t_array_raw.Length;ii++){
						System.Object t_list_item_raw = t_array_raw.GetValue(ii);
						t_workpool.Add(new ObjectToJson_Work(t_list_item_raw,null,ii,t_jsonitem));
					}

					t_return = t_jsonitem;
				}else if(t_type.IsEnum == true){
					//enum

					bool t_string_mode = false;
					if(a_objectoption != null){
						if(a_objectoption.attribute_enumstring == true){
							t_string_mode = true;
						}
					}

					if(t_string_mode == true){
						//enumの文字列化。

						string t_value_raw = a_instance.ToString();

						if(t_value_raw != null){
							t_return = new JsonItem(new Value_StringData(t_value_raw));
						}else{
							//NULL処理。

							t_return = null;
							//t_return = new JsonItem();
						}
					}else{
						//enumの数値化。

						int t_value_raw = (int)a_instance;
						t_return = new JsonItem(new Value_Number<int>(t_value_raw));
					}
				}else if(t_type.IsGenericType == true){
					System.Type t_type_g = t_type.GetGenericTypeDefinition();

					if(t_type_g == typeof(System.Collections.Generic.List<>)){
						//List

						System.Collections.IList t_value_raw = a_instance as System.Collections.IList;
						if(t_value_raw != null){

							JsonItem t_jsonitem = new JsonItem(new Value_IndexArray());
							t_jsonitem.ReSize(t_value_raw.Count);
							for(int ii=0;ii<t_value_raw.Count;ii++){
								System.Object t_list_item_raw = t_value_raw[ii];
								t_workpool.Add(new ObjectToJson_Work(t_list_item_raw,null,ii,t_jsonitem));
							}

							t_return = t_jsonitem;
						}else{
							//NULL処理。

							t_return = null;
							//t_return = new JsonItem();
						}
					}else if(t_type_g == typeof(System.Collections.Generic.Dictionary<,>)){
						//Dictionary

						System.Collections.IDictionary t_value_raw = a_instance as System.Collections.IDictionary;
						if(t_value_raw != null){
							System.Collections.Generic.ICollection<string> t_collection = t_value_raw.Keys as System.Collections.Generic.ICollection<string>;
							if(t_collection != null){

								JsonItem t_jsonitem = new JsonItem(new Value_AssociativeArray());
								foreach(string t_key_string in t_collection){
									if(t_key_string != null){
										System.Object t_list_item_raw = t_value_raw[t_key_string];
										t_workpool.Add(new ObjectToJson_Work(t_list_item_raw,null,t_key_string,t_jsonitem));
									}else{
										//NULL処理。

										//nullの場合は追加しない。
									}
								}

								t_return = t_jsonitem;
							}else{
								//keyの型がstring以外のものは追加しない。

								t_return = null;
								//t_return = new JsonItem();
							}
						}else{
							//NULL処理。

							t_return = null;
							//t_return = new JsonItem();
						}
					}else{
						t_search_member = true;
					}
				}else{
					t_search_member = true;
				}

				if(t_search_member == true){
					//class,struct

					JsonItem t_jsonitem = new JsonItem(new Value_AssociativeArray());
					System.Reflection.MemberInfo[] t_member = t_type.GetMembers(System.Reflection.BindingFlags.Public|System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Instance);

					for(int ii=0;ii<t_member.Length;ii++){
						if(t_member[ii].MemberType == System.Reflection.MemberTypes.Field){
							System.Reflection.FieldInfo t_fieldinfo = t_member[ii] as System.Reflection.FieldInfo;
							if(t_fieldinfo != null){
								if(t_fieldinfo.IsDefined(typeof(Fee.JsonItem.Ignore),false) == true){
									//無視する。
								}else{
									ObjectToJson_Work.ObjectOption t_objectoption = null;

									//ＥＮＵＭの文字列化。
									if(t_fieldinfo.IsDefined(typeof(Fee.JsonItem.EnumString),false) == true){
										t_objectoption = new ObjectToJson_Work.ObjectOption();
										t_objectoption.attribute_enumstring = true;
									}

									switch(t_fieldinfo.Attributes){
									case System.Reflection.FieldAttributes.Public:
									case System.Reflection.FieldAttributes.Private:
									case System.Reflection.FieldAttributes.Public | System.Reflection.FieldAttributes.InitOnly:
									case System.Reflection.FieldAttributes.Private | System.Reflection.FieldAttributes.InitOnly:
										{
											System.Object t_raw = t_fieldinfo.GetValue(a_instance);
											if(t_raw != null){

												//対応できないDictionaryのチェック。
												bool t_no_support_dictionary = false;
												{
													System.Collections.IDictionary t_value_raw = t_raw as System.Collections.IDictionary;
													if(t_value_raw != null){
														System.Collections.Generic.ICollection<string> t_collection = t_value_raw.Keys as System.Collections.Generic.ICollection<string>;
														if(t_collection == null){
															t_no_support_dictionary = true;
														}
													}
												}

												if(t_no_support_dictionary == false){
													t_workpool.Add(new ObjectToJson_Work(t_raw,t_objectoption,t_fieldinfo.Name,t_jsonitem));
												}
											}else{
												//NULL処理。

												//t_return = new JsonItem();
											}
										}break;
									default:
										{
											//ＪＳＯＮ化しない型。
										}break;
									}
								}
							}else{
								Tool.Assert(false);
							}
						}
					}

					t_return = t_jsonitem;
				}
			}else{

				t_return = null;
				//t_return = new JsonItem();

			}

			//再起呼び出し。
			if(a_workpool == null){
				while(true){
					int t_count = t_workpool.Count;
					if(t_count > 0){
						ObjectToJson_Work t_current_work = t_workpool[t_count - 1];
						t_workpool.RemoveAt(t_count - 1);
						t_current_work.Do(t_nest,t_workpool);
					}else{
						break;
					}
				}
			}

			return t_return;
		}
	}
}

