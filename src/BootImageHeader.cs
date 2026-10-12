using System.Diagnostics;
using System.Runtime.CompilerServices;

internal class BootImageHeader
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object _0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private uint _1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private uint _2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private uint _3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private uint _4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private uint _5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private uint _6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private uint _7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private uint _8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object _9;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object a;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object b;

	public string Magic
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

	public uint KernelSize
	{
		[CompilerGenerated]
		get
		{
			return _1;
		}
		[CompilerGenerated]
		set
		{
			_1 = value;
		}
	}

	public uint KernelAddr
	{
		[CompilerGenerated]
		get
		{
			return _2;
		}
		[CompilerGenerated]
		set
		{
			_2 = value;
		}
	}

	public uint RamdiskSize
	{
		[CompilerGenerated]
		get
		{
			return _3;
		}
		[CompilerGenerated]
		set
		{
			_3 = value;
		}
	}

	public uint RamdiskAddr
	{
		[CompilerGenerated]
		get
		{
			return _4;
		}
		[CompilerGenerated]
		set
		{
			_4 = value;
		}
	}

	public uint SecondSize
	{
		[CompilerGenerated]
		get
		{
			return _5;
		}
		[CompilerGenerated]
		set
		{
			_5 = value;
		}
	}

	public uint SecondAddr
	{
		[CompilerGenerated]
		get
		{
			return _6;
		}
		[CompilerGenerated]
		set
		{
			_6 = value;
		}
	}

	public uint TagsAddr
	{
		[CompilerGenerated]
		get
		{
			return _7;
		}
		[CompilerGenerated]
		set
		{
			_7 = value;
		}
	}

	public uint PageSize
	{
		[CompilerGenerated]
		get
		{
			return _8;
		}
		[CompilerGenerated]
		set
		{
			_8 = value;
		}
	}

	public string Name
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

	public string Cmdline
	{
		[CompilerGenerated]
		get
		{
			return (string)a;
		}
		[CompilerGenerated]
		set
		{
			a = value;
		}
	}

	public byte[] Id
	{
		[CompilerGenerated]
		get
		{
			return (byte[])b;
		}
		[CompilerGenerated]
		set
		{
			b = value;
		}
	}
}
