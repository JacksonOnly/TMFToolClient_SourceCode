using System;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace ChromeosUpdateEngine;

public sealed class ImageInfo : IMessage<ImageInfo>, IMessage, IEquatable<ImageInfo>, IDeepCloneable<ImageInfo>
{
	private static readonly object _0 = new MessageParser<ImageInfo>((Func<ImageInfo>)(() => new ImageInfo()));

	private object _1;

	public const int BoardFieldNumber = 1;

	private static readonly object _3 = "";

	private object _4;

	public const int KeyFieldNumber = 2;

	private static readonly object _6 = "";

	private object _7;

	public const int ChannelFieldNumber = 3;

	private static readonly object _9 = "";

	private object a;

	public const int VersionFieldNumber = 4;

	private static readonly object c = "";

	private object d;

	public const int BuildChannelFieldNumber = 5;

	private static readonly object f = "";

	private object _10;

	public const int BuildVersionFieldNumber = 6;

	private static readonly object _12 = "";

	private object _13;

	[DebuggerNonUserCode]
	public static MessageParser<ImageInfo> Parser => (MessageParser<ImageInfo>)_0;

	[DebuggerNonUserCode]
	public static MessageDescriptor Descriptor => UpdateMetadataReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	public string Board
	{
		get
		{
			return (string)(_4 ?? _3);
		}
		set
		{
			_4 = ProtoPreconditions.CheckNotNull<string>(value, "value");
		}
	}

	[DebuggerNonUserCode]
	public bool HasBoard => _4 != null;

	[DebuggerNonUserCode]
	public string Key
	{
		get
		{
			return (string)(_7 ?? _6);
		}
		set
		{
			_7 = ProtoPreconditions.CheckNotNull<string>(value, "value");
		}
	}

	[DebuggerNonUserCode]
	public bool HasKey => _7 != null;

	[DebuggerNonUserCode]
	public string Channel
	{
		get
		{
			return (string)(a ?? _9);
		}
		set
		{
			a = ProtoPreconditions.CheckNotNull<string>(value, "value");
		}
	}

	[DebuggerNonUserCode]
	public bool HasChannel => a != null;

	[DebuggerNonUserCode]
	public string Version
	{
		get
		{
			return (string)(d ?? c);
		}
		set
		{
			d = ProtoPreconditions.CheckNotNull<string>(value, "value");
		}
	}

	[DebuggerNonUserCode]
	public bool HasVersion => d != null;

	[DebuggerNonUserCode]
	public string BuildChannel
	{
		get
		{
			return (string)(_10 ?? f);
		}
		set
		{
			_10 = ProtoPreconditions.CheckNotNull<string>(value, "value");
		}
	}

	[DebuggerNonUserCode]
	public bool HasBuildChannel => _10 != null;

	[DebuggerNonUserCode]
	public string BuildVersion
	{
		get
		{
			return (string)(_13 ?? _12);
		}
		set
		{
			_13 = ProtoPreconditions.CheckNotNull<string>(value, "value");
		}
	}

	[DebuggerNonUserCode]
	public bool HasBuildVersion => _13 != null;

	[DebuggerNonUserCode]
	public ImageInfo()
	{
	}

	[DebuggerNonUserCode]
	public ImageInfo(ImageInfo other)
		: this()
	{
		_4 = other._4;
		_7 = other._7;
		a = other.a;
		d = other.d;
		_10 = other._10;
		_13 = other._13;
		_1 = UnknownFieldSet.Clone((UnknownFieldSet)other._1);
	}

	[DebuggerNonUserCode]
	public ImageInfo Clone()
	{
		return new ImageInfo(this);
	}

	[DebuggerNonUserCode]
	public void ClearBoard()
	{
		_4 = null;
	}

	[DebuggerNonUserCode]
	public void ClearKey()
	{
		_7 = null;
	}

	[DebuggerNonUserCode]
	public void ClearChannel()
	{
		a = null;
	}

	[DebuggerNonUserCode]
	public void ClearVersion()
	{
		d = null;
	}

	[DebuggerNonUserCode]
	public void ClearBuildChannel()
	{
		_10 = null;
	}

	[DebuggerNonUserCode]
	public void ClearBuildVersion()
	{
		_13 = null;
	}

	[DebuggerNonUserCode]
	public override bool Equals(object other)
	{
		return Equals(other as ImageInfo);
	}

	[DebuggerNonUserCode]
	public bool Equals(ImageInfo other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Board != other.Board)
		{
			return false;
		}
		if (Key != other.Key)
		{
			return false;
		}
		if (Channel != other.Channel)
		{
			return false;
		}
		if (Version != other.Version)
		{
			return false;
		}
		if (BuildChannel != other.BuildChannel)
		{
			return false;
		}
		if (BuildVersion != other.BuildVersion)
		{
			return false;
		}
		return object.Equals(_1, other._1);
	}

	[DebuggerNonUserCode]
	public override int GetHashCode()
	{
		int num = 1;
		if (HasBoard)
		{
			num ^= Board.GetHashCode();
		}
		if (HasKey)
		{
			num ^= Key.GetHashCode();
		}
		if (HasChannel)
		{
			num ^= Channel.GetHashCode();
		}
		if (HasVersion)
		{
			num ^= Version.GetHashCode();
		}
		if (HasBuildChannel)
		{
			num ^= BuildChannel.GetHashCode();
		}
		if (HasBuildVersion)
		{
			num ^= BuildVersion.GetHashCode();
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
		if (HasBoard)
		{
			output.WriteRawTag((byte)10);
			output.WriteString(Board);
		}
		if (HasKey)
		{
			output.WriteRawTag((byte)18);
			output.WriteString(Key);
		}
		if (HasChannel)
		{
			output.WriteRawTag((byte)26);
			output.WriteString(Channel);
		}
		if (HasVersion)
		{
			output.WriteRawTag((byte)34);
			output.WriteString(Version);
		}
		if (HasBuildChannel)
		{
			output.WriteRawTag((byte)42);
			output.WriteString(BuildChannel);
		}
		if (HasBuildVersion)
		{
			output.WriteRawTag((byte)50);
			output.WriteString(BuildVersion);
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
		if (HasBoard)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Board);
		}
		if (HasKey)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Key);
		}
		if (HasChannel)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Channel);
		}
		if (HasVersion)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Version);
		}
		if (HasBuildChannel)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(BuildChannel);
		}
		if (HasBuildVersion)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(BuildVersion);
		}
		if (_1 != null)
		{
			num += ((UnknownFieldSet)_1).CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	public void MergeFrom(ImageInfo other)
	{
		if (other != null)
		{
			if (other.HasBoard)
			{
				Board = other.Board;
			}
			if (other.HasKey)
			{
				Key = other.Key;
			}
			if (other.HasChannel)
			{
				Channel = other.Channel;
			}
			if (other.HasVersion)
			{
				Version = other.Version;
			}
			if (other.HasBuildChannel)
			{
				BuildChannel = other.BuildChannel;
			}
			if (other.HasBuildVersion)
			{
				BuildVersion = other.BuildVersion;
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
				Board = input.ReadString();
				break;
			case 18u:
				Key = input.ReadString();
				break;
			case 26u:
				Channel = input.ReadString();
				break;
			case 34u:
				Version = input.ReadString();
				break;
			case 42u:
				BuildChannel = input.ReadString();
				break;
			case 50u:
				BuildVersion = input.ReadString();
				break;
			}
		}
	}
}
