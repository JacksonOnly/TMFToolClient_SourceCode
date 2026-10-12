using System;
using System.Collections.Generic;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace ChromeosUpdateEngine;

public sealed class DeltaArchiveManifest : IMessage<DeltaArchiveManifest>, IMessage, IEquatable<DeltaArchiveManifest>, IDeepCloneable<DeltaArchiveManifest>
{
	private static readonly object _0 = new MessageParser<DeltaArchiveManifest>((Func<DeltaArchiveManifest>)(() => new DeltaArchiveManifest()));

	private object _1;

	private IntPtr _2;

	public const int InstallOperationsFieldNumber = 1;

	private static readonly object _4 = FieldCodec.ForMessage<InstallOperation>(10u, InstallOperation.Parser);

	private readonly object _5 = new RepeatedField<InstallOperation>();

	public const int KernelInstallOperationsFieldNumber = 2;

	private static readonly object _7 = FieldCodec.ForMessage<InstallOperation>(18u, InstallOperation.Parser);

	private readonly object _8 = new RepeatedField<InstallOperation>();

	public const int BlockSizeFieldNumber = 3;

	private static readonly uint a = 4096u;

	private uint b;

	public const int SignaturesOffsetFieldNumber = 4;

	private static readonly ulong d = 0uL;

	private ulong e;

	public const int SignaturesSizeFieldNumber = 5;

	private static readonly ulong _10 = 0uL;

	private ulong _11;

	public const int OldKernelInfoFieldNumber = 6;

	private object _13;

	public const int NewKernelInfoFieldNumber = 7;

	private object _15;

	public const int OldRootfsInfoFieldNumber = 8;

	private object _17;

	public const int NewRootfsInfoFieldNumber = 9;

	private object _19;

	public const int OldImageInfoFieldNumber = 10;

	private object _1b;

	public const int NewImageInfoFieldNumber = 11;

	private object _1d;

	public const int MinorVersionFieldNumber = 12;

	private static readonly uint _1f = 0u;

	private uint _20;

	public const int PartitionsFieldNumber = 13;

	private static readonly object _22 = FieldCodec.ForMessage<PartitionUpdate>(106u, PartitionUpdate.Parser);

	private readonly object _23 = new RepeatedField<PartitionUpdate>();

	public const int MaxTimestampFieldNumber = 14;

	private static readonly long _25 = 0L;

	private long _26;

	public const int DynamicPartitionMetadataFieldNumber = 15;

	private object _28;

	[DebuggerNonUserCode]
	public static MessageParser<DeltaArchiveManifest> Parser => (MessageParser<DeltaArchiveManifest>)_0;

	[DebuggerNonUserCode]
	public static MessageDescriptor Descriptor => UpdateMetadataReflection.Descriptor.MessageTypes[8];

	[DebuggerNonUserCode]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	public RepeatedField<InstallOperation> InstallOperations => (RepeatedField<InstallOperation>)_5;

	[DebuggerNonUserCode]
	public RepeatedField<InstallOperation> KernelInstallOperations => (RepeatedField<InstallOperation>)_8;

	[DebuggerNonUserCode]
	public uint BlockSize
	{
		get
		{
			if (((nint)_2 & 1) != 0)
			{
				return b;
			}
			return a;
		}
		set
		{
			_2 |= (nint)1;
			b = value;
		}
	}

	[DebuggerNonUserCode]
	public bool HasBlockSize => ((nint)_2 & 1) != 0;

	[DebuggerNonUserCode]
	public ulong SignaturesOffset
	{
		get
		{
			if (((nint)_2 & 2) != 0)
			{
				return e;
			}
			return d;
		}
		set
		{
			_2 |= (nint)2;
			e = value;
		}
	}

	[DebuggerNonUserCode]
	public bool HasSignaturesOffset => ((nint)_2 & 2) != 0;

	[DebuggerNonUserCode]
	public ulong SignaturesSize
	{
		get
		{
			if (((nint)_2 & 4) != 0)
			{
				return _11;
			}
			return _10;
		}
		set
		{
			_2 |= (nint)4;
			_11 = value;
		}
	}

	[DebuggerNonUserCode]
	public bool HasSignaturesSize => ((nint)_2 & 4) != 0;

	[DebuggerNonUserCode]
	public PartitionInfo OldKernelInfo
	{
		get
		{
			return (PartitionInfo)_13;
		}
		set
		{
			_13 = value;
		}
	}

	[DebuggerNonUserCode]
	public PartitionInfo NewKernelInfo
	{
		get
		{
			return (PartitionInfo)_15;
		}
		set
		{
			_15 = value;
		}
	}

	[DebuggerNonUserCode]
	public PartitionInfo OldRootfsInfo
	{
		get
		{
			return (PartitionInfo)_17;
		}
		set
		{
			_17 = value;
		}
	}

	[DebuggerNonUserCode]
	public PartitionInfo NewRootfsInfo
	{
		get
		{
			return (PartitionInfo)_19;
		}
		set
		{
			_19 = value;
		}
	}

	[DebuggerNonUserCode]
	public ImageInfo OldImageInfo
	{
		get
		{
			return (ImageInfo)_1b;
		}
		set
		{
			_1b = value;
		}
	}

	[DebuggerNonUserCode]
	public ImageInfo NewImageInfo
	{
		get
		{
			return (ImageInfo)_1d;
		}
		set
		{
			_1d = value;
		}
	}

	[DebuggerNonUserCode]
	public uint MinorVersion
	{
		get
		{
			if (((nint)_2 & 8) != 0)
			{
				return _20;
			}
			return _1f;
		}
		set
		{
			_2 |= (nint)8;
			_20 = value;
		}
	}

	[DebuggerNonUserCode]
	public bool HasMinorVersion => ((nint)_2 & 8) != 0;

	[DebuggerNonUserCode]
	public RepeatedField<PartitionUpdate> Partitions => (RepeatedField<PartitionUpdate>)_23;

	[DebuggerNonUserCode]
	public long MaxTimestamp
	{
		get
		{
			if (((nint)_2 & 0x10) != 0)
			{
				return _26;
			}
			return _25;
		}
		set
		{
			_2 |= (nint)16;
			_26 = value;
		}
	}

	[DebuggerNonUserCode]
	public bool HasMaxTimestamp => ((nint)_2 & 0x10) != 0;

	[DebuggerNonUserCode]
	public DynamicPartitionMetadata DynamicPartitionMetadata
	{
		get
		{
			return (DynamicPartitionMetadata)_28;
		}
		set
		{
			_28 = value;
		}
	}

	[DebuggerNonUserCode]
	public DeltaArchiveManifest()
	{
	}

	[DebuggerNonUserCode]
	public DeltaArchiveManifest(DeltaArchiveManifest other)
		: this()
	{
		_2 = other._2;
		_5 = ((RepeatedField<InstallOperation>)other._5).Clone();
		_8 = ((RepeatedField<InstallOperation>)other._8).Clone();
		b = other.b;
		e = other.e;
		_11 = other._11;
		_13 = ((other._13 != null) ? ((PartitionInfo)other._13).Clone() : null);
		_15 = ((other._15 != null) ? ((PartitionInfo)other._15).Clone() : null);
		_17 = ((other._17 != null) ? ((PartitionInfo)other._17).Clone() : null);
		_19 = ((other._19 != null) ? ((PartitionInfo)other._19).Clone() : null);
		_1b = ((other._1b != null) ? ((ImageInfo)other._1b).Clone() : null);
		_1d = ((other._1d != null) ? ((ImageInfo)other._1d).Clone() : null);
		_20 = other._20;
		_23 = ((RepeatedField<PartitionUpdate>)other._23).Clone();
		_26 = other._26;
		_28 = ((other._28 != null) ? ((DynamicPartitionMetadata)other._28).Clone() : null);
		_1 = UnknownFieldSet.Clone((UnknownFieldSet)other._1);
	}

	[DebuggerNonUserCode]
	public DeltaArchiveManifest Clone()
	{
		return new DeltaArchiveManifest(this);
	}

	[DebuggerNonUserCode]
	public void ClearBlockSize()
	{
		_2 &= (nint)(-2);
	}

	[DebuggerNonUserCode]
	public void ClearSignaturesOffset()
	{
		_2 &= (nint)(-3);
	}

	[DebuggerNonUserCode]
	public void ClearSignaturesSize()
	{
		_2 &= (nint)(-5);
	}

	[DebuggerNonUserCode]
	public void ClearMinorVersion()
	{
		_2 &= (nint)(-9);
	}

	[DebuggerNonUserCode]
	public void ClearMaxTimestamp()
	{
		_2 &= (nint)(-17);
	}

	[DebuggerNonUserCode]
	public override bool Equals(object other)
	{
		return Equals(other as DeltaArchiveManifest);
	}

	[DebuggerNonUserCode]
	public bool Equals(DeltaArchiveManifest other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!((RepeatedField<InstallOperation>)_5).Equals((RepeatedField<InstallOperation>)other._5))
		{
			return false;
		}
		if (!((RepeatedField<InstallOperation>)_8).Equals((RepeatedField<InstallOperation>)other._8))
		{
			return false;
		}
		if (BlockSize != other.BlockSize)
		{
			return false;
		}
		if (SignaturesOffset != other.SignaturesOffset)
		{
			return false;
		}
		if (SignaturesSize != other.SignaturesSize)
		{
			return false;
		}
		if (!object.Equals(OldKernelInfo, other.OldKernelInfo))
		{
			return false;
		}
		if (!object.Equals(NewKernelInfo, other.NewKernelInfo))
		{
			return false;
		}
		if (!object.Equals(OldRootfsInfo, other.OldRootfsInfo))
		{
			return false;
		}
		if (!object.Equals(NewRootfsInfo, other.NewRootfsInfo))
		{
			return false;
		}
		if (!object.Equals(OldImageInfo, other.OldImageInfo))
		{
			return false;
		}
		if (!object.Equals(NewImageInfo, other.NewImageInfo))
		{
			return false;
		}
		if (MinorVersion != other.MinorVersion)
		{
			return false;
		}
		if (!((RepeatedField<PartitionUpdate>)_23).Equals((RepeatedField<PartitionUpdate>)other._23))
		{
			return false;
		}
		if (MaxTimestamp != other.MaxTimestamp)
		{
			return false;
		}
		if (!object.Equals(DynamicPartitionMetadata, other.DynamicPartitionMetadata))
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
		num ^= _8.GetHashCode();
		if (HasBlockSize)
		{
			num ^= BlockSize.GetHashCode();
		}
		if (HasSignaturesOffset)
		{
			num ^= SignaturesOffset.GetHashCode();
		}
		if (HasSignaturesSize)
		{
			num ^= SignaturesSize.GetHashCode();
		}
		if (_13 != null)
		{
			num ^= OldKernelInfo.GetHashCode();
		}
		if (_15 != null)
		{
			num ^= NewKernelInfo.GetHashCode();
		}
		if (_17 != null)
		{
			num ^= OldRootfsInfo.GetHashCode();
		}
		if (_19 != null)
		{
			num ^= NewRootfsInfo.GetHashCode();
		}
		if (_1b != null)
		{
			num ^= OldImageInfo.GetHashCode();
		}
		if (_1d != null)
		{
			num ^= NewImageInfo.GetHashCode();
		}
		if (HasMinorVersion)
		{
			num ^= MinorVersion.GetHashCode();
		}
		num ^= _23.GetHashCode();
		if (HasMaxTimestamp)
		{
			num ^= MaxTimestamp.GetHashCode();
		}
		if (_28 != null)
		{
			num ^= DynamicPartitionMetadata.GetHashCode();
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
		((RepeatedField<InstallOperation>)_5).WriteTo(output, (FieldCodec<InstallOperation>)_4);
		((RepeatedField<InstallOperation>)_8).WriteTo(output, (FieldCodec<InstallOperation>)_7);
		if (HasBlockSize)
		{
			output.WriteRawTag((byte)24);
			output.WriteUInt32(BlockSize);
		}
		if (HasSignaturesOffset)
		{
			output.WriteRawTag((byte)32);
			output.WriteUInt64(SignaturesOffset);
		}
		if (HasSignaturesSize)
		{
			output.WriteRawTag((byte)40);
			output.WriteUInt64(SignaturesSize);
		}
		if (_13 != null)
		{
			output.WriteRawTag((byte)50);
			output.WriteMessage((IMessage)(object)OldKernelInfo);
		}
		if (_15 != null)
		{
			output.WriteRawTag((byte)58);
			output.WriteMessage((IMessage)(object)NewKernelInfo);
		}
		if (_17 != null)
		{
			output.WriteRawTag((byte)66);
			output.WriteMessage((IMessage)(object)OldRootfsInfo);
		}
		if (_19 != null)
		{
			output.WriteRawTag((byte)74);
			output.WriteMessage((IMessage)(object)NewRootfsInfo);
		}
		if (_1b != null)
		{
			output.WriteRawTag((byte)82);
			output.WriteMessage((IMessage)(object)OldImageInfo);
		}
		if (_1d != null)
		{
			output.WriteRawTag((byte)90);
			output.WriteMessage((IMessage)(object)NewImageInfo);
		}
		if (HasMinorVersion)
		{
			output.WriteRawTag((byte)96);
			output.WriteUInt32(MinorVersion);
		}
		((RepeatedField<PartitionUpdate>)_23).WriteTo(output, (FieldCodec<PartitionUpdate>)_22);
		if (HasMaxTimestamp)
		{
			output.WriteRawTag((byte)112);
			output.WriteInt64(MaxTimestamp);
		}
		if (_28 != null)
		{
			output.WriteRawTag((byte)122);
			output.WriteMessage((IMessage)(object)DynamicPartitionMetadata);
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
		num += ((RepeatedField<InstallOperation>)_5).CalculateSize((FieldCodec<InstallOperation>)_4);
		num += ((RepeatedField<InstallOperation>)_8).CalculateSize((FieldCodec<InstallOperation>)_7);
		if (HasBlockSize)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(BlockSize);
		}
		if (HasSignaturesOffset)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(SignaturesOffset);
		}
		if (HasSignaturesSize)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(SignaturesSize);
		}
		if (_13 != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize((IMessage)(object)OldKernelInfo);
		}
		if (_15 != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize((IMessage)(object)NewKernelInfo);
		}
		if (_17 != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize((IMessage)(object)OldRootfsInfo);
		}
		if (_19 != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize((IMessage)(object)NewRootfsInfo);
		}
		if (_1b != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize((IMessage)(object)OldImageInfo);
		}
		if (_1d != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize((IMessage)(object)NewImageInfo);
		}
		if (HasMinorVersion)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(MinorVersion);
		}
		num += ((RepeatedField<PartitionUpdate>)_23).CalculateSize((FieldCodec<PartitionUpdate>)_22);
		if (HasMaxTimestamp)
		{
			num += 1 + CodedOutputStream.ComputeInt64Size(MaxTimestamp);
		}
		if (_28 != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize((IMessage)(object)DynamicPartitionMetadata);
		}
		if (_1 != null)
		{
			num += ((UnknownFieldSet)_1).CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	public void MergeFrom(DeltaArchiveManifest other)
	{
		if (other == null)
		{
			return;
		}
		((RepeatedField<InstallOperation>)_5).Add((IEnumerable<InstallOperation>)other._5);
		((RepeatedField<InstallOperation>)_8).Add((IEnumerable<InstallOperation>)other._8);
		if (other.HasBlockSize)
		{
			BlockSize = other.BlockSize;
		}
		if (other.HasSignaturesOffset)
		{
			SignaturesOffset = other.SignaturesOffset;
		}
		if (other.HasSignaturesSize)
		{
			SignaturesSize = other.SignaturesSize;
		}
		if (other._13 != null)
		{
			if (_13 == null)
			{
				OldKernelInfo = new PartitionInfo();
			}
			OldKernelInfo.MergeFrom(other.OldKernelInfo);
		}
		if (other._15 != null)
		{
			if (_15 == null)
			{
				NewKernelInfo = new PartitionInfo();
			}
			NewKernelInfo.MergeFrom(other.NewKernelInfo);
		}
		if (other._17 != null)
		{
			if (_17 == null)
			{
				OldRootfsInfo = new PartitionInfo();
			}
			OldRootfsInfo.MergeFrom(other.OldRootfsInfo);
		}
		if (other._19 != null)
		{
			if (_19 == null)
			{
				NewRootfsInfo = new PartitionInfo();
			}
			NewRootfsInfo.MergeFrom(other.NewRootfsInfo);
		}
		if (other._1b != null)
		{
			if (_1b == null)
			{
				OldImageInfo = new ImageInfo();
			}
			OldImageInfo.MergeFrom(other.OldImageInfo);
		}
		if (other._1d != null)
		{
			if (_1d == null)
			{
				NewImageInfo = new ImageInfo();
			}
			NewImageInfo.MergeFrom(other.NewImageInfo);
		}
		if (other.HasMinorVersion)
		{
			MinorVersion = other.MinorVersion;
		}
		((RepeatedField<PartitionUpdate>)_23).Add((IEnumerable<PartitionUpdate>)other._23);
		if (other.HasMaxTimestamp)
		{
			MaxTimestamp = other.MaxTimestamp;
		}
		if (other._28 != null)
		{
			if (_28 == null)
			{
				DynamicPartitionMetadata = new DynamicPartitionMetadata();
			}
			DynamicPartitionMetadata.MergeFrom(other.DynamicPartitionMetadata);
		}
		_1 = UnknownFieldSet.MergeFrom((UnknownFieldSet)_1, (UnknownFieldSet)other._1);
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
				((RepeatedField<InstallOperation>)_5).AddEntriesFrom(input, (FieldCodec<InstallOperation>)_4);
				break;
			case 18u:
				((RepeatedField<InstallOperation>)_8).AddEntriesFrom(input, (FieldCodec<InstallOperation>)_7);
				break;
			case 24u:
				BlockSize = input.ReadUInt32();
				break;
			case 32u:
				SignaturesOffset = input.ReadUInt64();
				break;
			case 40u:
				SignaturesSize = input.ReadUInt64();
				break;
			case 50u:
				if (_13 == null)
				{
					OldKernelInfo = new PartitionInfo();
				}
				input.ReadMessage((IMessage)(object)OldKernelInfo);
				break;
			case 58u:
				if (_15 == null)
				{
					NewKernelInfo = new PartitionInfo();
				}
				input.ReadMessage((IMessage)(object)NewKernelInfo);
				break;
			case 66u:
				if (_17 == null)
				{
					OldRootfsInfo = new PartitionInfo();
				}
				input.ReadMessage((IMessage)(object)OldRootfsInfo);
				break;
			case 74u:
				if (_19 == null)
				{
					NewRootfsInfo = new PartitionInfo();
				}
				input.ReadMessage((IMessage)(object)NewRootfsInfo);
				break;
			case 82u:
				if (_1b == null)
				{
					OldImageInfo = new ImageInfo();
				}
				input.ReadMessage((IMessage)(object)OldImageInfo);
				break;
			case 90u:
				if (_1d == null)
				{
					NewImageInfo = new ImageInfo();
				}
				input.ReadMessage((IMessage)(object)NewImageInfo);
				break;
			case 96u:
				MinorVersion = input.ReadUInt32();
				break;
			case 106u:
				((RepeatedField<PartitionUpdate>)_23).AddEntriesFrom(input, (FieldCodec<PartitionUpdate>)_22);
				break;
			case 112u:
				MaxTimestamp = input.ReadInt64();
				break;
			case 122u:
				if (_28 == null)
				{
					DynamicPartitionMetadata = new DynamicPartitionMetadata();
				}
				input.ReadMessage((IMessage)(object)DynamicPartitionMetadata);
				break;
			}
		}
	}
}
