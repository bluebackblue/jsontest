

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief データ。ワークアイテム。
*/


/** Fee.Data
*/
namespace Fee.Data
{
	/** WorkItem
	*/
	public class WorkItem
	{
		/** Mode
		*/
		private enum Mode
		{
			/** 開始。
			*/
			Start,

			/** Do_File
			*/
			Do_File,

			/** 完了。
			*/
			End
		};

		/** RequestType
		*/
		private enum RequestType
		{
			/** None
			*/
			None,

			/** ロード。
			*/
			Load,
		};

		/** mode
		*/
		private Mode mode;

		/** request_type
		*/
		private RequestType request_type;

		/** request_listitem
		*/
		private ListItem request_listitem;

		/** item
		*/
		private Item item;

		/** constructor
		*/
		public WorkItem()
		{
			//mode
			this.mode = Mode.Start;

			//request_type
			this.request_type = RequestType.None;

			//request_listitem
			this.request_listitem = null;

			//item
			this.item = new Item();
		}

		/** リクエスト。
		*/
		public void RequestLoad(ListItem a_listitem)
		{
			this.request_type = RequestType.Load;
			this.request_listitem = a_listitem;
		}

		/** アイテム。
		*/
		public Item GetItem()
		{
			return this.item;
		}

		/** 更新。

			return == true : 完了。

		*/
		public bool Main()
		{
			switch(this.mode){
			case Mode.Start:
				{
					switch(this.request_type){
					case RequestType.Load:
						{
							if(Fee.Data.Data.GetInstance().GetMainLoad().RequestLoad(this.request_listitem) == true){
								this.mode = Mode.Do_File;
							}
						}break;
					}
				}break;
			case Mode.End:
				{
				}return true;
			case Mode.Do_File:
				{
					Main_Load t_main = Fee.Data.Data.GetInstance().GetMainLoad();

					this.item.SetResultProgress(t_main.GetResultProgress());

					if(t_main.GetResultType() != Main_Load.ResultType.None){
						//結果。
						bool t_success = false;
						switch(t_main.GetResultType()){
						case Main_Load.ResultType.Asset:
							{
								if(t_main.GetResultAsset() != null){
									this.item.SetResultAsset(t_main.GetResultAsset());
									t_success = true;
								}
							}break;
						}

						if(t_success == false){
							this.item.SetResultErrorString(t_main.GetResultErrorString());
						}

						//完了。
						t_main.Fix();

						this.mode = Mode.End;
					}else if(this.item.IsCancel() == true){
						//キャンセル。
						t_main.Cancel();
					}
				}break;
			}

			return false;
		}
	}
}

