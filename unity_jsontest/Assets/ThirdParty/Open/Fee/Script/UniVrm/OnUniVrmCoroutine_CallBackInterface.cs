

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief ＵＮＩＶＲＭ。コールバックインターフェイス。
*/


/** Fee.UniVrm
*/
namespace Fee.UniVrm
{
	/** OnUniVrmCoroutine_CallBackInterface
	*/
	public interface OnUniVrmCoroutine_CallBackInterface
	{
		/** [Fee.UniVrm.OnUniVrmCoroutine_CallBackInterface]コルーチン実行中。

			return == false : キャンセル。

		*/
		bool OnUniVrmCoroutine(float a_progress);
	}
}

