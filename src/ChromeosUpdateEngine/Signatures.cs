// Generated protobuf compatibility code must read/write its deprecated version field.
#pragma warning disable CS0612
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace ChromeosUpdateEngine;

public sealed class Signatures : IMessage<Signatures>, IMessage, IEquatable<Signatures>, IDeepCloneable<Signatures>
{
	[DebuggerNonUserCode]
	public static class Types
	{
		public sealed class Signature : IMessage<Signature>, IMessage, IEquatable<Signature>, IDeepCloneable<Signature>
		{
			private static readonly object _0 = new MessageParser<Signature>((Func<Signature>)(() => new Signature()));

			private object _1;

			private IntPtr _2;

			public const int VersionFieldNumber = 1;

			private static readonly uint _4 = 0u;

			private uint _5;

			public const int DataFieldNumber = 2;

			private static readonly object _7 = ByteString.Empty;

			private object _8;

			public const int UnpaddedSignatureSizeFieldNumber = 3;

			private static readonly uint a = 0u;

			private uint b;

			[DebuggerNonUserCode]
			public static MessageParser<Signature> Parser => (MessageParser<Signature>)_0;

			[DebuggerNonUserCode]
			public static MessageDescriptor Descriptor => Signatures.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[Obsolete]
			public uint Version
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
			[Obsolete]
			public bool HasVersion => ((nint)_2 & 1) != 0;

			[DebuggerNonUserCode]
			public ByteString Data
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
			public bool HasData => (ByteString)_8 != (ByteString)null;

			[DebuggerNonUserCode]
			public uint UnpaddedSignatureSize
			{
				get
				{
					if (((nint)_2 & 2) != 0)
					{
						return b;
					}
					return a;
				}
				set
				{
					_2 |= (nint)2;
					b = value;
				}
			}

			[DebuggerNonUserCode]
			public bool HasUnpaddedSignatureSize => ((nint)_2 & 2) != 0;

			[DebuggerNonUserCode]
			public Signature()
			{
			}

			[DebuggerNonUserCode]
			public Signature(Signature other)
				: this()
			{
				_2 = other._2;
				_5 = other._5;
				_8 = other._8;
				b = other.b;
				_1 = UnknownFieldSet.Clone((UnknownFieldSet)other._1);
			}

			[DebuggerNonUserCode]
			public Signature Clone()
			{
				return new Signature(this);
			}

			[Obsolete]
			[DebuggerNonUserCode]
			public void ClearVersion()
			{
				_2 &= (nint)(-2);
			}

			[DebuggerNonUserCode]
			public void ClearData()
			{
				_8 = null;
			}

			[DebuggerNonUserCode]
			public void ClearUnpaddedSignatureSize()
			{
				_2 &= (nint)(-3);
			}

			[DebuggerNonUserCode]
			public override bool Equals(object other)
			{
				return Equals(other as Signature);
			}

			[DebuggerNonUserCode]
			public bool Equals(Signature other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Version != other.Version)
				{
					return false;
				}
				if (Data != other.Data)
				{
					return false;
				}
				if (UnpaddedSignatureSize != other.UnpaddedSignatureSize)
				{
					return false;
				}
				return object.Equals(_1, other._1);
			}

			[DebuggerNonUserCode]
			public override int GetHashCode()
			{
				int num = 1;
				if (HasVersion)
				{
					num ^= Version.GetHashCode();
				}
				if (HasData)
				{
					num ^= ((object)Data).GetHashCode();
				}
				if (HasUnpaddedSignatureSize)
				{
					num ^= UnpaddedSignatureSize.GetHashCode();
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
				if (HasVersion)
				{
					output.WriteRawTag((byte)8);
					output.WriteUInt32(Version);
				}
				if (HasData)
				{
					output.WriteRawTag((byte)18);
					output.WriteBytes(Data);
				}
				if (HasUnpaddedSignatureSize)
				{
					output.WriteRawTag((byte)29);
					output.WriteFixed32(UnpaddedSignatureSize);
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
				if (HasVersion)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Version);
				}
				if (HasData)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(Data);
				}
				if (HasUnpaddedSignatureSize)
				{
					num += 5;
				}
				if (_1 != null)
				{
					num += ((UnknownFieldSet)_1).CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			public void MergeFrom(Signature other)
			{
				if (other != null)
				{
					if (other.HasVersion)
					{
						Version = other.Version;
					}
					if (other.HasData)
					{
						Data = other.Data;
					}
					if (other.HasUnpaddedSignatureSize)
					{
						UnpaddedSignatureSize = other.UnpaddedSignatureSize;
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
						Version = input.ReadUInt32();
						break;
					case 18u:
						Data = input.ReadBytes();
						break;
					case 29u:
						UnpaddedSignatureSize = input.ReadFixed32();
						break;
					}
				}
			}
		}
	}

	private static readonly object _0 = new MessageParser<Signatures>((Func<Signatures>)(() => new Signatures()));

	private object _1;

	public const int Signatures_FieldNumber = 1;

	private static readonly object _3 = FieldCodec.ForMessage<Types.Signature>(10u, Types.Signature.Parser);

	private readonly object _4 = new RepeatedField<Types.Signature>();

	[DebuggerNonUserCode]
	public static MessageParser<Signatures> Parser => (MessageParser<Signatures>)_0;

	[DebuggerNonUserCode]
	public static MessageDescriptor Descriptor => UpdateMetadataReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	public RepeatedField<Types.Signature> Signatures_ => (RepeatedField<Types.Signature>)_4;

	[DebuggerNonUserCode]
	public Signatures()
	{
	}

	[DebuggerNonUserCode]
	public Signatures(Signatures other)
		: this()
	{
		_4 = ((RepeatedField<Types.Signature>)other._4).Clone();
		_1 = UnknownFieldSet.Clone((UnknownFieldSet)other._1);
	}

	[DebuggerNonUserCode]
	public Signatures Clone()
	{
		return new Signatures(this);
	}

	[DebuggerNonUserCode]
	public override bool Equals(object other)
	{
		return Equals(other as Signatures);
	}

	[DebuggerNonUserCode]
	public bool Equals(Signatures other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!((RepeatedField<Types.Signature>)_4).Equals((RepeatedField<Types.Signature>)other._4))
		{
			return false;
		}
		return object.Equals(_1, other._1);
	}

	[DebuggerNonUserCode]
	public override int GetHashCode()
	{
		int num = 1;
		num ^= _4.GetHashCode();
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
		((RepeatedField<Types.Signature>)_4).WriteTo(output, (FieldCodec<Types.Signature>)_3);
		if (_1 != null)
		{
			((UnknownFieldSet)_1).WriteTo(output);
		}
	}

	[DebuggerNonUserCode]
	public int CalculateSize()
	{
		int num = 0;
		num += ((RepeatedField<Types.Signature>)_4).CalculateSize((FieldCodec<Types.Signature>)_3);
		if (_1 != null)
		{
			num += ((UnknownFieldSet)_1).CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	public void MergeFrom(Signatures other)
	{
		if (other != null)
		{
			((RepeatedField<Types.Signature>)_4).Add((IEnumerable<Types.Signature>)other._4);
			_1 = UnknownFieldSet.MergeFrom((UnknownFieldSet)_1, (UnknownFieldSet)other._1);
		}
	}

	[DebuggerNonUserCode]
	public void MergeFrom(CodedInputStream input)
	{
		uint num;
		while ((num = input.ReadTag()) != 0)
		{
			uint num2 = num;
			uint num3 = num2;
			if (num3 != 10)
			{
				_1 = UnknownFieldSet.MergeFieldFrom((UnknownFieldSet)_1, input);
			}
			else
			{
				((RepeatedField<Types.Signature>)_4).AddEntriesFrom(input, (FieldCodec<Types.Signature>)_3);
			}
		}
	}
}
#pragma warning restore CS0612
