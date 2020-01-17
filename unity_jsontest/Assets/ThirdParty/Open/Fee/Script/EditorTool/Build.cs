

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief エディターツール。ビルド。
*/


/** Fee.EditorTool

https://docs.unity3d.com/ja/current/Manual/CommandLineArguments.html

*/
#if(UNITY_EDITOR)
namespace Fee.EditorTool
{
	/** Build
	*/
	public class Build
	{
		/** パッケージ。作成。
		*/
		#if(!NOUSE_DEF_FEE_EDITORMENU)
		[UnityEditor.MenuItem("Fee/Build/BuildFeePackage")]
		private static void MenuItem_BuildFeePackage()
		{
			Build.BuildFeePackage();
		}
		#endif

		/** パッケージ。作成。
		*/
		private static void BuildFeePackage()
		{
			//サブディレクトリの再帰探査。
			UnityEditor.ExportPackageOptions t_option = UnityEditor.ExportPackageOptions.Recurse;

			//非同期実行。
			t_option |= UnityEditor.ExportPackageOptions.Interactive;

			//ファイル名。
			string t_filename = "fee_" + System.DateTime.Now.ToString("yyyyMMdd_HH") + ".unitypackage";

			//ディレクトリ名。
			Fee.File.Path t_fee_path = Fee.EditorTool.Utility.FindFeePath();

			//出力。
			Fee.EditorTool.Utility.ExportPackage(t_fee_path,t_filename,t_option);
		}

		/** CommandLineParam
		*/
		public class CommandLineParam
		{
			public string outputpath;
		}

		/** シーンパスリスト。取得。
		*/
		private static System.Collections.Generic.List<string> GetScenePathList()
		{
			System.Collections.Generic.List<string> t_scenepath_list = new System.Collections.Generic.List<string>();

			// "Scenes In Build"に登録されているシーンリストを取得
			UnityEditor.EditorBuildSettingsScene[] t_scene_list = UnityEditor.EditorBuildSettings.scenes;
			foreach(UnityEditor.EditorBuildSettingsScene t_scene in t_scene_list){
				if(t_scene.enabled == true){
					t_scenepath_list.Add(t_scene.path);
				}
			}

			return t_scenepath_list;
		}

		/** コマンドライン。取得。
		*/
		private static CommandLineParam GetCommandLine()
		{
			string[] t_commandline = System.Environment.GetCommandLineArgs();

			CommandLineParam t_param = new CommandLineParam();

			for(int ii=0;ii<(t_commandline.Length-1);ii++){
				if(t_commandline[ii] == "---outputpath"){
					t_param.outputpath = t_commandline[ii + 1];
				}
			}

			return t_param;
		}

		/** ビルド。WebGL。
		*/
		private static void Build_WebGL()
		{
			string t_log = "-------Build_WebGL-------\n";

			CommandLineParam t_commandline_param = GetCommandLine();
			System.Collections.Generic.List<string> t_scenepath_list = GetScenePathList();
			string[] t_levels = t_scenepath_list.ToArray();
			for(int ii=0;ii<t_levels.Length;ii++){
				t_log += t_levels[ii] + "\n";
			}

			string t_output_target = t_commandline_param.outputpath + "/WebGL";
			t_log += t_output_target + "\n";

			#if(UNITY_5)
			{
				//未対応。
				UnityEngine.Debug.Assert(false);
			}
			#else
			{
				UnityEditor.Build.Reporting.BuildReport t_return = UnityEditor.BuildPipeline.BuildPlayer(
					t_levels,
					t_output_target,
					UnityEditor.BuildTarget.WebGL,
					UnityEditor.BuildOptions.None
				);

				t_log += t_return.summary.totalErrors.ToString();
				t_log += "-----------------------------------";
			}
			#endif

			UnityEngine.Debug.Log(t_log);
		}

		/** ビルド。Android。
		*/
		private static void Build_Android()
		{
			string t_log = "-------Build_Android-------\n";

			CommandLineParam t_commandline_param = GetCommandLine();
			System.Collections.Generic.List<string> t_scenepath_list = GetScenePathList();
			string[] t_levels = t_scenepath_list.ToArray();
			for(int ii=0;ii<t_levels.Length;ii++){
				t_log += t_levels[ii] + "\n";
			}

			string t_output_target = t_commandline_param.outputpath + "/Fee.apk";
			t_log += t_output_target + "\n";

			#if(UNITY_5)
			{
				//未対応。
				UnityEngine.Debug.Assert(false);
			}
			#else
			{
				UnityEditor.Build.Reporting.BuildReport t_return = UnityEditor.BuildPipeline.BuildPlayer(
					t_levels,
					t_output_target,
					UnityEditor.BuildTarget.Android,
					UnityEditor.BuildOptions.None
				);
			
				t_log += t_return.summary.totalErrors.ToString();
				t_log += "-----------------------------------";
			}
			#endif

			UnityEngine.Debug.Log(t_log);
		}

		/** ビルド。StandaloneWindows。
		*/
		private static void Build_StandAloneWindows()
		{
			string t_log = "-------Build_StandAloneWindows-------\n";

			CommandLineParam t_commandline_param = GetCommandLine();
			System.Collections.Generic.List<string> t_scenepath_list = GetScenePathList();
			string[] t_levels = t_scenepath_list.ToArray();
			for(int ii=0;ii<t_levels.Length;ii++){
				t_log += t_levels[ii] + "\n";
			}

			string t_output_target = t_commandline_param.outputpath + "/Exe/fee.exe";
			t_log += t_output_target + "\n";

			#if(UNITY_5)
			{
				//未対応。
				UnityEngine.Debug.Assert(false);
			}
			#else
			{
				UnityEditor.Build.Reporting.BuildReport t_return = UnityEditor.BuildPipeline.BuildPlayer(
					t_levels,
					t_output_target,
					UnityEditor.BuildTarget.StandaloneWindows,
					UnityEditor.BuildOptions.None
				);

				t_log += t_return.summary.totalErrors.ToString();
				t_log += "-----------------------------------";
			}
			#endif

			UnityEngine.Debug.Log(t_log);
		}
	}
}
#endif

