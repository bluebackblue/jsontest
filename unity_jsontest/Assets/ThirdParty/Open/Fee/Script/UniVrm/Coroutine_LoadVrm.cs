

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief ＵＮＩＶＲＭ。コルーチン。
*/


/** Fee.UniVrm
*/
namespace Fee.UniVrm
{
	/** ロード。ＶＲＭ。
	*/
	public class Coroutine_LoadVrm
	{
		/** ResultType
		*/
		public class ResultType
		{
			/** コンテキスト。
			*/
			public VRM.VRMImporterContext context;

			/** エラー文字列。
			*/
			public string errorstring;

			/** constructor
			*/
			public ResultType()
			{
				//context
				this.context = null;

				//errorstring
				this.errorstring = null;
			}
		}

		/** result
		*/
		public ResultType result;

		/** is_error
		*/
		private bool is_error;

		/** CoroutineMain
		*/
		public System.Collections.IEnumerator CoroutineMain(Fee.UniVrm.OnUniVrmCoroutine_CallBackInterface a_callback,byte[] a_binary)
		{
			//result
			this.result = new ResultType();

			//is_error
			this.is_error = false;

			{
				VRM.VRMImporterContext t_context = new VRM.VRMImporterContext();

				//キャンセル。
				if(this.result.errorstring == null){
					if(a_callback != null){
						if(a_callback.OnUniVrmCoroutine(0.0f) == false){
							this.result.errorstring = "Coroutine_Load : Cancel";
						}
					}
				}

				//「ParseGlb」。
				if(this.result.errorstring == null){
					try{
						t_context.ParseGlb(a_binary);
					}catch(System.Exception t_exception){
						this.result.errorstring = "Coroutine_Load : ParseGlb : " + t_exception.Message;
					}
				}

				//エラーチェック。
				if(this.result.errorstring != null){
					if(t_context != null){
						t_context.Dispose();
						t_context = null;
					}
					this.result.context = null;
					yield break;
				}

				//キャンセル。
				if(this.result.errorstring == null){
					if(a_callback != null){
						if(a_callback.OnUniVrmCoroutine(0.5f) == false){
							this.result.errorstring = "Coroutine_Load : Cancel";
						}
					}
				}

				yield return null;

				//「Load」。
				if(this.result.errorstring == null){
					yield return t_context.LoadCoroutine(this.OnLoadEnd,this.OnLoadError);
				}

				//エラーチェック。
				if(this.result.errorstring == null){
					if(this.is_error == true){
						this.result.errorstring = "Coroutine_Load : OnLoadError";
					}
				}

				//エラーチェック。
				if(this.result.errorstring != null){
					if(t_context != null){
						t_context.Dispose();
						t_context = null;
					}
					this.result.context = null;
					yield break;
				}

				//成功。
				this.result.errorstring = null;
				this.result.context = t_context;
				yield break;
			}
		}

		/** OnLoadEnd
		*/
		private void OnLoadEnd()
		{
		}

		/** OnLoadError
		*/
		private void OnLoadError(System.Exception a_exception)
		{
			this.is_error = true;
			this.result.errorstring = a_exception.Message;
		}
	}
}

