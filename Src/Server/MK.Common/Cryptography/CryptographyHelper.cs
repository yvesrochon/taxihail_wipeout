﻿using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace apcurium.MK.Common.Cryptography
{
    public static class CryptographyHelper
    {
        public static byte[] GetHash(string inputString)
        {
            var md5Hasher = MD5.Create();
            return md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static byte[] GetHash(byte[] inputBytes)
        {
            var md5Hasher = MD5.Create();
            return md5Hasher.ComputeHash(inputBytes);
        }

        public static string GetHashString(string inputString)
        {
            if (inputString == null)
            {
                return null;
            }

            var sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        public static string GetHashString(byte[] inputBytes)
        {
            if (inputBytes == null)
            {
                return null;
            }

            var sb = new StringBuilder();
            foreach (byte b in GetHash(inputBytes))
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

		public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] key, byte[] initVector)
		{
			byte[] encrypted;
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.KeySize = 128;
				aesAlg.IV = initVector;
				aesAlg.Key = key;

				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

				using (MemoryStream msEncrypt = new MemoryStream())
				{
					using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
						{
							swEncrypt.Write(plainText);
						}
						encrypted = msEncrypt.ToArray();
					}
				}
			}

			return encrypted;
		}

		public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] key, byte[] initVector)
		{
			string plaintext = null;

			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.KeySize = 128;
				aesAlg.IV = initVector;
				aesAlg.Key = key;

				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

				using (MemoryStream msDecrypt = new MemoryStream(cipherText))
				{
					using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader srDecrypt = new StreamReader(csDecrypt))
						{
							plaintext = srDecrypt.ReadToEnd();
						}
					}
				}

			}

			return plaintext;
		}
    }
}
