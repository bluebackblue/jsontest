

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief プラットフォーム。仮想DBからIDBへの書き込み。
*/


/** Fee.Platform
*/
namespace Fee.Platform
{
	/** WebGL_SyncFs
	*/
	#if((!UNITY_EDITOR)&&(UNITY_WEBGL))
	class WebGL_SyncFs
	{
		/** Fee_Platform_WebGLPlugin_SyncFs

		Plugins/Platform/syncfs:Fee_Platform_WebGLPlugin_SyncFs

		*/
		[System.Runtime.InteropServices.DllImport("__Internal")]
		private static extern bool Fee_Platform_WebGLPlugin_SyncFs();

		/** SyncFs
		*/
		public static void SyncFs(Root_MonoBehaviour a_root_monobehaviour)
		{
			try{
				bool t_ret = WebGL_SyncFs.Fee_Platform_WebGLPlugin_SyncFs();
				if(t_ret == false){
					Tool.LogError("Fee_Platform_WebGLPlugin_SyncFs","error");
				}
			}catch(System.Exception t_exception){
				Tool.DebugReThrow(t_exception);
			}
		}
	}
	#endif
}

