using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace SLA_Challenge;

public class IniFile
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private readonly object _0;

	public string Path
	{
		[CompilerGenerated]
		get
		{
			return (string)_0;
		}
	}

	public IniFile(string path)
	{
		_0 = path;
	}

	[DllImport("kernel32", CharSet = CharSet.Unicode)]
	private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

	[DllImport("kernel32", CharSet = CharSet.Unicode)]
	private static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder returnValue, int size, string filePath);

	public void Write(string section, string key, string value)
	{
		WritePrivateProfileString(section, key, value, Path);
	}

	public string Read(string section, string key, string defaultValue = "")
	{
		StringBuilder stringBuilder = new StringBuilder(255);
		GetPrivateProfileString(section, key, defaultValue, stringBuilder, stringBuilder.Capacity, Path);
		return stringBuilder.ToString();
	}
}
