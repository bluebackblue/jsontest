

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief エクセル。エクセルからＪＳＯＮシート作成。
*/


/** USE_DEF_FEE_EDITOR_EXCELDATAREADER
*/
#if((UNITY_EDITOR)&&(USE_DEF_FEE_EDITOR_EXCELDATAREADER))
	#define USE_DEF_FEE_EXCELDATAREADER
#endif


/** Fee.Excel
*/
namespace Fee.Excel
{
	/** エクセルからＪＳＯＮシート作成。
	*/
	public class ExcelToJsonSheet
	{
		/** excel
		*/
		private Excel_Base excel;

		/** jsonitem_jsonsheet
		*/
		private Fee.JsonItem.JsonItem jsonitem_jsonsheet;

		/** constructor
		*/
		public ExcelToJsonSheet()
		{
			//excel
			this.excel = null;

			//jsonitem_jsonsheet
			this.jsonitem_jsonsheet = null;
		}

		/** コンバート。
		*/
		public bool Convert(File.Path a_path)
		{
			this.jsonitem_jsonsheet = new JsonItem.JsonItem(new Fee.JsonItem.Value_AssociativeArray());

			{
				#if(USE_DEF_FEE_EXCELDATAREADER)
				{
					this.excel = new Excel_ExcelDataReader();
				}
				#else
				{
					this.excel = new Excel_Dummy();
				}
				#endif

				if(this.excel.ReadOpen(a_path) == true){
					int t_sheet_count = this.excel.GetSheetCount();
					for(int ii=0;ii<t_sheet_count;ii++){
						if(this.excel.SetActiveSheet(ii) == true){
							this.Convert_Sheet();
						}
					}
					this.excel.Close();
				}else{
					//失敗。
					return false;
				}
			}

			return true;
		}

		/** ＪＳＯＮシート。取得。
		*/
		public Fee.JsonItem.JsonItem GetJsonSheet()
		{
			return this.jsonitem_jsonsheet;
		}

		/** セルの文字列をチェック。
		*/
		private bool CellStringCheck(int a_x,int a_y,string a_text,out CellPosition a_result_pos)
		{
			if(this.excel.SetActiveCell(a_x,a_y) == true){
				string t_value;
				this.excel.GetTryCellString(out t_value);
				if(t_value == a_text){
					a_result_pos = new CellPosition(a_x,a_y);
					return true;
				}
			}

			a_result_pos = new CellPosition(0,0);
			return false;
		}

		/** セルの文字列を取得。
		*/
		private string GetTryCellString(int a_x,int a_y)
		{
			if(this.excel.SetActiveCell(a_x,a_y) == true){
				string t_value;
				if(this.excel.GetTryCellString(out t_value) == true){
					return t_value;
				}
			}
			return null;
		}

		/** セルの数値を取得。
		*/
		private double GetTryCellNumeric(int a_x,int a_y)
		{
			if(this.excel.SetActiveCell(a_x,a_y) == true){
				double t_value;
				if(this.excel.GetTryCellNumeric(out t_value) == true){
					return t_value;
				}
			}
			return 0.0;
		}

		/** ボックス内を検索。
		*/
		private bool FindCellBox(int a_x,int a_y,int a_size,string a_text,out CellPosition a_result_pos)
		{
			for(int yy=0;yy<a_size;yy++){
				for(int xx=0;xx<a_size;xx++){
					int t_x = a_x + xx;
					int t_y = a_y + yy;
					if(this.CellStringCheck(t_x,t_y,a_text,out a_result_pos) == true){
						return true;
					}
				}
			}

			a_result_pos = new CellPosition(0,0);
			return false;
		}

		/** Ｘ軸方向に検索。
		*/
		private bool FindCellXLine(int a_x,int a_y,int a_size,string a_text,out CellPosition a_result_pos)
		{
			for(int xx=0;xx<a_size;xx++){
				int t_x = a_x + xx;
				int t_y = a_y;
				if(this.CellStringCheck(t_x,t_y,a_text,out a_result_pos) == true){
					return true;
				}
			}

			a_result_pos = new CellPosition(0,0);
			return false;
		}

		/** Ｙ軸方向に検索。
		*/
		private bool FindCellYLine(int a_x,int a_y,int a_size,string a_text,out CellPosition a_result_pos)
		{
			for(int yy=0;yy<a_size;yy++){
				int t_x = a_x;
				int t_y = a_y + yy;
				if(this.CellStringCheck(t_x,t_y,a_text,out a_result_pos) == true){
					return true;
				}
			}

			a_result_pos = new CellPosition(0,0);
			return false;
		}

		/** ルートを検索。
		*/
		private bool FindCell_Root(out CellPosition a_result_pos)
		{
			int t_block_size = 16;
			for(int yy=0;yy<10;yy++){
				for(int xx=0;xx<10;xx++){

					//ルート発見。
					if(this.FindCellBox(xx * t_block_size,yy * t_block_size,t_block_size,Config.COMMAND_PARAM_ROOT,out a_result_pos) == true){
						return true;
					}

					//ルートより先に終端発見。
					if(this.FindCellBox(xx * t_block_size,yy * t_block_size,t_block_size,Config.COMMAND_PARAM_END,out a_result_pos) == true){
						return false;
					}
				}
			}

			Tool.Assert(false);
			a_result_pos = new CellPosition(0,0);
			return false;
		}

		/** パラメータタイプリスト。作成。
		*/
		private System.Collections.Generic.List<ParamListItem> CreateParamTypeList(int a_param_type_y,int a_param_name_y,int a_start_x,int a_end_x)
		{
			System.Collections.Generic.List<ParamListItem> t_list = new System.Collections.Generic.List<ParamListItem>();

			for(int xx = a_start_x;xx < a_end_x;xx++){
				string t_param_type = this.GetTryCellString(xx,a_param_type_y);
				string t_param_name = this.GetTryCellString(xx,a_param_name_y);

				switch(t_param_type){
				case Config.PARAMTYPE_STRING:
					{
						t_list.Add(new ParamListItem(ParamType.StringType,t_param_name,xx));
					}break;
				case Config.PARAMTYPE_INT:
					{
						t_list.Add(new ParamListItem(ParamType.IntType,t_param_name,xx));
					}break;
				case Config.PARAMTYPE_FLOAT:
					{
						t_list.Add(new ParamListItem(ParamType.FloatType,t_param_name,xx));
					}break;
				case Config.PARAMTYPE_COMMENT:
					{
						//スキップ。
					}break;
				default:
					{
						//不明なパラメータタイプ。
						Tool.Assert(false);
					}break;
				}
			}

			return t_list;
		}

		/** コンバート。シート。
		*/
		private void Convert_Sheet()
		{
			/** pos
			*/
			CellPosition t_pos_root = new CellPosition(0,0);
			CellPosition t_pos_param_type = new CellPosition(0,0);
			CellPosition t_pos_param_name = new CellPosition(0,0);
			CellPosition t_pos_end_y = new CellPosition(0,0);
			CellPosition t_pos_end_x = new CellPosition(0,0);

			//ルート。検索。
			if(this.FindCell_Root(out t_pos_root) == false){
				return;
			}

			//パラメータタイプ。検索。
			if(this.CellStringCheck(t_pos_root.x,t_pos_root.y + 1,Config.COMMAND_PARAM_TYPE,out t_pos_param_type) == false){
				Tool.Assert(false);
				return;
			}

			//パラメータ名。検索。
			if(this.CellStringCheck(t_pos_root.x,t_pos_root.y + 2,Config.COMMAND_PARAM_NAME,out t_pos_param_name) == false){
				Tool.Assert(false);
				return;
			}

			//Ｘ軸方向。終端検索。
			if(this.FindCellXLine(t_pos_param_type.x + 1,t_pos_param_type.y,Config.END_SEARCH_WIDTH,Config.COMMAND_PARAM_END,out t_pos_end_x) == false){
				Tool.Assert(false);
				return;
			}

			//Ｙ軸方向。終端検索。
			if(this.FindCellYLine(t_pos_param_type.x,t_pos_param_type.y + 1,Config.END_SEARCH_HEIGHT,Config.COMMAND_PARAM_END,out t_pos_end_y) == false){
				Tool.Assert(false);
				return;
			}

			//パラメータリスト。作成。
			System.Collections.Generic.List<ParamListItem> t_param_list = this.CreateParamTypeList(t_pos_param_type.y,t_pos_param_name.y,t_pos_param_type.x + 1,t_pos_end_x.x);

			{
				Fee.JsonItem.JsonItem t_jsonitem_list = new JsonItem.JsonItem(new Fee.JsonItem.Value_IndexArray());
				for(int yy=t_pos_param_name.y+1;yy<t_pos_end_y.y;yy++){
					string t_flag = this.GetTryCellString(t_pos_param_name.x,yy);
					if(t_flag == Config.COMMAND_ON){
						Fee.JsonItem.JsonItem t_jsonitem_item = new JsonItem.JsonItem(new Fee.JsonItem.Value_AssociativeArray());
						for(int ii=0;ii<t_param_list.Count;ii++){
							switch(t_param_list[ii].param_type){
							case ParamType.StringType:
								{
									//string

									string t_value = this.GetTryCellString(t_param_list[ii].pos_x,yy);
									t_jsonitem_item.AddItem(t_param_list[ii].param_name,new JsonItem.JsonItem(new  Fee.JsonItem.Value_StringData(t_value)),false);
								}break;
							case ParamType.IntType:
								{
									//int

									double t_value = this.GetTryCellNumeric(t_param_list[ii].pos_x,yy);
									t_jsonitem_item.AddItem(t_param_list[ii].param_name,new JsonItem.JsonItem(new  Fee.JsonItem.Value_Number<int>((int)t_value)),false);
								}break;
							case ParamType.FloatType:
								{
									//float

									double t_value = this.GetTryCellNumeric(t_param_list[ii].pos_x,yy);
									t_jsonitem_item.AddItem(t_param_list[ii].param_name,new JsonItem.JsonItem(new  Fee.JsonItem.Value_Number<float>((float)t_value)),false);
								}break;
							default:
								{
									Tool.Assert(false);
								}break;
							}
						}
						t_jsonitem_list.AddItem(t_jsonitem_item,false);
					}
				}
				string t_root_name = this.GetTryCellString(t_pos_root.x + 1,t_pos_root.y);

				if(this.jsonitem_jsonsheet.IsExistItem(t_root_name) == false){
					this.jsonitem_jsonsheet.AddItem(t_root_name,t_jsonitem_list,false);
				}else{
					//ルート名が他のシートと重複している。
					Tool.Assert(false);
					return;
				}
			}
		}
	}
}

