using System;
using System.Collections.Generic;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace ChromeosUpdateEngine;

public sealed class DynamicPartitionGroup : IMessage<DynamicPartitionGroup>, IMessage, IEquatable<DynamicPartitionGroup>, IDeepCloneable<DynamicPartitionGroup>
{
	private static readonly object _0 = new MessageParser<DynamicPartitionGroup>((Func<DynamicPartitionGroup>)(() => new DynamicPartitionGroup()));

	private object _1;

	private IntPtr _2;

	public const int NameFieldNumber = 1;

	private static readonly object _4 = "";

	private object _5;

	public const int SizeFieldNumber = 2;

	private static readonly ulong _7 = 0uL;

	private ulong _8;

	public const int PartitionNamesFieldNumber = 3;

	private static readonly object a = FieldCodec.ForString(26u);

	private readonly object b = new RepeatedField<string>();

	[DebuggerNonUserCode]
	public static MessageParser<DynamicPartitionGroup> Parser => (MessageParser<DynamicPartitionGroup>)_0;

	[DebuggerNonUserCode]
	public static MessageDescriptor Descriptor => UpdateMetadataReflection.Descriptor.MessageTypes[6];

	[DebuggerNonUserCode]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	public string Name
	{
		get
		{
			return (string)(_5 ?? _4);
		}
		set
		{
			_5 = ProtoPreconditions.CheckNotNull<string>(value, "value");
		}
	}

	[DebuggerNonUserCode]
	public bool HasName => _5 != null;

	[DebuggerNonUserCode]
	public ulong Size
	{
		get
		{
			if (((nint)_2 & 1) != 0)
			{
				return _8;
			}
			return _7;
		}
		set
		{
			_2 |= (nint)1;
			_8 = value;
		}
	}

	[DebuggerNonUserCode]
	public bool HasSize => ((nint)_2 & 1) != 0;

	[DebuggerNonUserCode]
	public RepeatedField<string> PartitionNames => (RepeatedField<string>)b;

	[DebuggerNonUserCode]
	public DynamicPartitionGroup()
	{
	}

	[DebuggerNonUserCode]
	public DynamicPartitionGroup(DynamicPartitionGroup other)
		: this()
	{
		_2 = other._2;
		_5 = other._5;
		_8 = other._8;
		b = ((RepeatedField<string>)other.b).Clone();
		_1 = UnknownFieldSet.Clone((UnknownFieldSet)other._1);
	}

	[DebuggerNonUserCode]
	public DynamicPartitionGroup Clone()
	{
		return new DynamicPartitionGroup(this);
	}

	[DebuggerNonUserCode]
	public void ClearName()
	{
		_5 = null;
	}

	[DebuggerNonUserCode]
	public void ClearSize()
	{
		_2 &= (nint)(-2);
	}

	[DebuggerNonUserCode]
	public override bool Equals(object other)
	{
		return Equals(other as DynamicPartitionGroup);
	}

	[DebuggerNonUserCode]
	public bool Equals(DynamicPartitionGroup other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Name != other.Name)
		{
			return false;
		}
		if (Size != other.Size)
		{
			return false;
		}
		if (!((RepeatedField<string>)b).Equals((RepeatedField<string>)other.b))
		{
			return false;
		}
		return object.Equals(_1, other._1);
	}

	[DebuggerNonUserCode]
	public override int GetHashCode()
	{
		int num = 1;
		if (HasName)
		{
			num ^= Name.GetHashCode();
		}
		if (HasSize)
		{
			num ^= Size.GetHashCode();
		}
		num ^= b.GetHashCode();
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
		if (HasName)
		{
			output.WriteRawTag((byte)10);
			output.WriteString(Name);
		}
		if (HasSize)
		{
			output.WriteRawTag((byte)16);
			output.WriteUInt64(Size);
		}
		((RepeatedField<string>)b).WriteTo(output, (FieldCodec<string>)a);
		if (_1 != null)
		{
			((UnknownFieldSet)_1).WriteTo(output);
		}
	}

	[DebuggerNonUserCode]
	public int CalculateSize()
	{
		int num = 0;
		if (HasName)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		if (HasSize)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(Size);
		}
		num += ((RepeatedField<string>)b).CalculateSize((FieldCodec<string>)a);
		if (_1 != null)
		{
			num += ((UnknownFieldSet)_1).CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	public void MergeFrom(DynamicPartitionGroup other)
	{
		if (other != null)
		{
			if (other.HasName)
			{
				Name = other.Name;
			}
			if (other.HasSize)
			{
				Size = other.Size;
			}
			((RepeatedField<string>)b).Add((IEnumerable<string>)other.b);
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
			case 10u:
				Name = input.ReadString();
				break;
			case 16u:
				Size = input.ReadUInt64();
				break;
			case 26u:
				((RepeatedField<string>)b).AddEntriesFrom(input, (FieldCodec<string>)a);
				break;
			}
		}
	}
}
