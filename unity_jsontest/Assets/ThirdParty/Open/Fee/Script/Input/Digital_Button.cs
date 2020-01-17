

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief 入力。デジタル。ボタン。
*/


/** Fee.Input
*/
namespace Fee.Input
{
	/** Digital_Button
	*/
	public struct Digital_Button
	{
		/** flag
		*/
		public bool on_old;
		public bool on;
		public bool down;
		public bool up;

		public bool rapid;
		public int rapid_time;
		public int rapid_time_max;

		/** リセット。
		*/
		public void Reset()
		{
			this.on_old = false;
			this.on = false;
			this.down = false;
			this.up = false;

			this.rapid = false;
			this.rapid_time = 0;
			this.rapid_time_max = Config.DEFAULT_RAPID_TIME_MAX;
		}

		/** 設定。
		*/
		public void Set(bool a_flag)
		{
			this.on_old = this.on;
			this.on = a_flag;
		}

		/** 更新。
		*/
		public void Main()
		{
			if((this.on == true)&&(this.on_old == false)){
				//ダウン。
				this.down = true;
				this.up = false;

				this.rapid = true;
				this.rapid_time = 0;
			}else if((this.on == false)&&(this.on_old == true)){
				//アップ。
				this.up = true;
				this.down = false;

				this.rapid = false;
				this.rapid_time = 0;
			}else if(this.on == true){
				//オン。

				this.down = false;
				this.up = false;

				this.rapid_time = (this.rapid_time + 1) % this.rapid_time_max; 
				if(this.rapid_time == 0){
					this.rapid = true;
				}else{
					this.rapid = false;
				}
			}else{
				this.down = false;
				this.up = false;
			}
		}
	}
}

