

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief ダイクストラ法。リンク。
*/


/** Fee.Dijkstra
*/
namespace Fee.Dijkstra
{
	/** Link_Base
	*/
	public interface Link_Base
	{
		/** [Link_Base]接続先ノードへの到達コスト。取得。
		*/
		long GetToCost(Fee.Dijkstra.Instance_Base a_instance);

		/** [Link_Base]接続先ノードへの到達コスト。設定。
		*/
		void SetToCost(Fee.Dijkstra.Instance_Base a_instance,long a_to_cost);
	}

	/** Link
	*/
	public class Link<NODEKEY,NODEDATA,LINKDATA>
		where NODEDATA : Node_Base
		where LINKDATA : Link_Base
	{
		/** リンク追加情報。
		*/
		public LINKDATA linkdata;

		/** 接続先ノード。
		*/
		private Node<NODEKEY,NODEDATA,LINKDATA> to_node;

		/** constructor
		*/
		public Link(LINKDATA a_linkdata,Node<NODEKEY,NODEDATA,LINKDATA> a_to_node)
		{
			this.linkdata = a_linkdata;
			this.to_node = a_to_node;
		}

		/** 接続先ノードへの到達コスト。設定。
		*/
		public void SetToCost(Fee.Dijkstra.Instance_Base a_instance,long a_to_cost)
		{
			this.linkdata.SetToCost(a_instance,a_to_cost);
		}

		/** 接続先ノードへの到達コスト。取得。
		*/
		public long GetToCost(Fee.Dijkstra.Instance_Base a_instance)
		{
			return this.linkdata.GetToCost(a_instance);
		}

		/** 接続先ノード。設定。
		*/
		public void SetToNode(Node<NODEKEY,NODEDATA,LINKDATA> a_to_node)
		{
			this.to_node = a_to_node;
		}

		/** 接続先ノード。取得。
		*/
		public Node<NODEKEY,NODEDATA,LINKDATA> GetToNode()
		{
			return this.to_node;
		}
	}
}

