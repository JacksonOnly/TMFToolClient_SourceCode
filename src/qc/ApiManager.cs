using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace qc;

public class ApiManager
{
	private static readonly object _0 = new HttpClient();

	private object _1 = new List<string> { "http://tmftool-api.ummx.cn" };

	private object _2 = null;

	public async Task<bool> PingAsync()
	{
		JToken obj3 = default;
		foreach (string item in (List<string>)_1)
		{
			try
			{
				object obj = await ((HttpClient)_0).GetAsync(item + "/api/V2/ping");
				if (((HttpResponseMessage)obj).IsSuccessStatusCode)
				{
					object obj2 = JsonConvert.DeserializeObject<JObject>(await ((HttpResponseMessage)obj).Content.ReadAsStringAsync());
					if (((JObject)obj2).TryGetValue("status", out obj3) && obj3.ToString() == "success")
					{
						_2 = item;
						return true;
					}
					obj3 = null;
				}
			}
			catch
			{
			}
		}
		return false;
	}

	public string GetActiveApi()
	{
		return (string)(_2 ?? ((List<string>)_1)[0]);
	}
}
