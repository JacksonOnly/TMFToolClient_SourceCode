using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Costura;

[CompilerGenerated]
internal static class AssemblyLoader
{
	private static object m_0;

	private static object m_1;

	private static object m_2;

	private static object m_3;

	private static IntPtr m_4;

	private static object _0(object culture)
	{
		if (culture == null)
		{
			return string.Empty;
		}
		return ((CultureInfo)culture).Name;
	}

	private static object _1(object name)
	{
		AppDomain currentDomain = AppDomain.CurrentDomain;
		Assembly[] assemblies = currentDomain.GetAssemblies();
		Assembly[] array = assemblies;
		foreach (Assembly assembly in array)
		{
			AssemblyName name2 = assembly.GetName();
			if (string.Equals(name2.Name, ((AssemblyName)name).Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals((string)_0(name2.CultureInfo), (string)_0(((AssemblyName)name).CultureInfo), StringComparison.InvariantCultureIgnoreCase))
			{
				return assembly;
			}
		}
		return null;
	}

	private static object _2(object requestedAssemblyName)
	{
		string text = ((AssemblyName)requestedAssemblyName).Name.ToLowerInvariant();
		if (((AssemblyName)requestedAssemblyName).CultureInfo != null && !string.IsNullOrEmpty(((AssemblyName)requestedAssemblyName).CultureInfo.Name))
		{
			text = ((string)_0(((AssemblyName)requestedAssemblyName).CultureInfo) + "." + text).ToLowerInvariant();
		}
		return text;
	}

	private static void _3(object source, object destination)
	{
		byte[] array = new byte[81920];
		int count;
		while ((count = ((Stream)source).Read(array, 0, array.Length)) != 0)
		{
			((Stream)destination).Write(array, 0, count);
		}
	}

	private static object _4(object fullName)
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		if (((string)fullName).EndsWith(".compressed"))
		{
			using (Stream stream = executingAssembly.GetManifestResourceStream((string)fullName))
			{
				using DeflateStream source = new DeflateStream(stream, CompressionMode.Decompress);
				MemoryStream memoryStream = new MemoryStream();
				_3(source, memoryStream);
				memoryStream.Position = 0L;
				return memoryStream;
			}
		}
		return executingAssembly.GetManifestResourceStream((string)fullName);
	}

	private static object _5(object resourceNames, object name)
	{
		if (((Dictionary<string, string>)resourceNames).TryGetValue((string)name, out string value))
		{
			return _4(value);
		}
		return null;
	}

	private static object _6(object stream)
	{
		byte[] array = new byte[((Stream)stream).Length];
		((Stream)stream).Read(array, 0, array.Length);
		return array;
	}

	private static object _7(object assemblyNames, object symbolNames, object requestedAssemblyName)
	{
		string name = (string)_2(requestedAssemblyName);
		byte[] rawAssembly;
		using (Stream stream = (Stream)_5(assemblyNames, name))
		{
			if (stream == null)
			{
				return null;
			}
			rawAssembly = (byte[])_6(stream);
		}
		using (Stream stream2 = (Stream)_5(symbolNames, name))
		{
			if (stream2 != null)
			{
				byte[] rawSymbolStore = (byte[])_6(stream2);
				return Assembly.Load(rawAssembly, rawSymbolStore);
			}
		}
		return Assembly.Load(rawAssembly);
	}

	public static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
	{
		string name = e.Name;
		AssemblyName assemblyName = new AssemblyName(name);
		lock (AssemblyLoader.m_0)
		{
			if (((Dictionary<string, bool>)AssemblyLoader.m_1).ContainsKey(name))
			{
				return null;
			}
		}
		Assembly assembly = (Assembly)_1(assemblyName);
		if ((object)assembly != null)
		{
			return assembly;
		}
		assembly = (Assembly)_7(AssemblyLoader.m_2, AssemblyLoader.m_3, assemblyName);
		if ((object)assembly == null)
		{
			lock (AssemblyLoader.m_0)
			{
				((Dictionary<string, bool>)AssemblyLoader.m_1)[name] = true;
			}
			if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != 0)
			{
				assembly = Assembly.Load(assemblyName);
			}
		}
		return assembly;
	}

	static AssemblyLoader()
	{
		AssemblyLoader.m_0 = new object();
		AssemblyLoader.m_1 = new Dictionary<string, bool>();
		AssemblyLoader.m_2 = new Dictionary<string, string>();
		AssemblyLoader.m_3 = new Dictionary<string, string>();
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("antdui", "costura.antdui.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("costura", "costura.costura.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_3).Add("costura", "costura.costura.pdb.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("dotnetzip", "costura.dotnetzip.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_3).Add("dotnetzip", "costura.dotnetzip.pdb.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("google.protobuf", "costura.google.protobuf.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_3).Add("google.protobuf", "costura.google.protobuf.pdb.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("libusbdotnet.libusbdotnet", "costura.libusbdotnet.libusbdotnet.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_3).Add("libusbdotnet.libusbdotnet", "costura.libusbdotnet.libusbdotnet.pdb.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("managedxz", "costura.managedxz.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("microsoft.bcl.asyncinterfaces", "costura.microsoft.bcl.asyncinterfaces.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("microsoft.extensions.logging.abstractions", "costura.microsoft.extensions.logging.abstractions.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("newtonsoft.json", "costura.newtonsoft.json.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("ookii.dialogs.winforms", "costura.ookii.dialogs.winforms.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_3).Add("ookii.dialogs.winforms", "costura.ookii.dialogs.winforms.pdb.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("quartz", "costura.quartz.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("restsharp", "costura.restsharp.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("sunnyui.common", "costura.sunnyui.common.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("sunnyui", "costura.sunnyui.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("system.buffers", "costura.system.buffers.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("system.diagnostics.diagnosticsource", "costura.system.diagnostics.diagnosticsource.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("system.memory", "costura.system.memory.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("system.numerics.vectors", "costura.system.numerics.vectors.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("system.resources.extensions", "costura.system.resources.extensions.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("system.runtime.compilerservices.unsafe", "costura.system.runtime.compilerservices.unsafe.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("system.text.encoding.codepages", "costura.system.text.encoding.codepages.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("system.text.encodings.web", "costura.system.text.encodings.web.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("system.text.json", "costura.system.text.json.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("system.threading.tasks.extensions", "costura.system.threading.tasks.extensions.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("system.valuetuple", "costura.system.valuetuple.dll.compressed");
		((Dictionary<string, string>)AssemblyLoader.m_2).Add("zstdsharp", "costura.zstdsharp.dll.compressed");
	}

	public static void Attach(bool subscribe)
	{
		if (Interlocked.Exchange(ref Unsafe.As<IntPtr, int>(ref AssemblyLoader.m_4), 1) != 1 && subscribe)
		{
			AppDomain currentDomain = AppDomain.CurrentDomain;
			currentDomain.AssemblyResolve += ResolveAssembly;
		}
	}
}
