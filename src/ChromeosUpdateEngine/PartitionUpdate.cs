using System;
using System.Collections.Generic;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace ChromeosUpdateEngine;

public sealed class PartitionUpdate : IMessage<PartitionUpdate>, IMessage, IEquatable<PartitionUpdate>, IDeepCloneable<PartitionUpdate>
{
	private static readonly object _0 = new MessageParser<PartitionUpdate>((Func<PartitionUpdate>)(() => new PartitionUpdate()));

	private object _1;

	private IntPtr _2;

	public const int PartitionNameFieldNumber = 1;

	private static readonly object _4 = "";

	private object _5;

	public const int RunPostinstallFieldNumber = 2;

	private static readonly IntPtr _7 = (IntPtr)0;

	private IntPtr _8;

	public const int PostinstallPathFieldNumber = 3;

	private static readonly object a = "";

	private object b;

	public const int FilesystemTypeFieldNumber = 4;

	private static readonly object d = "";

	private object e;

	public const int NewPartitionSignatureFieldNumber = 5;

	private static readonly object _10 = FieldCodec.ForMessage<Signatures.Types.Signature>(42u, Signatures.Types.Signature.Parser);

	private readonly object _11 = new RepeatedField<Signatures.Types.Signature>();

	public const int OldPartitionInfoFieldNumber = 6;

	private object _13;

	public const int NewPartitionInfoFieldNumber = 7;

	private object _15;

	public const int OperationsFieldNumber = 8;

	private static readonly object _17 = FieldCodec.ForMessage<InstallOperation>(66u, InstallOperation.Parser);

	private readonly object _18 = new RepeatedField<InstallOperation>();

	public const int PostinstallOptionalFieldNumber = 9;

	private static readonly IntPtr _1a = (IntPtr)0;

	private IntPtr _1b;

	public const int HashTreeDataExtentFieldNumber = 10;

	private object _1d;

	public const int HashTreeExtentFieldNumber = 11;

	private object _1f;

	public const int HashTreeAlgorithmFieldNumber = 12;

	private static readonly object _21 = "";

	private object _22;

	public const int HashTreeSaltFieldNumber = 13;

	private static readonly object _24 = ByteString.Empty;

	private object _25;

	public const int FecDataExtentFieldNumber = 14;

	private object _27;

	public const int FecExtentFieldNumber = 15;

	private object _29;

	public const int FecRootsFieldNumber = 16;

	private static readonly uint _2b = 2u;

	private uint _2c;

	[DebuggerNonUserCode]
	public static MessageParser<PartitionUpdate> Parser => (MessageParser<PartitionUpdate>)_0;

	[DebuggerNonUserCode]
	public static MessageDescriptor Descriptor => UpdateMetadataReflection.Descriptor.MessageTypes[5];

	[DebuggerNonUserCode]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	public string PartitionName
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
	public bool HasPartitionName => _5 != null;

	[DebuggerNonUserCode]
	public bool RunPostinstall
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
	public bool HasRunPostinstall => ((nint)_2 & 1) != 0;

	[DebuggerNonUserCode]
	public string PostinstallPath
	{
		get
		{
			return (string)(b ?? a);
		}
		set
		{
			b = ProtoPreconditions.CheckNotNull<string>(value, "value");
		}
	}

	[DebuggerNonUserCode]
	public bool HasPostinstallPath => b != null;

	[DebuggerNonUserCode]
	public string FilesystemType
	{
		get
		{
			return (string)(e ?? d);
		}
		set
		{
			e = ProtoPreconditions.CheckNotNull<string>(value, "value");
		}
	}

	[DebuggerNonUserCode]
	public bool HasFilesystemType => e != null;

	[DebuggerNonUserCode]
	public RepeatedField<Signatures.Types.Signature> NewPartitionSignature => (RepeatedField<Signatures.Types.Signature>)_11;

	[DebuggerNonUserCode]
	public PartitionInfo OldPartitionInfo
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
	public PartitionInfo NewPartitionInfo
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
	public RepeatedField<InstallOperation> Operations => (RepeatedField<InstallOperation>)_18;

	[DebuggerNonUserCode]
	public bool PostinstallOptional
	{
		get
		{
			if (((nint)_2 & 2) != 0)
			{
				return (byte)(nint)_1b != 0;
			}
			return (byte)(nint)_1a != 0;
		}
		set
		{
			_2 |= (nint)2;
			_1b = (IntPtr)(value ? 1 : 0);
		}
	}

	[DebuggerNonUserCode]
	public bool HasPostinstallOptional => ((nint)_2 & 2) != 0;

	[DebuggerNonUserCode]
	public Extent HashTreeDataExtent
	{
		get
		{
			return (Extent)_1d;
		}
		set
		{
			_1d = value;
		}
	}

	[DebuggerNonUserCode]
	public Extent HashTreeExtent
	{
		get
		{
			return (Extent)_1f;
		}
		set
		{
			_1f = value;
		}
	}

	[DebuggerNonUserCode]
	public string HashTreeAlgorithm
	{
		get
		{
			return (string)(_22 ?? _21);
		}
		set
		{
			_22 = ProtoPreconditions.CheckNotNull<string>(value, "value");
		}
	}

	[DebuggerNonUserCode]
	public bool HasHashTreeAlgorithm => _22 != null;

	[DebuggerNonUserCode]
	public ByteString HashTreeSalt
	{
		get
		{
			return (ByteString)(_25 ?? _24);
		}
		set
		{
			_25 = ProtoPreconditions.CheckNotNull<ByteString>(value, "value");
		}
	}

	[DebuggerNonUserCode]
	public bool HasHashTreeSalt => (ByteString)_25 != (ByteString)null;

	[DebuggerNonUserCode]
	public Extent FecDataExtent
	{
		get
		{
			return (Extent)_27;
		}
		set
		{
			_27 = value;
		}
	}

	[DebuggerNonUserCode]
	public Extent FecExtent
	{
		get
		{
			return (Extent)_29;
		}
		set
		{
			_29 = value;
		}
	}

	[DebuggerNonUserCode]
	public uint FecRoots
	{
		get
		{
			if (((nint)_2 & 4) != 0)
			{
				return _2c;
			}
			return _2b;
		}
		set
		{
			_2 |= (nint)4;
			_2c = value;
		}
	}

	[DebuggerNonUserCode]
	public bool HasFecRoots => ((nint)_2 & 4) != 0;

	[DebuggerNonUserCode]
	public PartitionUpdate()
	{
	}

	[DebuggerNonUserCode]
	public PartitionUpdate(PartitionUpdate other)
		: this()
	{
		_2 = other._2;
		_5 = other._5;
		_8 = other._8;
		b = other.b;
		e = other.e;
		_11 = ((RepeatedField<Signatures.Types.Signature>)other._11).Clone();
		_13 = ((other._13 != null) ? ((PartitionInfo)other._13).Clone() : null);
		_15 = ((other._15 != null) ? ((PartitionInfo)other._15).Clone() : null);
		_18 = ((RepeatedField<InstallOperation>)other._18).Clone();
		_1b = other._1b;
		_1d = ((other._1d != null) ? ((Extent)other._1d).Clone() : null);
		_1f = ((other._1f != null) ? ((Extent)other._1f).Clone() : null);
		_22 = other._22;
		_25 = other._25;
		_27 = ((other._27 != null) ? ((Extent)other._27).Clone() : null);
		_29 = ((other._29 != null) ? ((Extent)other._29).Clone() : null);
		_2c = other._2c;
		_1 = UnknownFieldSet.Clone((UnknownFieldSet)other._1);
	}

	[DebuggerNonUserCode]
	public PartitionUpdate Clone()
	{
		return new PartitionUpdate(this);
	}

	[DebuggerNonUserCode]
	public void ClearPartitionName()
	{
		_5 = null;
	}

	[DebuggerNonUserCode]
	public void ClearRunPostinstall()
	{
		_2 &= (nint)(-2);
	}

	[DebuggerNonUserCode]
	public void ClearPostinstallPath()
	{
		b = null;
	}

	[DebuggerNonUserCode]
	public void ClearFilesystemType()
	{
		e = null;
	}

	[DebuggerNonUserCode]
	public void ClearPostinstallOptional()
	{
		_2 &= (nint)(-3);
	}

	[DebuggerNonUserCode]
	public void ClearHashTreeAlgorithm()
	{
		_22 = null;
	}

	[DebuggerNonUserCode]
	public void ClearHashTreeSalt()
	{
		_25 = null;
	}

	[DebuggerNonUserCode]
	public void ClearFecRoots()
	{
		_2 &= (nint)(-5);
	}

	[DebuggerNonUserCode]
	public override bool Equals(object other)
	{
		return Equals(other as PartitionUpdate);
	}

	[DebuggerNonUserCode]
	public bool Equals(PartitionUpdate other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (PartitionName != other.PartitionName)
		{
			return false;
		}
		if (RunPostinstall != other.RunPostinstall)
		{
			return false;
		}
		if (PostinstallPath != other.PostinstallPath)
		{
			return false;
		}
		if (FilesystemType != other.FilesystemType)
		{
			return false;
		}
		if (!((RepeatedField<Signatures.Types.Signature>)_11).Equals((RepeatedField<Signatures.Types.Signature>)other._11))
		{
			return false;
		}
		if (!object.Equals(OldPartitionInfo, other.OldPartitionInfo))
		{
			return false;
		}
		if (!object.Equals(NewPartitionInfo, other.NewPartitionInfo))
		{
			return false;
		}
		if (!((RepeatedField<InstallOperation>)_18).Equals((RepeatedField<InstallOperation>)other._18))
		{
			return false;
		}
		if (PostinstallOptional != other.PostinstallOptional)
		{
			return false;
		}
		if (!object.Equals(HashTreeDataExtent, other.HashTreeDataExtent))
		{
			return false;
		}
		if (!object.Equals(HashTreeExtent, other.HashTreeExtent))
		{
			return false;
		}
		if (HashTreeAlgorithm != other.HashTreeAlgorithm)
		{
			return false;
		}
		if (HashTreeSalt != other.HashTreeSalt)
		{
			return false;
		}
		if (!object.Equals(FecDataExtent, other.FecDataExtent))
		{
			return false;
		}
		if (!object.Equals(FecExtent, other.FecExtent))
		{
			return false;
		}
		if (FecRoots != other.FecRoots)
		{
			return false;
		}
		return object.Equals(_1, other._1);
	}

	[DebuggerNonUserCode]
	public override int GetHashCode()
	{
		int num = 1;
		if (HasPartitionName)
		{
			num ^= PartitionName.GetHashCode();
		}
		if (HasRunPostinstall)
		{
			num ^= RunPostinstall.GetHashCode();
		}
		if (HasPostinstallPath)
		{
			num ^= PostinstallPath.GetHashCode();
		}
		if (HasFilesystemType)
		{
			num ^= FilesystemType.GetHashCode();
		}
		num ^= _11.GetHashCode();
		if (_13 != null)
		{
			num ^= OldPartitionInfo.GetHashCode();
		}
		if (_15 != null)
		{
			num ^= NewPartitionInfo.GetHashCode();
		}
		num ^= _18.GetHashCode();
		if (HasPostinstallOptional)
		{
			num ^= PostinstallOptional.GetHashCode();
		}
		if (_1d != null)
		{
			num ^= HashTreeDataExtent.GetHashCode();
		}
		if (_1f != null)
		{
			num ^= HashTreeExtent.GetHashCode();
		}
		if (HasHashTreeAlgorithm)
		{
			num ^= HashTreeAlgorithm.GetHashCode();
		}
		if (HasHashTreeSalt)
		{
			num ^= ((object)HashTreeSalt).GetHashCode();
		}
		if (_27 != null)
		{
			num ^= FecDataExtent.GetHashCode();
		}
		if (_29 != null)
		{
			num ^= FecExtent.GetHashCode();
		}
		if (HasFecRoots)
		{
			num ^= FecRoots.GetHashCode();
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
		if (HasPartitionName)
		{
			output.WriteRawTag((byte)10);
			output.WriteString(PartitionName);
		}
		if (HasRunPostinstall)
		{
			output.WriteRawTag((byte)16);
			output.WriteBool(RunPostinstall);
		}
		if (HasPostinstallPath)
		{
			output.WriteRawTag((byte)26);
			output.WriteString(PostinstallPath);
		}
		if (HasFilesystemType)
		{
			output.WriteRawTag((byte)34);
			output.WriteString(FilesystemType);
		}
		((RepeatedField<Signatures.Types.Signature>)_11).WriteTo(output, (FieldCodec<Signatures.Types.Signature>)_10);
		if (_13 != null)
		{
			output.WriteRawTag((byte)50);
			output.WriteMessage((IMessage)(object)OldPartitionInfo);
		}
		if (_15 != null)
		{
			output.WriteRawTag((byte)58);
			output.WriteMessage((IMessage)(object)NewPartitionInfo);
		}
		((RepeatedField<InstallOperation>)_18).WriteTo(output, (FieldCodec<InstallOperation>)_17);
		if (HasPostinstallOptional)
		{
			output.WriteRawTag((byte)72);
			output.WriteBool(PostinstallOptional);
		}
		if (_1d != null)
		{
			output.WriteRawTag((byte)82);
			output.WriteMessage((IMessage)(object)HashTreeDataExtent);
		}
		if (_1f != null)
		{
			output.WriteRawTag((byte)90);
			output.WriteMessage((IMessage)(object)HashTreeExtent);
		}
		if (HasHashTreeAlgorithm)
		{
			output.WriteRawTag((byte)98);
			output.WriteString(HashTreeAlgorithm);
		}
		if (HasHashTreeSalt)
		{
			output.WriteRawTag((byte)106);
			output.WriteBytes(HashTreeSalt);
		}
		if (_27 != null)
		{
			output.WriteRawTag((byte)114);
			output.WriteMessage((IMessage)(object)FecDataExtent);
		}
		if (_29 != null)
		{
			output.WriteRawTag((byte)122);
			output.WriteMessage((IMessage)(object)FecExtent);
		}
		if (HasFecRoots)
		{
			output.WriteRawTag((byte)128, (byte)1);
			output.WriteUInt32(FecRoots);
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
		if (HasPartitionName)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(PartitionName);
		}
		if (HasRunPostinstall)
		{
			num += 2;
		}
		if (HasPostinstallPath)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(PostinstallPath);
		}
		if (HasFilesystemType)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(FilesystemType);
		}
		num += ((RepeatedField<Signatures.Types.Signature>)_11).CalculateSize((FieldCodec<Signatures.Types.Signature>)_10);
		if (_13 != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize((IMessage)(object)OldPartitionInfo);
		}
		if (_15 != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize((IMessage)(object)NewPartitionInfo);
		}
		num += ((RepeatedField<InstallOperation>)_18).CalculateSize((FieldCodec<InstallOperation>)_17);
		if (HasPostinstallOptional)
		{
			num += 2;
		}
		if (_1d != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize((IMessage)(object)HashTreeDataExtent);
		}
		if (_1f != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize((IMessage)(object)HashTreeExtent);
		}
		if (HasHashTreeAlgorithm)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(HashTreeAlgorithm);
		}
		if (HasHashTreeSalt)
		{
			num += 1 + CodedOutputStream.ComputeBytesSize(HashTreeSalt);
		}
		if (_27 != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize((IMessage)(object)FecDataExtent);
		}
		if (_29 != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize((IMessage)(object)FecExtent);
		}
		if (HasFecRoots)
		{
			num += 2 + CodedOutputStream.ComputeUInt32Size(FecRoots);
		}
		if (_1 != null)
		{
			num += ((UnknownFieldSet)_1).CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	public void MergeFrom(PartitionUpdate other)
	{
		if (other == null)
		{
			return;
		}
		if (other.HasPartitionName)
		{
			PartitionName = other.PartitionName;
		}
		if (other.HasRunPostinstall)
		{
			RunPostinstall = other.RunPostinstall;
		}
		if (other.HasPostinstallPath)
		{
			PostinstallPath = other.PostinstallPath;
		}
		if (other.HasFilesystemType)
		{
			FilesystemType = other.FilesystemType;
		}
		((RepeatedField<Signatures.Types.Signature>)_11).Add((IEnumerable<Signatures.Types.Signature>)other._11);
		if (other._13 != null)
		{
			if (_13 == null)
			{
				OldPartitionInfo = new PartitionInfo();
			}
			OldPartitionInfo.MergeFrom(other.OldPartitionInfo);
		}
		if (other._15 != null)
		{
			if (_15 == null)
			{
				NewPartitionInfo = new PartitionInfo();
			}
			NewPartitionInfo.MergeFrom(other.NewPartitionInfo);
		}
		((RepeatedField<InstallOperation>)_18).Add((IEnumerable<InstallOperation>)other._18);
		if (other.HasPostinstallOptional)
		{
			PostinstallOptional = other.PostinstallOptional;
		}
		if (other._1d != null)
		{
			if (_1d == null)
			{
				HashTreeDataExtent = new Extent();
			}
			HashTreeDataExtent.MergeFrom(other.HashTreeDataExtent);
		}
		if (other._1f != null)
		{
			if (_1f == null)
			{
				HashTreeExtent = new Extent();
			}
			HashTreeExtent.MergeFrom(other.HashTreeExtent);
		}
		if (other.HasHashTreeAlgorithm)
		{
			HashTreeAlgorithm = other.HashTreeAlgorithm;
		}
		if (other.HasHashTreeSalt)
		{
			HashTreeSalt = other.HashTreeSalt;
		}
		if (other._27 != null)
		{
			if (_27 == null)
			{
				FecDataExtent = new Extent();
			}
			FecDataExtent.MergeFrom(other.FecDataExtent);
		}
		if (other._29 != null)
		{
			if (_29 == null)
			{
				FecExtent = new Extent();
			}
			FecExtent.MergeFrom(other.FecExtent);
		}
		if (other.HasFecRoots)
		{
			FecRoots = other.FecRoots;
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
				PartitionName = input.ReadString();
				break;
			case 16u:
				RunPostinstall = input.ReadBool();
				break;
			case 26u:
				PostinstallPath = input.ReadString();
				break;
			case 34u:
				FilesystemType = input.ReadString();
				break;
			case 42u:
				((RepeatedField<Signatures.Types.Signature>)_11).AddEntriesFrom(input, (FieldCodec<Signatures.Types.Signature>)_10);
				break;
			case 50u:
				if (_13 == null)
				{
					OldPartitionInfo = new PartitionInfo();
				}
				input.ReadMessage((IMessage)(object)OldPartitionInfo);
				break;
			case 58u:
				if (_15 == null)
				{
					NewPartitionInfo = new PartitionInfo();
				}
				input.ReadMessage((IMessage)(object)NewPartitionInfo);
				break;
			case 66u:
				((RepeatedField<InstallOperation>)_18).AddEntriesFrom(input, (FieldCodec<InstallOperation>)_17);
				break;
			case 72u:
				PostinstallOptional = input.ReadBool();
				break;
			case 82u:
				if (_1d == null)
				{
					HashTreeDataExtent = new Extent();
				}
				input.ReadMessage((IMessage)(object)HashTreeDataExtent);
				break;
			case 90u:
				if (_1f == null)
				{
					HashTreeExtent = new Extent();
				}
				input.ReadMessage((IMessage)(object)HashTreeExtent);
				break;
			case 98u:
				HashTreeAlgorithm = input.ReadString();
				break;
			case 106u:
				HashTreeSalt = input.ReadBytes();
				break;
			case 114u:
				if (_27 == null)
				{
					FecDataExtent = new Extent();
				}
				input.ReadMessage((IMessage)(object)FecDataExtent);
				break;
			case 122u:
				if (_29 == null)
				{
					FecExtent = new Extent();
				}
				input.ReadMessage((IMessage)(object)FecExtent);
				break;
			case 128u:
				FecRoots = input.ReadUInt32();
				break;
			}
		}
	}
}
