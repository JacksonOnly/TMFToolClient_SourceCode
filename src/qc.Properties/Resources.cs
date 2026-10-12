using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace qc.Properties;

[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "18.0.0.0")]
[DebuggerNonUserCode]
public class Resources
{
	private static object _0;

	private static object _1;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static ResourceManager ResourceManager
	{
		get
		{
			if (_0 == null)
			{
				ResourceManager resourceManager = new ResourceManager("qc.Properties.Resources", typeof(Resources).Assembly);
				_0 = resourceManager;
			}
			return (ResourceManager)_0;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static CultureInfo Culture
	{
		get
		{
			return (CultureInfo)_1;
		}
		set
		{
			_1 = value;
		}
	}

	public static byte[] commonmisc
	{
		get
		{
			object obj = ResourceManager.GetObject("commonmisc", (CultureInfo)_1);
			return (byte[])obj;
		}
	}

	public static byte[] fd
	{
		get
		{
			object obj = ResourceManager.GetObject("fd", (CultureInfo)_1);
			return (byte[])obj;
		}
	}

	public static byte[] misc
	{
		get
		{
			object obj = ResourceManager.GetObject("misc", (CultureInfo)_1);
			return (byte[])obj;
		}
	}

	public static byte[] misc_wipedata_meizu
	{
		get
		{
			object obj = ResourceManager.GetObject("misc_wipedata_meizu", (CultureInfo)_1);
			return (byte[])obj;
		}
	}

	public static byte[] qcedlcmdhelper
	{
		get
		{
			object obj = ResourceManager.GetObject("qcedlcmdhelper", (CultureInfo)_1);
			return (byte[])obj;
		}
	}

	public static byte[] rec
	{
		get
		{
			object obj = ResourceManager.GetObject("rec", (CultureInfo)_1);
			return (byte[])obj;
		}
	}

	public static byte[] simg2img
	{
		get
		{
			object obj = ResourceManager.GetObject("simg2img", (CultureInfo)_1);
			return (byte[])obj;
		}
	}

	public static byte[] tools
	{
		get
		{
			object obj = ResourceManager.GetObject("tools", (CultureInfo)_1);
			return (byte[])obj;
		}
	}

	public static Icon xm2
	{
		get
		{
			object obj = ResourceManager.GetObject("xm2", (CultureInfo)_1);
			return (Icon)obj;
		}
	}

	public static byte[] zero
	{
		get
		{
			object obj = ResourceManager.GetObject("zero", (CultureInfo)_1);
			return (byte[])obj;
		}
	}

	public static byte[] zk
	{
		get
		{
			object obj = ResourceManager.GetObject("zk", (CultureInfo)_1);
			return (byte[])obj;
		}
	}

	internal Resources()
	{
	}
}
