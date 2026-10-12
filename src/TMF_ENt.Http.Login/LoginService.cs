using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TMF_ENt.AES;

namespace TMF_ENt.Http.Login;

public class LoginService
{
	private const string _0 = "";

	private const string _1 = "";

	public static async Task<LoginResult> LoginAsync(string username, string password, string Hwid, string Vs, string api)
	{
		object url = api + "/api/V1/login";
		long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		object obj = $"username={username}&password={password}&timestamp={num}";
		object mD5Hash = AesHelper.GetMD5Hash((string)obj + "LKHIKNIBUNUMI892");
		object obj2 = new
		{
			username = username,
			password = password,
			hwid = Hwid,
			pc = await ComputerInfoHelper.GetComputerInfoAsync(),
			Vs = Vs,
			timestamp = num,
			sign = (string)mD5Hash
		};
		object plainText = JsonConvert.SerializeObject(obj2);
		object jsonContent = "\"" + AesHelper.Encrypt((string)plainText) + "\"";
		try
		{
			object obj3 = JObject.Parse(await HttpHelper.PostJsonAsync((string)url, (string)jsonContent));
			if (!((JObject)obj3).ContainsKey("encryptedResponse"))
			{
				return new LoginResult
				{
					Success = false,
					Message = "响应格式错误，未找到加密数据"
				};
			}
			object cipherText = ((JToken)obj3).Value<string>((object)"encryptedResponse");
			object obj4 = AesHelper.Decrypt((string)cipherText);
			object obj5 = JObject.Parse((string)obj4);
			long num2 = ((JToken)obj5).Value<long>((object)"timestamp");
			long num3 = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			long num4 = Math.Abs(num3 - num2);
			if (num4 > 5)
			{
				return new LoginResult
				{
					Success = false,
					Message = "数据包已过期，请重新登录"
				};
			}
			nint num5 = ((JToken)obj5).Value<int>((object)"code");
			if (num5 == 200)
			{
				JToken val = ((JObject)obj5)["data"];
				object token = ((val == null) ? null : ((object)val[(object)"token"])?.ToString()) ?? "";
				JToken val2 = ((JObject)obj5)["data"];
				object role = ((val2 == null) ? null : ((object)val2[(object)"role"])?.ToString()) ?? "";
				JToken val3 = ((JObject)obj5)["data"];
				object tile = ((val3 == null) ? null : ((object)val3[(object)"tile"])?.ToString()) ?? "";
				JToken val4 = ((JObject)obj5)["data"];
				object expiry = ((val4 == null) ? null : ((object)val4[(object)"expiry"])?.ToString()) ?? "";
				JToken val5 = ((JObject)obj5)["data"];
				int? num6;
				if (val5 == null)
				{
					num6 = null;
				}
				else
				{
					JToken val6 = val5[(object)"steer"];
					num6 = ((val6 != null) ? new int?(Extensions.Value<int>((IEnumerable<JToken>)val6)) : ((int?)null));
				}
				int? num7 = num6;
				nint num8 = num7.GetValueOrDefault();
				JToken val7 = ((JObject)obj5)["data"];
				object lang = ((val7 == null) ? null : ((object)val7[(object)"lang"])?.ToString()) ?? "";
				JToken val8 = ((JObject)obj5)["data"];
				object modules = ((val8 == null) ? null : ((object)val8[(object)"modules"])?.ToString()) ?? "";
				return new LoginResult
				{
					Success = true,
					Token = (string)token,
					role = (string)role,
					tile = (string)tile,
					expiry = (string)expiry,
					steer = (int)num8,
					lang = (string)lang,
					modules = (string)modules,
					Message = "登录成功"
				};
			}
			object message = (((JObject)obj5).ContainsKey("message") ? ((JToken)obj5).Value<string>((object)"message") : "未知错误");
			return new LoginResult
			{
				Success = false,
				Message = (string)message
			};
		}
		catch (TaskCanceledException)
		{
			return new LoginResult
			{
				Success = false,
				Message = "请求超时，请检查网络或服务是否可用"
			};
		}
		catch (Exception ex2)
		{
			object obj6 = ex2;
			return new LoginResult
			{
				Success = false,
				Message = "处理接口响应失败：" + ((Exception)obj6).Message
			};
		}
	}

	public static async Task<LoginResult> UploadResultAsync(string username, string password, string Hwid, string token, string output)
	{
		object url = "http://localhost:5136/api/V1/User/update";
		long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		object obj = $"username={username}&password={password}&timestamp={num}";
		object mD5Hash = AesHelper.GetMD5Hash((string)obj + "LKHIKNIBUNUMI892");
		object obj2 = new
		{
			username = username,
			password = password,
			hwid = Hwid,
			Token = token,
			output = output,
			timestamp = num,
			sign = (string)mD5Hash
		};
		object plainText = JsonConvert.SerializeObject(obj2);
		object jsonContent = "\"" + AesHelper.Encrypt((string)plainText) + "\"";
		try
		{
			object obj3 = JObject.Parse(await HttpHelper.PostJsonAsync((string)url, (string)jsonContent));
			if (!((JObject)obj3).ContainsKey("encryptedResponse"))
			{
				return new LoginResult
				{
					Success = false,
					Message = "响应格式错误，未找到加密数据"
				};
			}
			object cipherText = ((JToken)obj3).Value<string>((object)"encryptedResponse");
			object obj4 = AesHelper.Decrypt((string)cipherText);
			object obj5 = JObject.Parse((string)obj4);
			long num2 = ((JToken)obj5).Value<long>((object)"timestamp");
			long num3 = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			long num4 = Math.Abs(num3 - num2);
			if (num4 > 10)
			{
				return new LoginResult
				{
					Success = false,
					Message = "数据包已过期，请重新登录"
				};
			}
			nint num5 = ((JToken)obj5).Value<int>((object)"code");
			if (num5 == 200)
			{
				return new LoginResult
				{
					Success = true,
					Token = token,
					Message = "更新完成"
				};
			}
			object message = (((JObject)obj5).ContainsKey("message") ? ((JToken)obj5).Value<string>((object)"message") : "未知错误");
			return new LoginResult
			{
				Success = false,
				Message = (string)message
			};
		}
		catch (TaskCanceledException)
		{
			return new LoginResult
			{
				Success = false,
				Message = "请求超时，请检查网络或服务是否可用"
			};
		}
		catch (Exception ex2)
		{
			object obj6 = ex2;
			return new LoginResult
			{
				Success = false,
				Message = "网络连接丢失：" + ((Exception)obj6).Message
			};
		}
	}
}
