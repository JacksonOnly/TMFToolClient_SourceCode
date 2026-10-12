using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TMF_ENt.Http.Login;

public class VersionCheckResult
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IntPtr _0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object _1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object _2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object _3;

	public bool Success
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)_0 != 0;
		}
		[CompilerGenerated]
		set
		{
			_0 = (IntPtr)(value ? 1 : 0);
		}
	}

	public string Message
	{
		[CompilerGenerated]
		get
		{
			return (string)_1;
		}
		[CompilerGenerated]
		set
		{
			_1 = value;
		}
	}

	public string ServerVersion
	{
		[CompilerGenerated]
		get
		{
			return (string)_2;
		}
		[CompilerGenerated]
		set
		{
			_2 = value;
		}
	}

	public string DownloadUrl
	{
		[CompilerGenerated]
		get
		{
			return (string)_3;
		}
		[CompilerGenerated]
		set
		{
			_3 = value;
		}
	}
}
