

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief オーディオ。バンク。
*/


/** Fee.Audio
*/
namespace Fee.Audio
{
	/** Bank
	*/
	public class Bank
	{
		/** pack_audioclip
		*/
		public Pack_AudioClip pack_audioclip_monobehaviour;

		/** pack_soundpool
		*/
		public Pack_SoundPool pack_soundpool;

		/** constructor
		*/
		public Bank(Pack_AudioClip a_pack)
		{
			this.pack_audioclip_monobehaviour = a_pack;
			this.pack_soundpool = null;
		}

		/** constructor
		*/
		public Bank(Pack_SoundPool a_pack)
		{
			this.pack_audioclip_monobehaviour = null;
			this.pack_soundpool = a_pack;
		}

		/** 個数。取得。
		*/
		public int GetCount()
		{
			if(this.pack_audioclip_monobehaviour != null){
				return this.pack_audioclip_monobehaviour.audioclip_list.Count;
			}

			if(this.pack_soundpool != null){
				return this.pack_soundpool.name_list.Count;
			}

			return 0;
		}

		/** オーディオクリップ。取得。
		*/
		public void GetAudioClip(int a_index,out UnityEngine.AudioClip a_audioclip,out float a_volume)
		{
			if(this.pack_audioclip_monobehaviour != null){
				if((0<=a_index)&&(a_index<this.pack_audioclip_monobehaviour.audioclip_list.Count)){
					if(this.pack_audioclip_monobehaviour.audioclip_list[a_index] != null){
						a_audioclip = this.pack_audioclip_monobehaviour.audioclip_list[a_index];
						a_volume = this.pack_audioclip_monobehaviour.volume_list[a_index];
						return;
					}
				}
			}
			a_audioclip = null;
			a_volume = 0.0f;
		}

		/** サウンドプール。取得。
		*/
		public void GetSoundPool(int a_index,out string a_name,out float a_volume)
		{
			if(this.pack_soundpool != null){
				if((0<=a_index)&&(a_index<this.pack_soundpool.name_list.Count)){
					if(this.pack_soundpool.name_list[a_index] != null){
						a_name = this.pack_soundpool.name_list[a_index];
						a_volume = this.pack_soundpool.volume_list[a_index];
						return;
					}
				}
			}
			a_name = null;
			a_volume = 0.0f;
		}

		/** ロードメイン。
		*/
		public bool LoadMain()
		{
			if(this.pack_audioclip_monobehaviour != null){
				for(int ii=0;ii<this.pack_audioclip_monobehaviour.audioclip_list.Count;ii++){
					if(this.pack_audioclip_monobehaviour.audioclip_list[ii] != null){
						this.pack_audioclip_monobehaviour.audioclip_list[ii].LoadAudioData();
					}
				}
			}

			if(this.pack_soundpool != null){
				for(int ii=0;ii<this.pack_soundpool.name_list.Count;ii++){
					if(this.pack_soundpool.name_list[ii] != null){
						Fee.Audio.Audio.GetInstance().GetSoundPool().Load(this.pack_soundpool.name_list[ii]);
					}
				}
			}

			return true;
		}

		/** アンロードメイン。
		*/
		public bool UnloadMain()
		{
			if(this.pack_audioclip_monobehaviour != null){
				for(int ii=0;ii<this.pack_audioclip_monobehaviour.audioclip_list.Count;ii++){
					if(this.pack_audioclip_monobehaviour.audioclip_list[ii] != null){
						this.pack_audioclip_monobehaviour.audioclip_list[ii].UnloadAudioData();
					}
				}
			}

			if(this.pack_soundpool != null){
				for(int ii=0;ii<this.pack_soundpool.name_list.Count;ii++){
					if(this.pack_soundpool.name_list[ii] != null){
						Fee.Audio.Audio.GetInstance().GetSoundPool().UnLoad(this.pack_soundpool.name_list[ii]);
					}
				}
			}

			return true;
		}
	}
}

