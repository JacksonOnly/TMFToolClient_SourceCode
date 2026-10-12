using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ServerAuth;

internal class DataAuth
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private static object _0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static IntPtr _1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static object _2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private static object _3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private static IntPtr _4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static IntPtr _5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private static object _6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private static object _7;

	public static string BlobKey
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

	public static bool TokenExist
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)_1 != 0;
		}
		[CompilerGenerated]
		set
		{
			_1 = (IntPtr)(value ? 1 : 0);
		}
	}

	public static string CreditBalance
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

	public static string ServerNum
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

	public static bool AuhtResult
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)_4 != 0;
		}
		[CompilerGenerated]
		set
		{
			_4 = (IntPtr)(value ? 1 : 0);
		}
	}

	public static bool serverauto
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)_5 != 0;
		}
		[CompilerGenerated]
		set
		{
			_5 = (IntPtr)(value ? 1 : 0);
		}
	}

	public static string authStatus
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

	public static string SignedKey
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
}
