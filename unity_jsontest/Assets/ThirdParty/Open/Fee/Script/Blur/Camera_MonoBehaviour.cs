

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief ブラー。カメラ。
*/


/** Fee.Blur
*/
namespace Fee.Blur
{
	/** Camera_MonoBehaviour
	*/
	public class Camera_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** mycamera
		*/
		public UnityEngine.Camera mycamera;

		/** material_blur_x
		*/
		private UnityEngine.Material material_blur_x;

		/** material_blur_y
		*/
		private UnityEngine.Material material_blur_y;

		/** work_rendertexture
		*/
		private UnityEngine.RenderTexture work_rendertexture;

		/** ブレンド比率。
		*/
		[UnityEngine.SerializeField,UnityEngine.Range(0.0f,1.0f)]
		private float rate_blend;

		/** 初期化。
		*/
		public void Initialize()
		{
			//カメラ取得。
			this.mycamera = this.GetComponent<UnityEngine.Camera>();

			//マテリアル読み込み。
			this.material_blur_x = new UnityEngine.Material(UnityEngine.Resources.Load<UnityEngine.Material>(Config.MATERIAL_NAME_BLURX));
			this.material_blur_y = new UnityEngine.Material(UnityEngine.Resources.Load<UnityEngine.Material>(Config.MATERIAL_NAME_BLURY));

			//比率。
			this.rate_blend = 1.0f;

			//レンダーテクスチャ。
			this.work_rendertexture = null;

			#if(UNITY_EDITOR)
			{
				float[] t_table = new float[8];
				float t_total = 0.0f;
				float t_dispersion = 1.0f;
				for(int ii=0;ii<t_table.Length;ii++){
					t_table[ii] = UnityEngine.Mathf.Exp(-0.5f * ((float)(ii*ii)) / t_dispersion);
					t_total += t_table[ii] * 2;
				}

				float t_check = 0.0f;

				for(int ii=0;ii<t_table.Length;ii++){
					t_table[ii] /= t_total;
					t_check += t_table[ii];
					Tool.Log("Blur","param = " + (t_table[ii] * 10000).ToString());
				}

				Tool.Log("Blur","0.5f check = " + t_check.ToString());
			}
			#endif
		}

		/** 削除。
		*/
		public void Delete()
		{
		}

		/** カメラデプス。設定。
		*/
		public void SetCameraDepth(float a_depth)
		{
			this.mycamera.depth = a_depth;
		}

		/** カメラ深度。取得。
		*/
		public float GetCameraDepth()
		{
			return this.mycamera.depth;
		}

		/** ブレンド比率。設定。
		*/
		public void SetBlendRate(float a_blend)
		{
			this.rate_blend = a_blend;

			if(this.rate_blend < 0.0f){
				this.rate_blend = 0.0f;
			}else if(this.rate_blend > 1.0f){
				this.rate_blend = 1.0f;
			}
		}

		/** ブレンド比率。取得。
		*/
		public float GetBlendRate()
		{
			return this.rate_blend;
		}

		/** OnRenderImage
		*/
		private void OnRenderImage(UnityEngine.RenderTexture a_source,UnityEngine.RenderTexture a_dest)
		{
			//レンダリングテクスチャ作成。
			this.work_rendertexture = UnityEngine.RenderTexture.GetTemporary(a_source.width,a_source.height,0,a_source.format,UnityEngine.RenderTextureReadWrite.Default);

			try{
				//x
				UnityEngine.Graphics.Blit(a_source,this.work_rendertexture,this.material_blur_x);

				//y
				this.material_blur_y.SetFloat("rate_blend",this.rate_blend);
				this.material_blur_y.SetTexture("texture_original",a_source);
				UnityEngine.Graphics.Blit(this.work_rendertexture,a_dest,this.material_blur_y);
			}catch(System.Exception t_exception){
				Tool.DebugReThrow(t_exception);
			}

			//レンダーテクスチャ解放。
			if(this.work_rendertexture != null){
				UnityEngine.RenderTexture.ReleaseTemporary(this.work_rendertexture);
				this.work_rendertexture = null;
			}
		}
	}
}

