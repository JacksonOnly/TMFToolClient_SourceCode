using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace qc;

internal class Apis
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static object _0;

	public static string Api
	{
		[CompilerGenerated]
		get
		{
			return (string)_0;
		}
		[CompilerGenerated]
		set
		{
			_0 = value;
		}
	}

	public static void SetApi(string apiUrl)
	{
		Api = apiUrl;
	}

	public static string GetApi()
	{
		return Api;
	}
}
