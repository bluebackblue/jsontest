

/** Visual
*/
namespace Visual
{
	/** JsonViewer_Item
	*/
	public class JsonViewer_Item : Fee.Ui.ScrollItem_Base , Fee.Ui.OnButtonClick_CallBackInterface<int>
	{
		/** deleter
		*/
		private Fee.Deleter.Deleter deleter;

		/** viewer
		*/
		private JsonViewer viewer;
		
		/** layer
		*/
		private int layer;

		/** jsonitem
		*/
		private Fee.JsonItem.JsonItem jsonitem;

		/** sprite
		*/
		private Fee.Ui.Sprite2D_Clip sprite;

		/** button
		*/
		private Fee.Ui.Button button;

		/** text
		*/
		private Fee.Render2D.Text2D text;

		/** constructor
		*/
		public JsonViewer_Item(string a_label,JsonViewer a_viewer,int a_layer,Fee.JsonItem.JsonItem a_jsonitem)
		{
			//deleter
			this.deleter = new Fee.Deleter.Deleter();

			//viewer
			this.viewer = a_viewer;

			//layer
			this.layer = a_layer;

			//jsonitem
			this.jsonitem = a_jsonitem;

			string t_text;
			UnityEngine.Color t_color = UnityEngine.Color.black;
			{
				if(a_jsonitem == null){
					t_text = a_label;
				}else{

					//親がインデックス配列ならインデックス、連想配列ならキー名。
					t_text = "label = " + a_label + "\n";

					//データタイプ名。
					t_text += a_jsonitem.GetValueType().ToString() + "\n";

					//データ。
					switch(a_jsonitem.GetValueType()){
					case Fee.JsonItem.ValueType.AssociativeArray:
						{
							t_text += "count = " + a_jsonitem.GetListMax().ToString() + "\n";
							t_color = new UnityEngine.Color(0.2f,0.3f,0.2f,1.0f);
						}break;
					case Fee.JsonItem.ValueType.IndexArray:
						{
							t_text += "count = " + a_jsonitem.GetListMax().ToString() + "\n";
							t_color = new UnityEngine.Color(0.4f,0.2f,0.5f,1.0f);
						}break;
					case Fee.JsonItem.ValueType.BoolData:
						{
							t_text += "value = " + a_jsonitem.GetBoolData().ToString() + "\n";
							t_color = new UnityEngine.Color(0.1f,0.2f,0.4f,1.0f);
						}break;
					case Fee.JsonItem.ValueType.SignedNumber:
						{
							t_text += "value = " + a_jsonitem.GetSignedNumber().ToString() + "\n";
							t_color = new UnityEngine.Color(0.5f,0.2f,0.8f,1.0f);
						}break;
					case Fee.JsonItem.ValueType.UnsignedNumber:
						{
							t_text += "value = " + a_jsonitem.GetUnsignedNumber().ToString() + "\n";
							t_color = new UnityEngine.Color(0.4f,0.6f,0.3f,1.0f);
						}break;
					case Fee.JsonItem.ValueType.FloatingNumber:
						{
							t_text += "value = " + a_jsonitem.GetFloatingNumber().ToString() + "\n";
							t_color = new UnityEngine.Color(0.2f,0.2f,0.5f,1.0f);
						}break;
					case Fee.JsonItem.ValueType.DecimalNumber:
						{
							t_text += "value = " + a_jsonitem.GetDecimalNumber().ToString() + "\n";
							t_color = new UnityEngine.Color(0.1f,0.1f,0.1f,1.0f);
						}break;
					case Fee.JsonItem.ValueType.StringData:
						{
							t_text += "value = " + a_jsonitem.GetStringData() + "\n";
							t_color = new UnityEngine.Color(0.5f,0.2f,0.2f,1.0f);
						}break;
					}
				}
			}

			//text
			this.text = Fee.Render2D.Text2D.Create(this.deleter,0);
			this.text.SetText(t_text);
			this.text.SetAlignmentType(Fee.Render2D.Text2D_HorizontalAlignmentType.Left,Fee.Render2D.Text2D_VerticalAlignmentType.Top);
			this.text.SetColor(in t_color);
			this.text.SetClip(true);
			this.text.SetVisible(false);

			//button
			this.button = Fee.Ui.Button.Create(this.deleter,0);
			this.button.SetNormalTexture(UnityEngine.Texture2D.whiteTexture);
			this.button.SetOnTexture(UnityEngine.Texture2D.whiteTexture);
			this.button.SetDownTexture(UnityEngine.Texture2D.whiteTexture);
			this.button.SetLockTexture(UnityEngine.Texture2D.whiteTexture);
			this.button.SetNormalColor(0.8f,0.8f,0.8f,1.0f);
			this.button.SetOnColor(0.7f,0.7f,0.7f,1.0f);
			this.button.SetDownColor(0.6f,0.6f,0.6f,1.0f);
			this.button.SetLockColor(0.5f,0.5f,0.5f,1.0f);
			this.button.SetOnButtonClick(this,-1);
			this.button.SetClip(true);
			this.button.SetVisible(false);
			this.button.SetDragCancelFlag(true);
		}

		/** GetW
		*/
		public static int GetW()
		{
			return 200;
		}

		/** GetH
		*/
		public static int GetH()
		{
			return 100;
		}

		/** 削除。
		*/
		public void OnDelete()
		{
			this.deleter.DeleteAll();
		}

		/** [Fee.Ui.OnButtonClick_CallBackInterface]クリック。
		*/
		public void OnButtonClick(int a_id)
		{
			if(this.jsonitem == null){
			}else{
				switch(this.jsonitem.GetValueType()){
				case Fee.JsonItem.ValueType.AssociativeArray:
					{
						//自分のレイヤーの後ろを、自分を親として差し替え。
						this.viewer.CreateScroll(this.layer + 1,this.jsonitem);
					}break;
				case Fee.JsonItem.ValueType.IndexArray:
					{
						//自分のレイヤーの後ろを、自分を親として差し替え。
						this.viewer.CreateScroll(this.layer + 1,this.jsonitem);
					}break;
				default:
					{
						//自分のレイヤーの後ろを、削除。
						this.viewer.DeleteScroll(this.layer + 1);
					}break;
				}
			}
		}

		/** [Fee.Ui.ScrollItem_Base]矩形変更。
		*/
		public override void OnChangeParentRectX(int a_parent_x)
		{
			this.button.SetX(a_parent_x);
			this.text.SetX(a_parent_x);
		}

		/** [Fee.Ui.ScrollItem_Base]矩形変更。
		*/
		public override void OnChangeParentRectY(int a_parent_y)
		{
			this.button.SetY(a_parent_y + 1);
			this.text.SetY(a_parent_y);
		}

		/** [Fee.Ui.ScrollItem_Base]矩形変更。
		*/
		public override void OnChangeParentRectWH(int a_parent_w,int a_parent_h)
		{
			this.button.SetWH(a_parent_w,GetH() - 2);
			this.text.SetWH(0,0);
		}

		/** [Fee.Ui.ScrollItem_Base]クリップ矩形変更。
		*/
		public override void OnChangeParentClipRect(in Fee.Geometry.Rect2D_R<int> a_parent_rect)
		{
			this.button.SetClipRect(in a_parent_rect);
			this.text.SetClipRect(in a_parent_rect);
		}

		/** [Fee.Ui.ScrollItem_Base]描画プライオリティ変更。
		*/
		public override void OnChangeParentDrawPriority(long a_parent_drawpriority)
		{
			this.button.SetDrawPriority(a_parent_drawpriority + 100);
			this.text.SetDrawPriority(a_parent_drawpriority + 100);
		}

		/** [Fee.Ui.ScrollItem_Base]表示内。
		*/
		public override void OnViewIn()
		{
			this.button.SetVisible(true);
			this.text.SetVisible(true);
		}

		/** [Fee.Ui.ScrollItem_Base]表示外。
		*/
		public override void OnViewOut()
		{
			this.button.SetVisible(false);
			this.text.SetVisible(false);
		}
	}
}

