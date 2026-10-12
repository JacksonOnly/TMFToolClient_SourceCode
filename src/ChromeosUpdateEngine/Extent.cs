using System;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace ChromeosUpdateEngine;

public sealed class Extent : IMessage<Extent>, IMessage, IEquatable<Extent>, IDeepCloneable<Extent>
{
	private static readonly object _0 = new MessageParser<Extent>((Func<Extent>)(() => new Extent()));

	private object _1;

	private IntPtr _2;

	public const int StartBlockFieldNumber = 1;

	private static readonly ulong _4 = 0uL;

	private ulong _5;

	public const int NumBlocksFieldNumber = 2;

	private static readonly ulong _7 = 0uL;

	private ulong _8;

	[DebuggerNonUserCode]
	public static MessageParser<Extent> Parser => (MessageParser<Extent>)_0;

	[DebuggerNonUserCode]
	public static MessageDescriptor Descriptor => UpdateMetadataReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	public ulong StartBlock
	{
		get
		{
			if (((nint)_2 & 1) != 0)
			{
				return _5;
			}
			return _4;
		}
		set
		{
			_2 |= (nint)1;
			_5 = value;
		}
	}

	[DebuggerNonUserCode]
	public bool HasStartBlock => ((nint)_2 & 1) != 0;

	[DebuggerNonUserCode]
	public ulong NumBlocks
	{
		get
		{
			if (((nint)_2 & 2) != 0)
			{
				return _8;
			}
			return _7;
		}
		set
		{
			_2 |= (nint)2;
			_8 = value;
		}
	}

	[DebuggerNonUserCode]
	public bool HasNumBlocks => ((nint)_2 & 2) != 0;

	[DebuggerNonUserCode]
	public Extent()
	{
	}

	[DebuggerNonUserCode]
	public Extent(Extent other)
		: this()
	{
		_2 = other._2;
		_5 = other._5;
		_8 = other._8;
		_1 = UnknownFieldSet.Clone((UnknownFieldSet)other._1);
	}

	[DebuggerNonUserCode]
	public Extent Clone()
	{
		return new Extent(this);
	}

	[DebuggerNonUserCode]
	public void ClearStartBlock()
	{
		_2 &= (nint)(-2);
	}

	[DebuggerNonUserCode]
	public void ClearNumBlocks()
	{
		_2 &= (nint)(-3);
	}

	[DebuggerNonUserCode]
	public override bool Equals(object other)
	{
		return Equals(other as Extent);
	}

	[DebuggerNonUserCode]
	public bool Equals(Extent other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (StartBlock != other.StartBlock)
		{
			return false;
		}
		if (NumBlocks != other.NumBlocks)
		{
			return false;
		}
		return object.Equals(_1, other._1);
	}

	[DebuggerNonUserCode]
	public override int GetHashCode()
	{
		int num = 1;
		if (HasStartBlock)
		{
			num ^= StartBlock.GetHashCode();
		}
		if (HasNumBlocks)
		{
			num ^= NumBlocks.GetHashCode();
		}
		if (_1 != null)
		{
			num ^= _1.GetHashCode();
		}
		return num;
	}

	[DebuggerNonUserCode]
	public override string ToString()
	{
		return JsonFormatter.ToDiagnosticString((IMessage)(object)this);
	}

	[DebuggerNonUserCode]
	public void WriteTo(CodedOutputStream output)
	{
		if (HasStartBlock)
		{
			output.WriteRawTag((byte)8);
			output.WriteUInt64(StartBlock);
		}
		if (HasNumBlocks)
		{
			output.WriteRawTag((byte)16);
			output.WriteUInt64(NumBlocks);
		}
		if (_1 != null)
		{
			((UnknownFieldSet)_1).WriteTo(output);
		}
	}

	[DebuggerNonUserCode]
	public int CalculateSize()
	{
		int num = 0;
		if (HasStartBlock)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(StartBlock);
		}
		if (HasNumBlocks)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(NumBlocks);
		}
		if (_1 != null)
		{
			num += ((UnknownFieldSet)_1).CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	public void MergeFrom(Extent other)
	{
		if (other != null)
		{
			if (other.HasStartBlock)
			{
				StartBlock = other.StartBlock;
			}
			if (other.HasNumBlocks)
			{
				NumBlocks = other.NumBlocks;
			}
			_1 = UnknownFieldSet.MergeFrom((UnknownFieldSet)_1, (UnknownFieldSet)other._1);
		}
	}

	[DebuggerNonUserCode]
	public void MergeFrom(CodedInputStream input)
	{
		uint num;
		while ((num = input.ReadTag()) != 0)
		{
			switch (num)
			{
			default:
				_1 = UnknownFieldSet.MergeFieldFrom((UnknownFieldSet)_1, input);
				break;
			case 8u:
				StartBlock = input.ReadUInt64();
				break;
			case 16u:
				NumBlocks = input.ReadUInt64();
				break;
			}
		}
	}
}
