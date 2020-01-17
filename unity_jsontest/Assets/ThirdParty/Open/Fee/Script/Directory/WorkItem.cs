

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief ディレクトリ。ワークアイテム。
*/


/** Fee.Directory
*/
namespace Fee.Directory
{
	/** WorkItem
	*/
	public class WorkItem
	{
		/** 相対パス。
		*/
		private string path;

		/** アイテム。
		*/
		private Item item;

		/** constructor
		*/
		public WorkItem(string a_path,Item a_item)
		{
			/** 相対パス。
			*/
			this.path = a_path;

			/** 追加先。
			*/
			this.item = a_item;
		}

		/** 相対パス。取得。
		*/
		public string GetPath()
		{
			return this.path;
		}

		/** アイテム。取得。
		*/
		public Item GetItem()
		{
			return this.item;
		}
	}
}

