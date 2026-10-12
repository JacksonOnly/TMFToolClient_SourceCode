using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace SLA_Challenge;

public class CommonUtil
{
	public static byte[] HexStringToByteArray(string hexString)
	{
		hexString = hexString.Replace(" ", "");
		byte[] array = new byte[hexString.Length / 2];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
		}
		return array;
	}

	private static object _1(IntPtr ptr, uint length)
	{
		StringBuilder stringBuilder = new StringBuilder((int)(length * 2));
		for (int i = 0; i < (int)length; i++)
		{
			byte b = Marshal.ReadByte(ptr, i);
			stringBuilder.AppendFormat("{0:X2}", b);
		}
		return stringBuilder.ToString();
	}

	public static string Get(string url)
	{
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
		httpWebRequest.Method = "GET";
		httpWebRequest.ContentType = "text/html;charset=UTF-8";
		HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		Stream responseStream = httpWebResponse.GetResponseStream();
		StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
		string result = streamReader.ReadToEnd();
		streamReader.Close();
		responseStream.Close();
		return result;
	}
}
