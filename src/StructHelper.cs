using System;
using System.Buffers.Binary;
using System.Text;

public class StructHelper
{
	private readonly Memory<byte> _0;

	private IntPtr _1;

	public StructHelper(byte[] data, int pos = 0)
	{
		_0 = data.AsMemory();
		_1 = (IntPtr)pos;
	}

	public void Advance(int count)
	{
		_1 += (nint)count;
	}

	public ulong Qword(bool bigEndian = false)
	{
		ReadOnlySpan<byte> source = _0.Slice((int)(nint)_1, 8).Span;
		ulong result = (bigEndian ? BinaryPrimitives.ReadUInt64BigEndian(source) : BinaryPrimitives.ReadUInt64LittleEndian(source));
		_1 += (nint)8;
		return result;
	}

	public uint Dword(bool bigEndian = false)
	{
		ReadOnlySpan<byte> source = _0.Slice((int)(nint)_1, 4).Span;
		uint result = (bigEndian ? BinaryPrimitives.ReadUInt32BigEndian(source) : BinaryPrimitives.ReadUInt32LittleEndian(source));
		_1 += (nint)4;
		return result;
	}

	public uint[] Dwords(int count = 1, bool bigEndian = false)
	{
		uint[] array = new uint[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = Dword(bigEndian);
		}
		return array;
	}

	public ulong[] Qwords(int count = 1, bool bigEndian = false)
	{
		ulong[] array = new ulong[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = Qword(bigEndian);
		}
		return array;
	}

	public ushort Short(bool bigEndian = false)
	{
		ReadOnlySpan<byte> source = _0.Slice((int)(nint)_1, 2).Span;
		ushort result = (bigEndian ? BinaryPrimitives.ReadUInt16BigEndian(source) : BinaryPrimitives.ReadUInt16LittleEndian(source));
		_1 += (nint)2;
		return result;
	}

	public ushort[] Shorts(int count, bool bigEndian = false)
	{
		ushort[] array = new ushort[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = Short(bigEndian);
		}
		return array;
	}

	public byte[] Bytes(int length = 1)
	{
		byte[] result = _0.Slice((int)(nint)_1, length).ToArray();
		_1 += (nint)length;
		return result;
	}

	public string String(int length = 1)
	{
		Memory<byte> memory = _0.Slice((int)(nint)_1, length);
		string result = Encoding.ASCII.GetString(memory.Span.ToArray());
		_1 += (nint)length;
		return result;
	}

	public byte Byte()
	{
		byte result = _0.Slice((int)(nint)_1, 1).Span[0];
		_1 += (nint)1;
		return result;
	}

	public int GetPos()
	{
		return (int)(nint)_1;
	}

	public void Seek(int pos)
	{
		_1 = (IntPtr)pos;
	}
}
