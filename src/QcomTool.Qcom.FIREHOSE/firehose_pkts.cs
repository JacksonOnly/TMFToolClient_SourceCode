using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace QcomTool.Qcom.FIREHOSE;

public sealed class firehose_pkts
{
	public string xml;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private static object _1;

	public static string Sigkey
	{
		[CompilerGenerated]
		get
		{
			return (string)_1;
		}
		[CompilerGenerated]
		set
		{
			_1 = value;
		}
	}

	public static string pkt_fhConfig1(string MemName)
	{
		FIREHOSE_CONFIG fIREHOSE_CONFIG = new FIREHOSE_CONFIG
		{
			Version = 4,
			MemoryName = MemName,
			SkipWrite = 0,
			ZLPAwareHost = 1,
			SkipStorageInit = 0,
			ActivePartition = 0,
			MaxPayloadSizeToTargetInBytes = 16384,
			AckRawDataEveryNumPackets = 1
		};
		return $"<?xml version=\"1.0\"?><data><configure MemoryName=\"{fIREHOSE_CONFIG.MemoryName}\" ZLPAwareHost=\"{fIREHOSE_CONFIG.ZLPAwareHost}\" SkipStorageInit=\"{fIREHOSE_CONFIG.SkipStorageInit}\" SkipWrite=\"{fIREHOSE_CONFIG.SkipWrite.ToString()}\" MaxPayloadSizeToTargetInBytes=\"{fIREHOSE_CONFIG.MaxPayloadSizeToTargetInBytes}\"/></data>";
	}

	public static string configZTE()
	{
		return "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>\r\n<data>\r\n    <configure MemoryName=\"ufs\" Verbose=\"0\" AlwaysValidate=\"0\" MaxDigestTableSizeInBytes=\"8192\" MaxPayloadSizeToTargetInBytes=\"1048576\" ZlpAwareHost=\"1\" SkipStorageInit=\"0\" Oem=\"ZTE\" />\r\n</data>";
	}

	public static string pkt_fhConfig(string MemName, int MaxPayload)
	{
		FIREHOSE_CONFIG fIREHOSE_CONFIG = new FIREHOSE_CONFIG
		{
			Version = 4,
			MemoryName = MemName,
			SkipWrite = 0,
			ZLPAwareHost = 1,
			SkipStorageInit = 0,
			ActivePartition = 0,
			MaxPayloadSizeToTargetInBytes = MaxPayload,
			AckRawDataEveryNumPackets = 1
		};
		return "<?xml version = \"1.0\"?><data><configure MemoryName=\"" + fIREHOSE_CONFIG.MemoryName + "\" ZLPAwareHost=\"" + fIREHOSE_CONFIG.ZLPAwareHost + "\" SkipStorageInit=\"" + fIREHOSE_CONFIG.SkipStorageInit + "\" SkipWrite=\"" + fIREHOSE_CONFIG.SkipWrite + "\" MaxPayloadSizeToTargetInBytes=\"" + fIREHOSE_CONFIG.MaxPayloadSizeToTargetInBytes + "\"/></data>";
	}

	public static string pkt_setAckRaw(int val)
	{
		return $"<?xml version=\"1.0\" ?><data><configure AckRawData=\"{val}\"/></data>";
	}

	public static string pkt_peekMem(uint address64, int size)
	{
		return $" <?xml version=\"1.0\" ?><data><peek address64=\"{address64}\" SizeInBytes=\"{size}\"/></data>";
	}

	public static string pkt_reqauth()
	{
		return " <? xml version =\"1.0\" ?><data> <sig TargetName=\"req\" verbose=\"1\"/></data>";
	}

	public static string pkt_eMMCinfo(string drive)
	{
		return "<?xml version=\"1.0\" ?><data><getstorageinfo physical_partition_number=\"" + drive + "\"/></data>";
	}

	public static string pkt_ProgramUFS(int nPartSectors, string fileName, int startSector, int lun)
	{
		return $" <?xml version=\"1.0\" ?><data><program SECTOR_SIZE_IN_BYTES=\"4096\" filename=\"{fileName}\" num_partition_sectors=\"{nPartSectors}\" physical_partition_number=\"0\" start_sector=\"{lun.ToString()}\"/></data>";
	}

	public static string pkt_readSimLock()
	{
		return "<?xml version=\"1.0\" ?><data><simlock read=\"1\" len=\"32\"/></data>";
	}

	public static string BootConf()
	{
		return "<?xml version=\"1.0\" ?><data><setbootablestoragedrive value=\"0\" /></data>";
	}

	public static string pkt_readSecBoot()
	{
		return "<?xml version=\"1.0\" ?><data><getSecureBootStatus/></data>";
	}

	public static string pkt_readSerialNumber()
	{
		return "<?xml version=\"1.0\" ?><data><getserialnum /></data>";
	}

	public static string pkt_readIMEI()
	{
		return "<?xml version=\"1.0\" ?><data><readIMEI len=\"32\"/></data>";
	}

	public static string pkt_sendNop()
	{
		return "<?xml version=\"1.0\" ?><data><nop verbose=\"{0}\"  value=\"ping\"/></data>";
	}

	public static string pkt_sendReset()
	{
		return "<?xml version=\"1.0\" ?><data><power value=\"reset\"/></data>";
	}

	public static string EDL()
	{
		return "<?xml version=\"1.0\" ?><data><power verbose=\"{0}\"  value=\"reset_to_edl\" DelayInSeconds=\"1\"/></data>";
	}

	public static string pkt_read(int sectorSize, int numPartitionSectors, int physicalPartNum, string startSector)
	{
		return "<?xml version=\"1.0\" ?>\r\n<data>\r\n" + $"  <read SECTOR_SIZE_IN_BYTES=\"{sectorSize}\" num_partition_sectors=\"{numPartitionSectors}\" physical_partition_number=\"{physicalPartNum}\" start_sector=\"{startSector}\" rawmode=\"true\" />\r\n" + "</data>";
	}

	public static string pkt_Program(string sectorsize, string NumPartitionSector, string PhysicalPartition, string StartSector)
	{
		return "<?xml version = \"1.0\"?><data><program SECTOR_SIZE_IN_BYTES=\"" + sectorsize.ToString() + "\" file_sector_offset=\"0\" num_partition_sectors=\"" + NumPartitionSector.ToString() + "\"  physical_partition_number=\"" + PhysicalPartition.ToString() + "\" start_sector=\"" + StartSector.ToString() + "\"/></data>";
	}

	public static string pkt_patch(string SectorSize, string BytesOffset, string FileName, string PhysicalPartition, string SizeInBytes, string StartSector, string Value, string What)
	{
		return "<?xml version = \"1.0\"?><data><patch SECTOR_SIZE_IN_BYTES=\"" + SectorSize.ToString() + "\" byte_offset=\"" + BytesOffset.ToString() + "\" filename=\"" + FileName.ToString() + "\" physical_partition_number=\"" + PhysicalPartition.ToString() + "\" size_in_bytes=\"" + SizeInBytes.ToString() + "\" start_sector=\"" + StartSector.ToString() + "\" value=\"" + Value.ToString() + "\" what=\"" + What.ToString() + "\"/></data>";
	}

	public static string pkt_erase(string sectorSize, string numPartitionSectors, string physicalPartNum, string startSector)
	{
		return "<?xml version = \"1.0\"?><data><erase SECTOR_SIZE_IN_BYTES=\"" + sectorSize.ToString() + "\" num_partition_sectors=\"" + numPartitionSectors.ToString() + "\" physical_partition_number=\"" + physicalPartNum.ToString() + "\" start_sector=\"" + startSector.ToString() + "\"/></data>";
	}
}
