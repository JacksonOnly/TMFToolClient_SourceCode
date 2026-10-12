using System;
using System.IO;
using System.Text;

public class CommandHelper : IDisposable
{
	private object _0;

	private object _1;

	public CommandHelper()
	{
		_0 = new MemoryStream();
		_1 = new BinaryWriter((Stream)_0);
	}

	public void Dispose()
	{
		((BinaryWriter)_1)?.Close();
		((BinaryWriter)_1)?.Dispose();
		((Stream)_0)?.Close();
		((Stream)_0)?.Dispose();
	}

	public byte[] GetCmd()
	{
		return ((MemoryStream)_0).ToArray();
	}

	public void Qword(ulong value)
	{
		((BinaryWriter)_1).Write(value);
	}

	public void Qwords(ulong[] values)
	{
		foreach (ulong value in values)
		{
			((BinaryWriter)_1).Write(value);
		}
	}

	public void Dword(uint value)
	{
		((BinaryWriter)_1).Write(value);
	}

	public void Dwords(uint[] values)
	{
		foreach (uint value in values)
		{
			((BinaryWriter)_1).Write(value);
		}
	}

	public void Byte(byte value)
	{
		((BinaryWriter)_1).Write(value);
	}

	public void Bytes(byte[] values)
	{
		((BinaryWriter)_1).Write(values);
	}

	public void Short(ushort value)
	{
		((BinaryWriter)_1).Write(value);
	}

	public void Shorts(ushort[] values)
	{
		foreach (ushort value in values)
		{
			((BinaryWriter)_1).Write(value);
		}
	}

	public void String(string value)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(value);
		((BinaryWriter)_1).Write(bytes);
	}
}
