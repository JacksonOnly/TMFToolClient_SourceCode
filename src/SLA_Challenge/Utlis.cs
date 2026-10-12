using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace SLA_Challenge;

public class Utlis
{
	private static object _0 = "5F4s81sbtO6KyhibL3dftN47fAbssNFH";

	private static readonly object _1 = new HttpClient();

	public static async Task<string> GetIPArea(string ip)
	{
		object obj = (object)new RestClient("https://tool.lu/ip/ajax.html", (ConfigureRestClient)null, (ConfigureHeaders)null, (ConfigureSerialization)null);
		object obj2 = (object)new RestRequest
		{
			Method = (Method)1
		};
		RestRequestExtensions.AddHeader((RestRequest)obj2, "Origin", "https://tool.lu");
		RestRequestExtensions.AddHeader((RestRequest)obj2, "Referer", "https://tool.lu/ip/");
		RestRequestExtensions.AddHeader((RestRequest)obj2, "User-Agent", "Mozilla/5.0 (Linux; Android 13; Pixel 7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Mobile Safari/537.36 Edg/121.0.0.0");
		RestRequestExtensions.AddHeader((RestRequest)obj2, "X-Requested-With", "XMLHttpRequest");
		return ((object)JObject.Parse(((RestResponseBase)(await RestClientExtensions.PostAsync((IRestClient)obj, (RestRequest)obj2, default(CancellationToken)))).Content)["ip2region"]).ToString();
	}

	public static async Task<string> Request(string url)
	{
		try
		{
			return ((object)JObject.Parse(await (await new HttpClient().GetAsync(url)).Content.ReadAsStringAsync())).ToString();
		}
		catch (Exception)
		{
		}
		return "{\"code\":-200,\"msg\":\"处理接口响应失败\"}";
	}

	public static async Task<string> wumingRequest(string url)
	{
		try
		{
			object obj = await ((HttpClient)_1).GetAsync(url);
			if (!((HttpResponseMessage)obj).IsSuccessStatusCode)
			{
				return "处理接口响应失败！";
			}
			return await ((HttpResponseMessage)obj).Content.ReadAsStringAsync();
		}
		catch (Exception ex)
		{
			object obj2 = ex;
			return ((Exception)obj2).Message;
		}
	}

	public static string AesEncrypt(string EncryptStr, string Key)
	{
		try
		{
			byte[] bytes = Encoding.UTF8.GetBytes(Key);
			byte[] bytes2 = Encoding.UTF8.GetBytes(EncryptStr);
			byte[] array = new RijndaelManaged
			{
				Key = bytes,
				Mode = CipherMode.ECB,
				Padding = PaddingMode.PKCS7
			}.CreateEncryptor().TransformFinalBlock(bytes2, 0, bytes2.Length);
			return Convert.ToBase64String(array, 0, array.Length);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static string AesDecrypt(string DecryptStr, string Key)
	{
		try
		{
			byte[] bytes = Encoding.UTF8.GetBytes(Key);
			byte[] array = Convert.FromBase64String(DecryptStr);
			byte[] bytes2 = new RijndaelManaged
			{
				Key = bytes,
				Mode = CipherMode.ECB,
				Padding = PaddingMode.PKCS7
			}.CreateDecryptor().TransformFinalBlock(array, 0, array.Length);
			return Encoding.UTF8.GetString(bytes2);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static string B64Encode(string B64Str)
	{
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(B64Str));
	}

	public static string B64Decode(string B64Str)
	{
		return Encoding.UTF8.GetString(Convert.FromBase64String(B64Str));
	}
}
