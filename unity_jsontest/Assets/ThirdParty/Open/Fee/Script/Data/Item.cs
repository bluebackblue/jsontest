

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief データ。アイテム。
*/


/** Fee.Data
*/
namespace Fee.Data
{
	/** Item
	*/
	public class Item
	{
		/** ResultType
		*/
		public enum ResultType
		{
			/** 未定義。
			*/
			None,

			/** エラー。
			*/
			Error,

			/** アセット。
			*/
			Asset,
		}

		/** result_type
		*/
		private ResultType result_type;

		/** result_progress
		*/
		private float result_progress;

		/** result_errorstring
		*/
		private string result_errorstring;

		/** cancel_flag
		*/
		private bool cancel_flag;

		/** result_asset
		*/
		private Fee.Asset.Asset result_asset;

		/** constructor
		*/
		public Item()
		{
			//result_type
			this.result_type = ResultType.None;

			//result_progress
			this.result_progress = 0.0f;

			//result_errorstring
			this.result_errorstring = null;

			//cancel_flag
			this.cancel_flag = false;

			//result_asset
			this.result_asset = null;
		}

		/** 削除。
		*/
		private void Delete()
		{
		}

		/** 処理中。チェック。
		*/
		public bool IsBusy()
		{
			if(this.result_type == ResultType.None){
				return true;
			}
			return false;
		}

		/** キャンセル。設定。
		*/
		public void Cancel()
		{
			this.cancel_flag = true;
		}

		/** キャンセル。取得。
		*/
		public bool IsCancel()
		{
			return this.cancel_flag;
		}

		/** 結果。タイプ。取得。
		*/
		public ResultType GetResultType()
		{
			return this.result_type;
		}

		/** プログレス。設定。
		*/
		public void SetResultProgress(float a_result_progress)
		{
			this.result_progress = a_result_progress;
		}

		/** プログレス。取得。
		*/
		public float GetResultProgress()
		{
			return this.result_progress;
		}

		/** 結果。エラー文字。設定。
		*/
		public void SetResultErrorString(string a_error_string)
		{
			this.result_type = ResultType.Error;

			this.result_errorstring = a_error_string;
		}

		/** 結果。エラー文字。取得。
		*/
		public string GetResultErrorString()
		{
			return this.result_errorstring;
		}

		/** 結果。アセット。設定。
		*/
		public void SetResultAsset(Fee.Asset.Asset a_asset)
		{
			this.result_type = ResultType.Asset;

			this.result_asset = a_asset;
		}

		/** 結果。アセット。取得。
		*/
		public Fee.Asset.Asset GetResultAsset()
		{
			return this.result_asset;
		}

		/** GetResultAssetType
		*/
		public Fee.Asset.AssetType GetResultAssetType()
		{
			if(this.result_asset != null){
				return this.result_asset.GetAssetType();
			}
			return Asset.AssetType.None;
		}

		/** GetResultAssetBinary
		*/
		public byte[] GetResultAssetBinary()
		{
			if(this.result_asset != null){
				return this.result_asset.GetBinary();
			}
			return null;
		}

		/** GetResultAssetTexture
		*/
		public UnityEngine.Texture2D GetResultAssetTexture()
		{
			if(this.result_asset != null){
				return this.result_asset.GetTexture();
			}
			return null;
		}

		/** GetResultAssetText
		*/
		public string GetResultAssetText()
		{
			if(this.result_asset != null){
				return this.result_asset.GetText();
			}
			return null;
		}

		/** GetResultAssetPrefab
		*/
		public UnityEngine.GameObject GetResultAssetPrefab()
		{
			if(this.result_asset != null){
				return this.result_asset.GetPrefab();
			}
			return null;
		}
	}
}

