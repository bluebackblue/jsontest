

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief ＵＩ。ウィンドウ。
*/


/** Fee.Ui
*/
namespace Fee.Ui
{
	/** WindowResumeItem
	*/
	public class WindowResumeItem
	{
		/** ラベル。
		*/
		public string label;

		/** 矩形。
		*/
		public Fee.Geometry.Rect2D_R<int> rect;

		/** constructor
		*/
		public WindowResumeItem(string a_label)
		{
			//label
			this.label = a_label;

			//rect
			this.rect.Set(0,0,0,0);
		}
	}
}

