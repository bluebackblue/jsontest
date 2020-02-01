

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
	/** OnButtonChangeOverFlag_CallBackInterface
	*/
	public interface OnButtonChangeOverFlag_CallBackInterface<T>
	{
		/** [Fee.Ui.OnButtonChangeOverFlag_CallBackInterface]オンオーバー。
		*/
		void OnButtonChangeOverFlag(T a_id,bool a_is_onover);
	}

	/** OnButtonChangeOverFlag_CallBackParam
	*/
	public interface OnButtonChangeOverFlag_CallBackParam
	{
		/** Call
		*/
		void Call(bool a_is_onover);
	}

	/** OnButtonChangeOverFlag_CallBackParam_Generic
	*/
	public readonly struct OnButtonChangeOverFlag_CallBackParam_Generic<T> : OnButtonChangeOverFlag_CallBackParam
	{
		/** callback_interface
		*/
		public readonly OnButtonChangeOverFlag_CallBackInterface<T> callback_interface;

		/** id
		*/
		public readonly T id;

		/** constructor
		*/
		public OnButtonChangeOverFlag_CallBackParam_Generic(OnButtonChangeOverFlag_CallBackInterface<T> a_callback_interface,T a_id)
		{
			this.callback_interface = a_callback_interface;
			this.id = a_id;
		}

		/** Call
		*/
		public void Call(bool a_is_onover)
		{
			if(this.callback_interface != null){
				try{
					this.callback_interface.OnButtonChangeOverFlag(this.id,a_is_onover);
				}catch(System.Exception t_exception){
					Tool.DebugReThrow(t_exception);
				}
			}
		}
	}
}

