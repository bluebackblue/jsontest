

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief ２Ｄ描画。レイヤーリスト。
*/


/** Fee.Render2D
*/
namespace Fee.Render2D
{
	/** LayerList
	*/
	public class LayerList
	{
		/** レイヤーリスト。
		*/
		private LayerItem[] list;

		/** constructor
		*/
		public LayerList(UnityEngine.Transform a_transform_root)
		{
			//レイヤーリスト。
			this.list = new LayerItem[Config.MAX_LAYER];
			for(int ii=0;ii<this.list.Length;ii++){
				this.list[ii] = new LayerItem();

				//描画順序。
				float t_gl_depth = Config.CAMERADEPTH_START + ii * Config.CAMERADEPTH_STEP + Config.CAMERADEPTH_OFFSET_GL;
				float t_ui_depth = Config.CAMERADEPTH_START + ii * Config.CAMERADEPTH_STEP + Config.CAMERADEPTH_OFFSET_UI;

				//カメラ。ＧＬ描画。
				UnityEngine.GameObject t_gameobject_camera_gl = Fee.Instantiate.Instantiate.CreateOrthographicCameraObject("Camera_" + ii.ToString() + "_GL",a_transform_root,t_gl_depth);
				UnityEngine.Camera t_camera_gl = t_gameobject_camera_gl.GetComponent<UnityEngine.Camera>();

				//カメラ。ＵＩ描画。
				UnityEngine.GameObject t_gameobject_camera_ui = Fee.Instantiate.Instantiate.CreateOrthographicCameraObject("Camera_" + ii.ToString() + "_UI",a_transform_root,t_ui_depth);
				UnityEngine.Camera t_camera_ui = t_gameobject_camera_ui.GetComponent<UnityEngine.Camera>();
				t_camera_ui.cullingMask = (1 << UnityEngine.LayerMask.NameToLayer("UI"));
				
				//キャンバス作成。
				UnityEngine.GameObject t_gameobject_canvas = Fee.Instantiate.Instantiate.CreateCameraCanvas("Canvas_" + ii.ToString(),a_transform_root,t_camera_ui);

				//ＧＬ描画設定。
				this.list[ii].camera_gl_monobehaviour = t_gameobject_camera_gl.AddComponent<Camera_GL_MonoBehaviour>();
				this.list[ii].camera_gl_monobehaviour.Initialize(ii,t_camera_gl,t_gl_depth);
				
				//ＵＩカメラ。
				this.list[ii].camera_ui_monobehaviour = t_gameobject_camera_ui.AddComponent<Camera_UI_MonoBehaviour>();
				this.list[ii].camera_ui_monobehaviour.Initialize(ii,t_camera_ui,t_ui_depth);

				//キャンバス設定。
				this.list[ii].canvas_transform = t_gameobject_canvas.GetComponent<UnityEngine.Transform>();
			}
		}

		/** 描画プライオリティからレイヤーインデックス取得。
		*/
		public int CalcLayerIndexFromDrawPriority(long a_drawpriority)
		{
			int t_layerindex = (int)(a_drawpriority / Config.DRAWPRIORITY_STEP);

			if((0<=t_layerindex)&&(t_layerindex<this.list.Length)){
				return t_layerindex;
			}

			return -1;
		}

		/** 描画プライオリティからレイヤートランスフォーム取得。
		*/
		public UnityEngine.Transform GetLayerTransformFromDrawPriority(long a_drawpriority)
		{
			int t_layerindex = this.CalcLayerIndexFromDrawPriority(a_drawpriority);

			if(t_layerindex >= 0){
				return this.list[t_layerindex].canvas_transform;
			}

			return null;
		}

		/** リストサイズ取得。
		*/
		public int GetListMax()
		{
			return this.list.Length;
		}

		/** GetStartIndex_Sprite
		*/
		public int GetStartIndex_Sprite(int a_layerindex)
		{
			return this.list[a_layerindex].sprite_index_start;
		}

		/** GetLastIndex_Sprite
		*/
		public int GetLastIndex_Sprite(int a_layerindex)
		{
			return this.list[a_layerindex].sprite_index_last;
		}

		/** GetStartIndex_Text
		*/
		public int GetStartIndex_Text(int a_layerindex)
		{
			return this.list[a_layerindex].text_index_start;
		}

		/** GetLastIndex_Text
		*/
		public int GetLastIndex_Text(int a_layerindex)
		{
			return this.list[a_layerindex].text_index_last;
		}

		/** GetStartIndex_InputField
		*/
		public int GetStartIndex_InputField(int a_layerindex)
		{
			return this.list[a_layerindex].inputfield_index_start;
		}

		/** GetLastIndex_InputField
		*/
		public int GetLastIndex_InputField(int a_layerindex)
		{
			return this.list[a_layerindex].inputfield_index_last;
		}

		/** デプスクリアフラグ。設定。
		*/
		public void SetDepthClearFlagGL(int a_layerindex,bool a_flag)
		{
			this.list[a_layerindex].camera_gl_monobehaviour.SetDepthFlagClear(a_flag);
		}

		/** デプスクリアフラグ。設定。
		*/
		public void SetDepthClearFlagUI(int a_layerindex,bool a_flag)
		{
			this.list[a_layerindex].camera_ui_monobehaviour.SetDepthFlagClear(a_flag);
		}

		/** コールバック。設定。
		*/
		public float GetGLCameraDepth(int a_layerindex)
		{
			return this.list[a_layerindex].camera_gl_monobehaviour.GetCameraDepth();
		}

		/** コールバック。設定。
		*/
		public float GetUICameraDepth(int a_layerindex)
		{
			return this.list[a_layerindex].camera_ui_monobehaviour.GetCameraDepth();
		}

		/** アクティブ。変更。

			表示物のないカメラを非アクティブにする。

		*/
		public void ChangeActiveCamera()
		{
			for(int ii=1;ii<this.list.Length;ii++){
				if(this.list[ii].sprite_index_start >= 0){
					this.list[ii].camera_gl_monobehaviour.SetActive(true);
				}else{
					this.list[ii].camera_gl_monobehaviour.SetActive(false);
				}
			}

			for(int ii=1;ii<this.list.Length;ii++){
				if((this.list[ii].inputfield_index_last >= 0)||(this.list[ii].text_index_start >= 0)){
					this.list[ii].camera_ui_monobehaviour.SetActive(true);
				}else{
					this.list[ii].camera_ui_monobehaviour.SetActive(false);
				}
			}
		}

		/** スプライトインデックス。計算。
		*/
		public void CalcSpriteIndex(SpriteList a_spritelist)
		{
			//リセット。
			for(int ii=0;ii<this.list.Length;ii++){
				this.list[ii].ResetSpriteIndex();
			}

			//スプライト。
			{
				int t_calc_mode = 0;
				int t_calc_layer = 0;
				int t_calc_index = 0;
				LayerItem t_calc_layeritem = this.list[t_calc_layer];

				while(t_calc_index < a_spritelist.GetListMax()){
					Fee.Render2D.Sprite2D t_sprite = a_spritelist.GetItem(t_calc_index);
					int t_layerindex = this.CalcLayerIndexFromDrawPriority(t_sprite.GetDrawPriority());
	
					if(t_calc_layer < this.list.Length){
						if(t_calc_mode == 0){
							//開始インデックス。

							if(t_layerindex < 0){
								//除外。
								t_calc_index++;
							}else{
								if(t_calc_layer == t_layerindex){
									//開始位置発見。
									t_calc_layeritem.sprite_index_start = t_calc_index;
									t_calc_layeritem.sprite_index_last = t_calc_index;

									t_calc_index++;
									t_calc_mode = 1;
								}else{
									//再チェック。
									t_calc_layeritem.sprite_index_start = -1;
									t_calc_layeritem.sprite_index_last = -1;

									t_calc_layer++;
									t_calc_layeritem = this.list[t_calc_layer];
									t_calc_mode = 0;
								}
							}
						}else{
							//終了インデックス。

							if(t_calc_layer == t_layerindex){
								//終了インデックス候補。
								t_calc_layeritem.sprite_index_last = t_calc_index;
								t_calc_index++;
							}else{
								//再チェック。
								t_calc_layer++;
								t_calc_layeritem = this.list[t_calc_layer];
								t_calc_mode = 0;
							}
						}
					}
				}
			}
		}

		/** スプライトインデックス。計算。
		*/
		public void CalcTextIndex(TextList a_textlist)
		{
			//リセット。
			for(int ii=0;ii<this.list.Length;ii++){
				this.list[ii].ResetTextIndex();
			}

			//テキスト。
			{
				int t_calc_mode = 0;
				int t_calc_layer = 0;
				int t_calc_index = 0;
				LayerItem t_calc_layeritem = this.list[t_calc_layer];

				while(t_calc_index < a_textlist.GetListMax()){
					Fee.Render2D.Text2D t_text = a_textlist.GetItem(t_calc_index);
					int t_layerindex = this.CalcLayerIndexFromDrawPriority(t_text.GetDrawPriority());
	
					if(t_calc_layer < this.list.Length){
						if(t_calc_mode == 0){
							//開始インデックス。

							if(t_layerindex < 0){
								//除外。
								t_calc_index++;
							}else{
								if(t_calc_layer == t_layerindex){
									//開始位置発見。
									t_calc_layeritem.text_index_start = t_calc_index;
									t_calc_layeritem.text_index_last = t_calc_index;

									t_calc_index++;
									t_calc_mode = 1;
								}else{
									//再チェック。
									t_calc_layeritem.text_index_start = -1;
									t_calc_layeritem.text_index_last = -1;

									t_calc_layer++;
									t_calc_layeritem = this.list[t_calc_layer];
									t_calc_mode = 0;
								}
							}
						}else{
							//終了インデックス。

							if(t_calc_layer == t_layerindex){
								//終了インデックス候補。
								t_calc_layeritem.text_index_last = t_calc_index;
								t_calc_index++;
							}else{
								//再チェック。
								t_calc_layer++;
								t_calc_layeritem = this.list[t_calc_layer];
								t_calc_mode = 0;
							}
						}
					}
				}
			}
		}

		/** スプライトインデックス。計算。
		*/
		public void CalcInputFieldIndex(InputFieldList a_inputfieldlist)
		{
			//リセット。
			for(int ii=0;ii<this.list.Length;ii++){
				this.list[ii].ResetInputFieldIndex();
			}

			//入力フィールド。
			{
				int t_calc_mode = 0;
				int t_calc_layer = 0;
				int t_calc_index = 0;
				LayerItem t_calc_layeritem = this.list[t_calc_layer];

				while(t_calc_index < a_inputfieldlist.GetListMax()){
					Fee.Render2D.InputField2D t_inputfield = a_inputfieldlist.GetItem(t_calc_index);
					int t_layerindex = this.CalcLayerIndexFromDrawPriority(t_inputfield.GetDrawPriority());
	
					if(t_calc_layer < this.list.Length){
						if(t_calc_mode == 0){
							//開始インデックス。

							if(t_layerindex < 0){
								//除外。
								t_calc_index++;
							}else{
								if(t_calc_layer == t_layerindex){
									//開始位置発見。
									t_calc_layeritem.inputfield_index_start = t_calc_index;
									t_calc_layeritem.inputfield_index_last = t_calc_index;

									t_calc_index++;
									t_calc_mode = 1;
								}else{
									//再チェック。
									t_calc_layeritem.inputfield_index_start = -1;
									t_calc_layeritem.inputfield_index_last = -1;

									t_calc_layer++;
									t_calc_layeritem = this.list[t_calc_layer];
									t_calc_mode = 0;
								}
							}
						}else{
							//終了インデックス。

							if(t_calc_layer == t_layerindex){
								//終了インデックス候補。
								t_calc_layeritem.inputfield_index_last = t_calc_index;
								t_calc_index++;
							}else{
								//再チェック。
								t_calc_layer++;
								t_calc_layeritem = this.list[t_calc_layer];
								t_calc_mode = 0;
							}
						}
					}
				}
			}
		}
	}
}

