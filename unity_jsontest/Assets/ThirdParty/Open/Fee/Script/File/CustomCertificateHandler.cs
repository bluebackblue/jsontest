

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * https://github.com/bluebackblue/fee/blob/master/LICENSE.txt
 * @brief ファイル。自己証明書。
*/


/** Fee.File
*/
namespace Fee.File
{
	/** CustomCertificateHandler
	*/
	public class CustomCertificateHandler : UnityEngine.Networking.CertificateHandler
	{
		/** publickey_string
		*/
		private string publickey_string;

		/** publickey_binary
		*/
		private byte[] publickey_binary;

		/** errorstring
		*/
		private string errorstring;

		/** receive_publickey
		*/
		private string receive_publickey;

		/** constructor
		*/
		public CustomCertificateHandler(string a_publickey_string)
		{
			//publickey_string
			this.publickey_string = a_publickey_string;

			//publickey_binary
			this.publickey_binary = null;

			//errorstring
			this.errorstring = null;

			//receive_publickey
			this.receive_publickey = null;
		}

		/** constructor
		*/
		public CustomCertificateHandler(byte[] a_publickey_binary)
		{
			//publickey_string
			this.publickey_string = null;

			//publickey_binary
			this.publickey_binary = a_publickey_binary;

			//errorstring
			this.errorstring = null;

			//receive_publickey
			this.receive_publickey = null;
		}

		/** GetErrorString
		*/
		public string GetErrorString()
		{
			return this.errorstring;
		}

		/** GetReceivePublicKey
		*/
		public string GetReceivePublicKey()
		{
			return this.receive_publickey;
		}

		/** 初期化チェック。
		*/
		public void InitializeCheck()
		{
			Tool.Assert(this.errorstring == null);
			this.errorstring = "Initialize";
		}

		/** ValidateCertificate
		*/
		protected override bool ValidateCertificate(byte[] a_certificate_data)
		{
			this.errorstring = "Call ValidateCertificate";

			try{
				using(System.Security.Cryptography.X509Certificates.X509Certificate2 t_certificate = new System.Security.Cryptography.X509Certificates.X509Certificate2(a_certificate_data)){

					this.receive_publickey = t_certificate.GetPublicKeyString();

					if(this.publickey_string != null){
						//文字列。

						if(t_certificate.GetPublicKeyString() == this.publickey_string){
							this.errorstring = "Success(String Public Key)";
							return true;
						}else{
							this.errorstring = "Mismatch String Error(String Public Key)";
						}
					}else if(this.publickey_binary != null){
						//バイナリ。

						byte[] t_binary = t_certificate.GetPublicKey();
						if(t_binary.Length == this.publickey_binary.Length){
							bool t_check = true;
							for(int ii=0;ii<t_binary.Length;ii++){
								if(t_binary[ii] != this.publickey_binary[ii]){
									t_check = false;
									break;
								}
							}
							if(t_check == true){
								this.errorstring = "Success(Binary Public Key)";
								return true;
							}else{
								this.errorstring = "Mismatch Binary Error(Binary Public Key)";
							}
						}else{
							this.errorstring = "Mismatch Binary Length Error(Binary Public Key)";
						}
					}else{
						//不明。

						this.errorstring = "Unknown Type Error";
					}
				}
			}catch(System.Exception t_exception){
				this.errorstring = "Exception : " + t_exception.Message;
			}

			return false;
		}
	}
}

