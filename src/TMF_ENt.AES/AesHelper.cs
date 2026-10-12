using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TMF_ENt.AES;

public static class AesHelper
{
	private static readonly object _0 = Encoding.UTF8.GetBytes("KFJIDAkanidm156l");

	private static readonly object _1 = Encoding.UTF8.GetBytes("IJIBUMOlOHNIuual");

	public static string Encrypt(string plainText)
	{
		using Aes aes = Aes.Create();
		aes.Key = (byte[])_0;
		aes.IV = (byte[])_1;
		using MemoryStream memoryStream = new MemoryStream();
		using (CryptoStream stream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
		{
			using StreamWriter streamWriter = new StreamWriter(stream);
			streamWriter.Write(plainText);
		}
		return Convert.ToBase64String(memoryStream.ToArray());
	}

	public static string GetMD5Hash(string input)
	{
		using MD5 mD = MD5.Create();
		byte[] bytes = Encoding.UTF8.GetBytes(input);
		byte[] array = mD.ComputeHash(bytes);
		return BitConverter.ToString(array).Replace("-", "").ToLower();
	}

	public static string Decrypt(string cipherText)
	{
		byte[] buffer = Convert.FromBase64String(cipherText);
		using Aes aes = Aes.Create();
		aes.Key = (byte[])_0;
		aes.IV = (byte[])_1;
		using MemoryStream stream = new MemoryStream(buffer);
		using CryptoStream stream2 = new CryptoStream(stream, aes.CreateDecryptor(), CryptoStreamMode.Read);
		using StreamReader streamReader = new StreamReader(stream2);
		return streamReader.ReadToEnd();
	}
}
