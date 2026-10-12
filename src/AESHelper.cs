using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class AESHelper
{
	public static string Encrypt(string plainText, out string key, out string iv)
	{
		using Aes aes = Aes.Create();
		aes.GenerateKey();
		aes.GenerateIV();
		key = Convert.ToBase64String(aes.Key);
		iv = Convert.ToBase64String(aes.IV);
		ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);
		using MemoryStream memoryStream = new MemoryStream();
		using (CryptoStream stream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
		{
			using StreamWriter streamWriter = new StreamWriter(stream);
			streamWriter.Write(plainText);
		}
		return Convert.ToBase64String(memoryStream.ToArray());
	}

	public static string Decrypt(string cipherText, string key, byte[] iv)
	{
		using Aes aes = Aes.Create();
		aes.Key = Encoding.UTF8.GetBytes(key);
		aes.IV = iv;
		ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);
		using MemoryStream stream = new MemoryStream(Convert.FromBase64String(cipherText));
		using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
		using StreamReader streamReader = new StreamReader(stream2);
		return streamReader.ReadToEnd();
	}
}
