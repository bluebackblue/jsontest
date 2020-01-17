

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief ＵＩ。コールバックインターフェイス。
*/


/** Fee.Ui
*/
namespace Fee.Ui
{
	/** OnSliderChangeValue_CallBackInterface
	*/
	public interface OnSliderChangeValue_CallBackInterface<T>
	{
		/** [Fee.Ui.OnSliderChangeValue_CallBackInterface]値変更。
		*/
		void OnSliderChangeValue(T a_id,float a_value);
	}

	/** OnSliderChangeValue_CallBackParam
	*/
	public interface OnSliderChangeValue_CallBackParam
	{
		void Call(float a_value);
	}

	/** OnSliderChangeValue_CallBackParam_Generic
	*/
	public class OnSliderChangeValue_CallBackParam_Generic<T> : OnSliderChangeValue_CallBackParam
	{
		/** callback_interface
		*/
		public OnSliderChangeValue_CallBackInterface<T> callback_interface;

		/** id
		*/
		public T id;

		/** constructor
		*/
		public OnSliderChangeValue_CallBackParam_Generic(OnSliderChangeValue_CallBackInterface<T> a_callback_interface,T a_id)
		{
			this.callback_interface = a_callback_interface;
			this.id = a_id;
		}

		/** Call
		*/
		public void Call(float a_value)
		{
			if(this.callback_interface != null){
				this.callback_interface.OnSliderChangeValue(this.id,a_value);
			}
		}
	}
}

