using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TMF_ENt.AES;

namespace TMF_ENt.Http;

public static class HttpHelper
{
	private static readonly object _0 = new HttpClient
	{
		Timeout = TimeSpan.FromSeconds(10.0)
	};

	public static async Task<JObject> Get(string api, string Url)
	{
		object url = api + Url;
		try
		{
			object obj = JObject.Parse(await GetAsync((string)url));
			if (!((JObject)obj).ContainsKey("encryptedResponse"))
			{
				return JObject.FromObject((object)new
				{
					message = "响应格式错误，未找到加密字段"
				});
			}
			object cipherText = ((JToken)obj).Value<string>((object)"encryptedResponse");
			object obj2 = AesHelper.Decrypt((string)cipherText);
			object obj3 = JObject.Parse((string)obj2);
			long num = ((JToken)obj3).Value<long>((object)"timestamp");
			long num2 = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			long num3 = Math.Abs(num2 - num);
			if (num3 > 6)
			{
				return JObject.FromObject((object)new
				{
					message = "数据包已过期"
				});
			}
			return (JObject)obj3;
		}
		catch (Exception ex)
		{
			object obj4 = ex;
			return JObject.FromObject((object)new
			{
				message = "发生错误: " + ((Exception)obj4).Message
			});
		}
	}

	public static async Task<JObject> Post(string api, string raw)
	{
		try
		{
			object obj = JObject.Parse(await PostJsonAsync(api, raw, 20));
			if (!((JObject)obj).ContainsKey("encryptedResponse"))
			{
				return JObject.FromObject((object)new
				{
					msg = "响应格式错误，未找到加密字段"
				});
			}
			object cipherText = ((JToken)obj).Value<string>((object)"encryptedResponse");
			object obj2 = AesHelper.Decrypt((string)cipherText);
			object obj3 = JObject.Parse((string)obj2);
			long num = ((JToken)obj3).Value<long>((object)"timestamp");
			long num2 = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			long num3 = Math.Abs(num2 - num);
			if (num3 > 25)
			{
				return JObject.FromObject((object)new
				{
					message = "数据包过期！请重新登录"
				});
			}
			return (JObject)obj3;
		}
		catch (TaskCanceledException)
		{
			return JObject.FromObject((object)new
			{
				code = 500,
				message = "请求超时，请检查网络或服务是否可用"
			});
		}
		catch (Exception ex2)
		{
			object obj4 = ex2;
			return JObject.FromObject((object)new
			{
				code = 500,
				message = ((Exception)obj4).Message
			});
		}
	}

	public static async Task<string> GetAsync(string url)
	{
		object obj = await ((HttpClient)_0).GetAsync(url);
		((HttpResponseMessage)obj).EnsureSuccessStatusCode();
		return await ((HttpResponseMessage)obj).Content.ReadAsStringAsync();
	}

	public static async Task<string> PostJsonAsync(string url, string jsonContent, int timeoutSeconds = 10)
	{
		object obj = new HttpClient();
		try
		{
			((HttpClient)obj).Timeout = TimeSpan.FromSeconds(timeoutSeconds);
			((HttpClient)obj).DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			object content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
			object obj2 = await ((HttpClient)obj).PostAsync(url, (HttpContent)content);
			((HttpResponseMessage)obj2).EnsureSuccessStatusCode();
			return await ((HttpResponseMessage)obj2).Content.ReadAsStringAsync();
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}
}
