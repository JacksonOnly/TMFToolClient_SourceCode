using System;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace ChromeosUpdateEngine;

public sealed class PartitionInfo : IMessage<PartitionInfo>, IMessage, IEquatable<PartitionInfo>, IDeepCloneable<PartitionInfo>
{
	private static readonly object _0 = new MessageParser<PartitionInfo>((Func<PartitionInfo>)(() => new PartitionInfo()));

	private object _1;

	private IntPtr _2;

	public const int SizeFieldNumber = 1;

	private static readonly ulong _4 = 0uL;

	private ulong _5;

	public const int HashFieldNumber = 2;

	private static readonly object _7 = ByteString.Empty;

	private object _8;

	[DebuggerNonUserCode]
	public static MessageParser<PartitionInfo> Parser => (MessageParser<PartitionInfo>)_0;

	[DebuggerNonUserCode]
	public static MessageDescriptor Descriptor => UpdateMetadataReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	public ulong Size
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
	public bool HasSize => ((nint)_2 & 1) != 0;

	[DebuggerNonUserCode]
	public ByteString Hash
	{
		get
		{
			return (ByteString)(_8 ?? _7);
		}
		set
		{
			_8 = ProtoPreconditions.CheckNotNull<ByteString>(value, "value");
		}
	}

	[DebuggerNonUserCode]
	public bool HasHash => (ByteString)_8 != (ByteString)null;

	[DebuggerNonUserCode]
	public PartitionInfo()
	{
	}

	[DebuggerNonUserCode]
	public PartitionInfo(PartitionInfo other)
		: this()
	{
		_2 = other._2;
		_5 = other._5;
		_8 = other._8;
		_1 = UnknownFieldSet.Clone((UnknownFieldSet)other._1);
	}

	[DebuggerNonUserCode]
	public PartitionInfo Clone()
	{
		return new PartitionInfo(this);
	}

	[DebuggerNonUserCode]
	public void ClearSize()
	{
		_2 &= (nint)(-2);
	}

	[DebuggerNonUserCode]
	public void ClearHash()
	{
		_8 = null;
	}

	[DebuggerNonUserCode]
	public override bool Equals(object other)
	{
		return Equals(other as PartitionInfo);
	}

	[DebuggerNonUserCode]
	public bool Equals(PartitionInfo other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Size != other.Size)
		{
			return false;
		}
		if (Hash != other.Hash)
		{
			return false;
		}
		return object.Equals(_1, other._1);
	}

	[DebuggerNonUserCode]
	public override int GetHashCode()
	{
		int num = 1;
		if (HasSize)
		{
			num ^= Size.GetHashCode();
		}
		if (HasHash)
		{
			num ^= ((object)Hash).GetHashCode();
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
		if (HasSize)
		{
			output.WriteRawTag((byte)8);
			output.WriteUInt64(Size);
		}
		if (HasHash)
		{
			output.WriteRawTag((byte)18);
			output.WriteBytes(Hash);
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
		if (HasSize)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(Size);
		}
		if (HasHash)
		{
			num += 1 + CodedOutputStream.ComputeBytesSize(Hash);
		}
		if (_1 != null)
		{
			num += ((UnknownFieldSet)_1).CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	public void MergeFrom(PartitionInfo other)
	{
		if (other != null)
		{
			if (other.HasSize)
			{
				Size = other.Size;
			}
			if (other.HasHash)
			{
				Hash = other.Hash;
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
				Size = input.ReadUInt64();
				break;
			case 18u:
				Hash = input.ReadBytes();
				break;
			}
		}
	}
}
