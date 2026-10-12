using System;
using System.Collections.Generic;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace ChromeosUpdateEngine;

public sealed class DynamicPartitionMetadata : IMessage<DynamicPartitionMetadata>, IMessage, IEquatable<DynamicPartitionMetadata>, IDeepCloneable<DynamicPartitionMetadata>
{
	private static readonly object _0 = new MessageParser<DynamicPartitionMetadata>((Func<DynamicPartitionMetadata>)(() => new DynamicPartitionMetadata()));

	private object _1;

	private IntPtr _2;

	public const int GroupsFieldNumber = 1;

	private static readonly object _4 = FieldCodec.ForMessage<DynamicPartitionGroup>(10u, DynamicPartitionGroup.Parser);

	private readonly object _5 = new RepeatedField<DynamicPartitionGroup>();

	public const int SnapshotEnabledFieldNumber = 2;

	private static readonly IntPtr _7 = (IntPtr)0;

	private IntPtr _8;

	[DebuggerNonUserCode]
	public static MessageParser<DynamicPartitionMetadata> Parser => (MessageParser<DynamicPartitionMetadata>)_0;

	[DebuggerNonUserCode]
	public static MessageDescriptor Descriptor => UpdateMetadataReflection.Descriptor.MessageTypes[7];

	[DebuggerNonUserCode]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	public RepeatedField<DynamicPartitionGroup> Groups => (RepeatedField<DynamicPartitionGroup>)_5;

	[DebuggerNonUserCode]
	public bool SnapshotEnabled
	{
		get
		{
			if (((nint)_2 & 1) != 0)
			{
				return (byte)(nint)_8 != 0;
			}
			return (byte)(nint)_7 != 0;
		}
		set
		{
			_2 |= (nint)1;
			_8 = (IntPtr)(value ? 1 : 0);
		}
	}

	[DebuggerNonUserCode]
	public bool HasSnapshotEnabled => ((nint)_2 & 1) != 0;

	[DebuggerNonUserCode]
	public DynamicPartitionMetadata()
	{
	}

	[DebuggerNonUserCode]
	public DynamicPartitionMetadata(DynamicPartitionMetadata other)
		: this()
	{
		_2 = other._2;
		_5 = ((RepeatedField<DynamicPartitionGroup>)other._5).Clone();
		_8 = other._8;
		_1 = UnknownFieldSet.Clone((UnknownFieldSet)other._1);
	}

	[DebuggerNonUserCode]
	public DynamicPartitionMetadata Clone()
	{
		return new DynamicPartitionMetadata(this);
	}

	[DebuggerNonUserCode]
	public void ClearSnapshotEnabled()
	{
		_2 &= (nint)(-2);
	}

	[DebuggerNonUserCode]
	public override bool Equals(object other)
	{
		return Equals(other as DynamicPartitionMetadata);
	}

	[DebuggerNonUserCode]
	public bool Equals(DynamicPartitionMetadata other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!((RepeatedField<DynamicPartitionGroup>)_5).Equals((RepeatedField<DynamicPartitionGroup>)other._5))
		{
			return false;
		}
		if (SnapshotEnabled != other.SnapshotEnabled)
		{
			return false;
		}
		return object.Equals(_1, other._1);
	}

	[DebuggerNonUserCode]
	public override int GetHashCode()
	{
		int num = 1;
		num ^= _5.GetHashCode();
		if (HasSnapshotEnabled)
		{
			num ^= SnapshotEnabled.GetHashCode();
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
		((RepeatedField<DynamicPartitionGroup>)_5).WriteTo(output, (FieldCodec<DynamicPartitionGroup>)_4);
		if (HasSnapshotEnabled)
		{
			output.WriteRawTag((byte)16);
			output.WriteBool(SnapshotEnabled);
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
		num += ((RepeatedField<DynamicPartitionGroup>)_5).CalculateSize((FieldCodec<DynamicPartitionGroup>)_4);
		if (HasSnapshotEnabled)
		{
			num += 2;
		}
		if (_1 != null)
		{
			num += ((UnknownFieldSet)_1).CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	public void MergeFrom(DynamicPartitionMetadata other)
	{
		if (other != null)
		{
			((RepeatedField<DynamicPartitionGroup>)_5).Add((IEnumerable<DynamicPartitionGroup>)other._5);
			if (other.HasSnapshotEnabled)
			{
				SnapshotEnabled = other.SnapshotEnabled;
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
			case 10u:
				((RepeatedField<DynamicPartitionGroup>)_5).AddEntriesFrom(input, (FieldCodec<DynamicPartitionGroup>)_4);
				break;
			case 16u:
				SnapshotEnabled = input.ReadBool();
				break;
			}
		}
	}
}
