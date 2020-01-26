

/** Visual
*/
namespace Visual
{
	/** JsonViewer
	*/
	public class JsonViewer
	{
		/** scroll
		*/
		private System.Collections.Generic.List<Fee.Ui.Scroll<JsonViewer_Item>> scroll;

		/** DrawPriority
		*/
		private const long DrawPriority = 100;

		/** constructor
		*/
		public JsonViewer()
		{
			this.scroll = new System.Collections.Generic.List<Fee.Ui.Scroll<JsonViewer_Item>>();
		}

		/** FixedUpdate
		*/
		public void FixedUpdate()
		{
			for(int ii=0;ii<this.scroll.Count;ii++){
				this.scroll[ii].DragScrollUpdate();
			}
		}

		/** スクロール削除。
		*/
		public void DeleteScroll(int a_layer)
		{
			while(this.scroll.Count > a_layer){
				int t_layer = this.scroll.Count - 1;

				for(int ii=0;ii<this.scroll[t_layer].GetListCount();ii++){
					this.scroll[t_layer].GetItem(ii).OnDelete();
				}
				this.scroll[t_layer].OnDelete();
				this.scroll.RemoveAt(t_layer);
			}
		}

		/** 削除。
		*/
		public void OnDelete()
		{
			this.DeleteScroll(0);
		}

		/** スクロール作成。
		*/
		public void CreateScroll(int a_layer,Fee.JsonItem.JsonItem a_parent_jsonitem)
		{
			this.DeleteScroll(a_layer);

			Fee.Ui.Scroll<JsonViewer_Item> t_scroll = Fee.Ui.Scroll<JsonViewer_Item>.Create(null,DrawPriority,Fee.Ui.Scroll_Type.Vertical,JsonViewer_Item.GetH());
			{
				t_scroll.SetRect(100 + this.scroll.Count * (JsonViewer_Item.GetW() + 2),100,JsonViewer_Item.GetW(),Fee.Render2D.Config.VIRTUAL_H - 200);

				switch(a_parent_jsonitem.GetValueType()){
				case Fee.JsonItem.ValueType.AssociativeArray:
					{
						if(a_parent_jsonitem.GetListMax() == 0){
							JsonViewer_Item t_scrollitem = new JsonViewer_Item("リストが空",this,this.scroll.Count,null);
							t_scroll.PushItem(t_scrollitem);
						}else{
							foreach(string t_key_string in a_parent_jsonitem.GetAssociativeKeyList()){
								JsonViewer_Item t_scrollitem = new JsonViewer_Item(t_key_string,this,this.scroll.Count,a_parent_jsonitem.GetItem(t_key_string));
								t_scroll.PushItem(t_scrollitem);
							}
						}
					}break;
				case Fee.JsonItem.ValueType.IndexArray:
					{
						if(a_parent_jsonitem.GetListMax() == 0){
							JsonViewer_Item t_scrollitem = new JsonViewer_Item("リストが空",this,this.scroll.Count,null);
							t_scroll.PushItem(t_scrollitem);
						}else{
							for(int ii=0;ii<a_parent_jsonitem.GetListMax();ii++){
								JsonViewer_Item t_scrollitem = new JsonViewer_Item("[" + ii.ToString() + "]",this,this.scroll.Count,a_parent_jsonitem.GetItem(ii));
								t_scroll.PushItem(t_scrollitem);
							}
						}
					}break;
				default:
					{
						JsonViewer_Item t_scrollitem = new JsonViewer_Item("",this,this.scroll.Count,a_parent_jsonitem);
						t_scroll.PushItem(t_scrollitem);
					}break;
				}
			}
			this.scroll.Add(t_scroll);
		}
	}
}

