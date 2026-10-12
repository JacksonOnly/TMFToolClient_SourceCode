using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TMF_ENt.Http.Login;

public class LoginResult
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private IntPtr _0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object _1 = "";

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object _2 = "";

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object _3 = "";

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object _4 = "";

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object _5 = "";

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object _6 = "";

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object _7 = "";

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IntPtr _8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object _9 = "";

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

	public string Token
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

	public string role
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

	public string Message
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

	public string expiry
	{
		[CompilerGenerated]
		get
		{
			return (string)_4;
		}
		[CompilerGenerated]
		set
		{
			_4 = value;
		}
	}

	public string tile
	{
		[CompilerGenerated]
		get
		{
			return (string)_5;
		}
		[CompilerGenerated]
		set
		{
			_5 = value;
		}
	}

	public string modules
	{
		[CompilerGenerated]
		get
		{
			return (string)_6;
		}
		[CompilerGenerated]
		set
		{
			_6 = value;
		}
	}

	public string lang
	{
		[CompilerGenerated]
		get
		{
			return (string)_7;
		}
		[CompilerGenerated]
		set
		{
			_7 = value;
		}
	}

	public int steer
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)_8;
		}
		[CompilerGenerated]
		set
		{
			_8 = (IntPtr)value;
		}
	}

	public string Comm
	{
		[CompilerGenerated]
		get
		{
			return (string)_9;
		}
		[CompilerGenerated]
		set
		{
			_9 = value;
		}
	}
}
