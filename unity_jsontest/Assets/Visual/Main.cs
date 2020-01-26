

/** Visual
*/
namespace Visual
{
	/** メイン処理。
	*/
	public class Main
	{
		/** deleter
		*/
		private Fee.Deleter.Deleter deleter;

		/** viewer
		*/
		private JsonViewer viewer;

		/** constructor
		*/
		public Main()
		{
			//deleter
			this.deleter = new Fee.Deleter.Deleter();

			//viewer
			this.viewer = new JsonViewer();

			//ＪＳＯＮ化するリスト。
			System.Collections.Generic.Dictionary<string,System.Object> t_list = new System.Collections.Generic.Dictionary<string,System.Object>();
			{
				ulong t_list_1 = 100;
				t_list.Add("item1",t_list_1);

				System.Collections.Generic.List<System.Object> t_list_2 = new System.Collections.Generic.List<object>();
				t_list.Add("item2",t_list_2);
				{
					System.Collections.Generic.List<System.Object> t_list_2_1 = new System.Collections.Generic.List<object>();
					t_list_2.Add(t_list_2_1);
					{
						t_list_2_1.Add(ulong.MaxValue);
						t_list_2_1.Add(-100);
						t_list_2_1.Add("asdf");
						t_list_2_1.Add(new int[]{1,2,3});
						t_list_2_1.Add(3.33f);
						t_list_2_1.Add(true);
						t_list_2_1.Add(100.3m);
					}

					string t_list_2_2 = "xyz";
					t_list_2.Add(t_list_2_2);
				}
				System.Collections.Generic.List<System.Object> t_list_3 = new System.Collections.Generic.List<object>();
				t_list.Add("item3",t_list_3);

				System.Collections.Generic.List<System.Object> t_list_4 = new System.Collections.Generic.List<object>();
				t_list.Add("item4",t_list_4);
			}

			//ＪＳＯＮをビュワーに登録。
			this.viewer.CreateScroll(0,Fee.JsonItem.Convert.ObjectToJsonItem(t_list));
		}

		/** 削除。
		*/
		public void OnDelete()
		{
			this.viewer.OnDelete();
		}

		/** FixedUpdate
		*/
		public void FixedUpdate()
		{
			this.viewer.FixedUpdate();
		}
	}
}

