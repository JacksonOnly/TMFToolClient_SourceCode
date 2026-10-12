using System;
using System.Collections.Generic;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace ChromeosUpdateEngine;

public sealed class InstallOperation : IMessage<InstallOperation>, IMessage, IEquatable<InstallOperation>, IDeepCloneable<InstallOperation>
{
	[DebuggerNonUserCode]
	public static class Types
	{
		public enum Type
		{
			[OriginalName("REPLACE")]
			Replace = 0,
			[OriginalName("REPLACE_BZ")]
			ReplaceBz = 1,
			[OriginalName("MOVE")]
			Move = 2,
			[OriginalName("BSDIFF")]
			Bsdiff = 3,
			[OriginalName("SOURCE_COPY")]
			SourceCopy = 4,
			[OriginalName("SOURCE_BSDIFF")]
			SourceBsdiff = 5,
			[OriginalName("REPLACE_XZ")]
			ReplaceXz = 8,
			[OriginalName("ZERO")]
			Zero = 6,
			[OriginalName("DISCARD")]
			Discard = 7,
			[OriginalName("BROTLI_BSDIFF")]
			BrotliBsdiff = 10,
			[OriginalName("PUFFDIFF")]
			Puffdiff = 9
		}
	}

	private static readonly object _0 = new MessageParser<InstallOperation>((Func<InstallOperation>)(() => new InstallOperation()));

	private object _1;

	private IntPtr _2;

	public const int TypeFieldNumber = 1;

	private static readonly Types.Type _4 = Types.Type.Replace;

	private Types.Type _5;

	public const int DataOffsetFieldNumber = 2;

	private static readonly ulong _7 = 0uL;

	private ulong _8;

	public const int DataLengthFieldNumber = 3;

	private static readonly ulong a = 0uL;

	private ulong b;

	public const int SrcExtentsFieldNumber = 4;

	private static readonly object d = FieldCodec.ForMessage<Extent>(34u, Extent.Parser);

	private readonly object e = new RepeatedField<Extent>();

	public const int SrcLengthFieldNumber = 5;

	private static readonly ulong _10 = 0uL;

	private ulong _11;

	public const int DstExtentsFieldNumber = 6;

	private static readonly object _13 = FieldCodec.ForMessage<Extent>(50u, Extent.Parser);

	private readonly object _14 = new RepeatedField<Extent>();

	public const int DstLengthFieldNumber = 7;

	private static readonly ulong _16 = 0uL;

	private ulong _17;

	public const int DataSha256HashFieldNumber = 8;

	private static readonly object _19 = ByteString.Empty;

	private object _1a;

	public const int SrcSha256HashFieldNumber = 9;

	private static readonly object _1c = ByteString.Empty;

	private object _1d;

	[DebuggerNonUserCode]
	public static MessageParser<InstallOperation> Parser => (MessageParser<InstallOperation>)_0;

	[DebuggerNonUserCode]
	public static MessageDescriptor Descriptor => UpdateMetadataReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	public Types.Type Type
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
	public bool HasType => ((nint)_2 & 1) != 0;

	[DebuggerNonUserCode]
	public ulong DataOffset
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
	public bool HasDataOffset => ((nint)_2 & 2) != 0;

	[DebuggerNonUserCode]
	public ulong DataLength
	{
		get
		{
			if (((nint)_2 & 4) != 0)
			{
				return b;
			}
			return a;
		}
		set
		{
			_2 |= (nint)4;
			b = value;
		}
	}

	[DebuggerNonUserCode]
	public bool HasDataLength => ((nint)_2 & 4) != 0;

	[DebuggerNonUserCode]
	public RepeatedField<Extent> SrcExtents => (RepeatedField<Extent>)e;

	[DebuggerNonUserCode]
	public ulong SrcLength
	{
		get
		{
			if (((nint)_2 & 8) != 0)
			{
				return _11;
			}
			return _10;
		}
		set
		{
			_2 |= (nint)8;
			_11 = value;
		}
	}

	[DebuggerNonUserCode]
	public bool HasSrcLength => ((nint)_2 & 8) != 0;

	[DebuggerNonUserCode]
	public RepeatedField<Extent> DstExtents => (RepeatedField<Extent>)_14;

	[DebuggerNonUserCode]
	public ulong DstLength
	{
		get
		{
			if (((nint)_2 & 0x10) != 0)
			{
				return _17;
			}
			return _16;
		}
		set
		{
			_2 |= (nint)16;
			_17 = value;
		}
	}

	[DebuggerNonUserCode]
	public bool HasDstLength => ((nint)_2 & 0x10) != 0;

	[DebuggerNonUserCode]
	public ByteString DataSha256Hash
	{
		get
		{
			return (ByteString)(_1a ?? _19);
		}
		set
		{
			_1a = ProtoPreconditions.CheckNotNull<ByteString>(value, "value");
		}
	}

	[DebuggerNonUserCode]
	public bool HasDataSha256Hash => (ByteString)_1a != (ByteString)null;

	[DebuggerNonUserCode]
	public ByteString SrcSha256Hash
	{
		get
		{
			return (ByteString)(_1d ?? _1c);
		}
		set
		{
			_1d = ProtoPreconditions.CheckNotNull<ByteString>(value, "value");
		}
	}

	[DebuggerNonUserCode]
	public bool HasSrcSha256Hash => (ByteString)_1d != (ByteString)null;

	[DebuggerNonUserCode]
	public InstallOperation()
	{
	}

	[DebuggerNonUserCode]
	public InstallOperation(InstallOperation other)
		: this()
	{
		_2 = other._2;
		_5 = other._5;
		_8 = other._8;
		b = other.b;
		e = ((RepeatedField<Extent>)other.e).Clone();
		_11 = other._11;
		_14 = ((RepeatedField<Extent>)other._14).Clone();
		_17 = other._17;
		_1a = other._1a;
		_1d = other._1d;
		_1 = UnknownFieldSet.Clone((UnknownFieldSet)other._1);
	}

	[DebuggerNonUserCode]
	public InstallOperation Clone()
	{
		return new InstallOperation(this);
	}

	[DebuggerNonUserCode]
	public void ClearType()
	{
		_2 &= (nint)(-2);
	}

	[DebuggerNonUserCode]
	public void ClearDataOffset()
	{
		_2 &= (nint)(-3);
	}

	[DebuggerNonUserCode]
	public void ClearDataLength()
	{
		_2 &= (nint)(-5);
	}

	[DebuggerNonUserCode]
	public void ClearSrcLength()
	{
		_2 &= (nint)(-9);
	}

	[DebuggerNonUserCode]
	public void ClearDstLength()
	{
		_2 &= (nint)(-17);
	}

	[DebuggerNonUserCode]
	public void ClearDataSha256Hash()
	{
		_1a = null;
	}

	[DebuggerNonUserCode]
	public void ClearSrcSha256Hash()
	{
		_1d = null;
	}

	[DebuggerNonUserCode]
	public override bool Equals(object other)
	{
		return Equals(other as InstallOperation);
	}

	[DebuggerNonUserCode]
	public bool Equals(InstallOperation other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Type != other.Type)
		{
			return false;
		}
		if (DataOffset != other.DataOffset)
		{
			return false;
		}
		if (DataLength != other.DataLength)
		{
			return false;
		}
		if (!((RepeatedField<Extent>)e).Equals((RepeatedField<Extent>)other.e))
		{
			return false;
		}
		if (SrcLength != other.SrcLength)
		{
			return false;
		}
		if (!((RepeatedField<Extent>)_14).Equals((RepeatedField<Extent>)other._14))
		{
			return false;
		}
		if (DstLength != other.DstLength)
		{
			return false;
		}
		if (DataSha256Hash != other.DataSha256Hash)
		{
			return false;
		}
		if (SrcSha256Hash != other.SrcSha256Hash)
		{
			return false;
		}
		return object.Equals(_1, other._1);
	}

	[DebuggerNonUserCode]
	public override int GetHashCode()
	{
		int num = 1;
		if (HasType)
		{
			num ^= Type.GetHashCode();
		}
		if (HasDataOffset)
		{
			num ^= DataOffset.GetHashCode();
		}
		if (HasDataLength)
		{
			num ^= DataLength.GetHashCode();
		}
		num ^= e.GetHashCode();
		if (HasSrcLength)
		{
			num ^= SrcLength.GetHashCode();
		}
		num ^= _14.GetHashCode();
		if (HasDstLength)
		{
			num ^= DstLength.GetHashCode();
		}
		if (HasDataSha256Hash)
		{
			num ^= ((object)DataSha256Hash).GetHashCode();
		}
		if (HasSrcSha256Hash)
		{
			num ^= ((object)SrcSha256Hash).GetHashCode();
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
		if (HasType)
		{
			output.WriteRawTag((byte)8);
			output.WriteEnum((int)Type);
		}
		if (HasDataOffset)
		{
			output.WriteRawTag((byte)16);
			output.WriteUInt64(DataOffset);
		}
		if (HasDataLength)
		{
			output.WriteRawTag((byte)24);
			output.WriteUInt64(DataLength);
		}
		((RepeatedField<Extent>)e).WriteTo(output, (FieldCodec<Extent>)d);
		if (HasSrcLength)
		{
			output.WriteRawTag((byte)40);
			output.WriteUInt64(SrcLength);
		}
		((RepeatedField<Extent>)_14).WriteTo(output, (FieldCodec<Extent>)_13);
		if (HasDstLength)
		{
			output.WriteRawTag((byte)56);
			output.WriteUInt64(DstLength);
		}
		if (HasDataSha256Hash)
		{
			output.WriteRawTag((byte)66);
			output.WriteBytes(DataSha256Hash);
		}
		if (HasSrcSha256Hash)
		{
			output.WriteRawTag((byte)74);
			output.WriteBytes(SrcSha256Hash);
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
		if (HasType)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
		}
		if (HasDataOffset)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(DataOffset);
		}
		if (HasDataLength)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(DataLength);
		}
		num += ((RepeatedField<Extent>)e).CalculateSize((FieldCodec<Extent>)d);
		if (HasSrcLength)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(SrcLength);
		}
		num += ((RepeatedField<Extent>)_14).CalculateSize((FieldCodec<Extent>)_13);
		if (HasDstLength)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(DstLength);
		}
		if (HasDataSha256Hash)
		{
			num += 1 + CodedOutputStream.ComputeBytesSize(DataSha256Hash);
		}
		if (HasSrcSha256Hash)
		{
			num += 1 + CodedOutputStream.ComputeBytesSize(SrcSha256Hash);
		}
		if (_1 != null)
		{
			num += ((UnknownFieldSet)_1).CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	public void MergeFrom(InstallOperation other)
	{
		if (other != null)
		{
			if (other.HasType)
			{
				Type = other.Type;
			}
			if (other.HasDataOffset)
			{
				DataOffset = other.DataOffset;
			}
			if (other.HasDataLength)
			{
				DataLength = other.DataLength;
			}
			((RepeatedField<Extent>)e).Add((IEnumerable<Extent>)other.e);
			if (other.HasSrcLength)
			{
				SrcLength = other.SrcLength;
			}
			((RepeatedField<Extent>)_14).Add((IEnumerable<Extent>)other._14);
			if (other.HasDstLength)
			{
				DstLength = other.DstLength;
			}
			if (other.HasDataSha256Hash)
			{
				DataSha256Hash = other.DataSha256Hash;
			}
			if (other.HasSrcSha256Hash)
			{
				SrcSha256Hash = other.SrcSha256Hash;
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
				Type = (Types.Type)input.ReadEnum();
				break;
			case 16u:
				DataOffset = input.ReadUInt64();
				break;
			case 24u:
				DataLength = input.ReadUInt64();
				break;
			case 34u:
				((RepeatedField<Extent>)e).AddEntriesFrom(input, (FieldCodec<Extent>)d);
				break;
			case 40u:
				SrcLength = input.ReadUInt64();
				break;
			case 50u:
				((RepeatedField<Extent>)_14).AddEntriesFrom(input, (FieldCodec<Extent>)_13);
				break;
			case 56u:
				DstLength = input.ReadUInt64();
				break;
			case 66u:
				DataSha256Hash = input.ReadBytes();
				break;
			case 74u:
				SrcSha256Hash = input.ReadBytes();
				break;
			}
		}
	}
}
