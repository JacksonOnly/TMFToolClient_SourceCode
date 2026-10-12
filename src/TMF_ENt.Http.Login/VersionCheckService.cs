using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TMF_ENt.AES;

namespace TMF_ENt.Http.Login;

public static class VersionCheckService
{
	private const string _0 = "";

	private const string m_1 = "";

	public static async Task<VersionCheckResult> CheckVersionAsync()
	{
		object url = "http://api.ummx.cn/api/V1/User/updateInfo";
		try
		{
			object obj = JObject.Parse(await HttpHelper.GetAsync((string)url));
			if (!((JObject)obj).ContainsKey("encryptedResponse"))
			{
				return new VersionCheckResult
				{
					Success = false,
					Message = "响应格式错误，未找到加密字段"
				};
			}
			object cipherText = ((JToken)obj).Value<string>((object)"encryptedResponse");
			object obj2 = AesHelper.Decrypt((string)cipherText);
			object obj3 = JObject.Parse((string)obj2);
			JToken val = ((JObject)obj3)["data"];
			object obj4 = ((val == null) ? null : ((object)val[(object)"version"])?.ToString()) ?? "";
			JToken val2 = ((JObject)obj3)["data"];
			object downloadUrl = ((val2 == null) ? null : ((object)val2[(object)"downloadLink"])?.ToString()) ?? "";
			JToken val3 = ((JObject)obj3)["data"];
			object obj5 = ((val3 == null) ? null : ((object)val3[(object)"announcement"])?.ToString()) ?? "";
			long num = ((JToken)obj3).Value<long>((object)"timestamp");
			long num2 = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			long num3 = Math.Abs(num2 - num);
			if (num3 > 5)
			{
				return new VersionCheckResult
				{
					Success = false,
					Message = "数据包已过期"
				};
			}
			if ((int)_1(obj4, "1.0.0") > 0)
			{
				VersionCheckResult versionCheckResult = new VersionCheckResult();
				versionCheckResult.Success = true;
				versionCheckResult.Message = "发现新版本：" + (string)obj4 + "\n公告：" + (string)obj5 + "\n是否前往下载?";
				versionCheckResult.ServerVersion = (string)obj4;
				versionCheckResult.DownloadUrl = (string)downloadUrl;
				return versionCheckResult;
			}
			return new VersionCheckResult
			{
				Success = true,
				Message = "当前为最新版本：1.0.0"
			};
		}
		catch (Exception ex)
		{
			object obj6 = ex;
			return new VersionCheckResult
			{
				Success = false,
				Message = "版本检测失败：" + ((Exception)obj6).Message
			};
		}
	}

	private static uint _1(object v1, object v2)
	{
		Version version = new Version((string)v1);
		Version value = new Version((string)v2);
		return (uint)version.CompareTo(value);
	}
}
