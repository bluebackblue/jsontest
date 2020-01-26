

/** Visual
*/
namespace Visual
{
	/** ライブラリ処理。
	*/
	public class Visual : UnityEngine.MonoBehaviour
	{
		/** main
		*/
		private Main main;

		/** Start
		*/
		void Start()
		{
			//２Ｄ描画。
			Fee.Render2D.Config.VIRTUAL_W = 1280;
			Fee.Render2D.Config.VIRTUAL_H = 720;
			Fee.Render2D.Config.ReCalcWH();
			Fee.Render2D.Render2D.CreateInstance();

			//マウス。
			Fee.Input.Mouse.CreateInstance();

			//イベントプレート。
			Fee.EventPlate.EventPlate.CreateInstance();
			
			//ＵＩ。
			Fee.Ui.Ui.CreateInstance();

			//初期化。
			this.main = new Main();
		}

		/** シーン遷移。
		*/
		private void OnDestroy()
		{
			//削除。
			this.main.OnDelete();

			//２Ｄ描画。
			Fee.Render2D.Render2D.DeleteInstance();

			//マウス。
			Fee.Input.Mouse.DeleteInstance();

			//イベントプレート。
			Fee.EventPlate.EventPlate.DeleteInstance();

			//ＵＩ。
			Fee.Ui.Ui.DeleteInstance();
		}

		/** 更新。

		https://docs.unity3d.com/ja/current/Manual/ExecutionOrder.html
		
		Update呼び出し前。

		*/
		private void FixedUpdate()
		{
			try{
				//２Ｄ描画。
				Fee.Render2D.Render2D.GetInstance().Main_Before();

				//マウス。
				Fee.Input.Mouse.GetInstance().Main(true,Fee.Render2D.Render2D.GetInstance());

				//イベントプレート。
				Fee.EventPlate.EventPlate.GetInstance().Main(in Fee.Input.Mouse.GetInstance().cursor.pos);

				//ＵＩ。
				Fee.Ui.Ui.GetInstance().Main();

				//更新。
				this.main.FixedUpdate();

				//２Ｄ描画。
				Fee.Render2D.Render2D.GetInstance().Main_After();
			}catch(System.Exception t_exception){
				UnityEngine.Debug.LogError(t_exception.StackTrace + "\n\n" + t_exception.Message);
			}
		}

		/** Update
		*/
		void Update()
		{
			//２Ｄ描画。
			Fee.Render2D.Render2D.GetInstance().Main_PreDraw();
		}
	}
}

