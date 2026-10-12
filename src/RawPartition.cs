using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

internal class RawPartition
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private IntPtr _0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object _1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object _2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object _3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object _4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object _5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object _6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object _7;

	public bool Download
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

	public string Name
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

	public string SectorSize
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

	public string File
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

	public string Size
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

	public string Start
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

	public string PhysicalNum
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

	public string NumSector
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

	public RawPartition(string name, string file, string size, string start, string sectorSize, string numsector, string physicalNum, bool download)
	{
		Name = name;
		File = file;
		Size = size;
		Start = start;
		SectorSize = sectorSize;
		NumSector = numsector;
		PhysicalNum = physicalNum;
		Download = download;
	}
}
