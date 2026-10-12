using System;
using System.Collections.Generic;
using System.Threading;

namespace XiaoMiFlash.code.module;

public class Device
{
	private IntPtr _0;

	private object _1;

	private object _2;

	private float _3;

	private DateTime _4;

	private float _5;

	private object _6;

	private object _7 = new List<string>();

	private object _8 = "";

	private bool? _9;

	private IntPtr a;

	private object b;

	private object c;

	private IntPtr d;

	private object e;

	private IntPtr f;

	private IntPtr _10;

	public int Index
	{
		get
		{
			return (int)(nint)_0;
		}
		set
		{
			_0 = (IntPtr)value;
		}
	}

	public string Name
	{
		get
		{
			return (string)_1;
		}
		set
		{
			_1 = value;
		}
	}

	public string FSN
	{
		get
		{
			return (string)_2;
		}
		set
		{
			_2 = value;
		}
	}

	public float Progress
	{
		get
		{
			return _3;
		}
		set
		{
			_3 = value;
		}
	}

	public DateTime StartTime
	{
		get
		{
			return _4;
		}
		set
		{
			_4 = value;
		}
	}

	public float Elapse
	{
		get
		{
			return _5;
		}
		set
		{
			_5 = value;
		}
	}

	public string Status
	{
		get
		{
			return (string)_6;
		}
		set
		{
			_6 = value;
		}
	}

	public List<string> StatusList
	{
		get
		{
			return (List<string>)_7;
		}
		set
		{
			_7 = value;
		}
	}

	public string Result
	{
		get
		{
			return (string)_8;
		}
		set
		{
			_8 = value;
		}
	}

	public bool? IsDone
	{
		get
		{
			return _9;
		}
		set
		{
			_9 = value;
		}
	}

	public bool IsUpdate
	{
		get
		{
			return (byte)(nint)a != 0;
		}
		set
		{
			a = (IntPtr)(value ? 1 : 0);
		}
	}

	public Thread DThread
	{
		get
		{
			return (Thread)b;
		}
		set
		{
			b = value;
		}
	}

	public Comm DComm
	{
		get
		{
			return (Comm)c;
		}
		set
		{
			c = value;
		}
	}

	public bool CheckCPUID
	{
		get
		{
			return (byte)(nint)d != 0;
		}
		set
		{
			d = (IntPtr)(value ? 1 : 0);
		}
	}

	public string DeviceType
	{
		get
		{
			return (string)e;
		}
		set
		{
			e = value;
		}
	}

	public ushort IdProduct
	{
		get
		{
			return (ushort)(nint)f;
		}
		set
		{
			f = (IntPtr)(int)value;
		}
	}

	public ushort IdVendor
	{
		get
		{
			return (ushort)(nint)_10;
		}
		set
		{
			_10 = (IntPtr)(int)value;
		}
	}
}
