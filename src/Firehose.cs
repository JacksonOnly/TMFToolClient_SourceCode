public class Firehose
{
	private static object _0 = "<?xml version=\"1.0\" ?><data><power verbose=\"{0}\"  value=\"reset_to_edl\" DelayInSeconds=\"1\"/></data>";

	private static object _1 = "<?xml version=\"1.0\" ?><data><power verbose=\"{0}\"  value=\"partial_reset\"/></data>";

	private static object _2 = "<?xml version=\"1.0\" ?><data><power verbose=\"{0}\"  value=\"reset\"/></data>";

	private static object _3 = "<?xml version=\"1.0\" ?><data><setbootablestoragedrive verbose=\"{0}\"  value=\"1\"/></data>";

	private static object _4 = "<?xml version=\"1.0\" ?><data><nop verbose=\"{0}\"  value=\"ping\"/></data>";

	private static object _5 = "<?xml version=\"1.0\" ?><data><configure verbose=\"{0}\" AlwaysValidate=\"0\"  ZlpAwareHost=\"1\"  MaxPayloadSizeToTargetInBytes=\"{1}\" MemoryName=\"{2}\" SkipStorageInit=\"{3}\"/></data>";

	private static object _6 = "<?xml version=\"1.0\" ?><data><erase SECTOR_SIZE_IN_BYTES=\"{0}\" physical_partition_number=\"{1}\"/></data>";

	private static object _7 = "<?xml version=\"1.0\" ?><data><peek size_in_bytes=\"4\" address64=\"0x00780198\"/></data>";

	private static object _8 = "<?xml version=\"1.0\" ?><data><peek size_in_bytes=\"10\" address64=\"0x00786134\"/></data>";

	private static object _9 = "<?xml version=\"1.0\" ?><data><xblgpt lun=\"{0}\"/></data>";

	private static object a = "<?xml version=\"1.0\" ?><data><getStorageInfo physical_partition_number=\"0\"/></data>";

	public const int PROGRAMMER_LITE = 1;

	public const int PROGRAMMER_DDR4 = 2;

	public const int PROGRAMMER_DDR5 = 3;

	public static string Partial_Reset => (string)_1;

	public static string Reset_To_Edl => (string)_0;

	public static string Reset => (string)_2;

	public static string SetBootPartition => (string)_3;

	public static string Nop => (string)_4;

	public static string Configure => (string)_5;

	public static int payload_size => 1048576;

	public static int MAX_PATCH_VALUE_LEN => 50;

	public static string ERASE => (string)_6;

	public static string PEEK => (string)_7;

	public static string PEEKCPUID => (string)_8;

	public static string XBLGPT => (string)_9;

	public static string GETSTORAGEINFO => (string)a;

	public static string FIREHOSE_PROGRAM => "<?xml version=\"1.0\" ?><data><program SECTOR_SIZE_IN_BYTES=\"{0}\" num_partition_sectors=\"{1}\" start_sector=\"{2}\" physical_partition_number=\"{3}\" {4}/></data>";

	public static string FIREHOSE_READ => "<?xml version=\"1.0\" ?><data><read SECTOR_SIZE_IN_BYTES=\"{0}\" num_partition_sectors=\"{1}\" start_sector=\"{2}\" physical_partition_number=\"{3}\" size_in_KB=\"{4}\" {5}/></data>";

	public static string FIREHOSE_FIRMWAREWRITE => "<?xml version=\"1.0\" ?><data><firmwarewrite SECTOR_SIZE_IN_BYTES=\"{0}\" num_partition_sectors=\"{1}\" start_sector=\"{2}\" physical_partition_number=\"{3}\" Version=\"1\" /></data>";

	public static string FIREHOSE_SHA256DIGEST => "<?xml version=\"1.0\" ?><data><getsha256digest SECTOR_SIZE_IN_BYTES=\"{0}\" num_partition_sectors=\"{1}\" start_sector=\"{2}\" physical_partition_number=\"{3}\"/></data>";

	public static string FIREHOSE_PATCH => "<?xml version=\"1.0\" ?><data><patch SECTOR_SIZE_IN_BYTES=\"{0}\" byte_offset=\"{1}\" filename=\"DISK\" physical_partition_number=\"{2}\" size_in_bytes=\"{3}\" start_sector=\"{4}\" value=\"{5}\" what=\"Update\" {6}/></data>";

	public static string REQ_AUTH => "<?xml version=\"1.0\" ?><data> <sig TargetName=\"req\" verbose=\"1\"/></data>";

	public static string AUTH => "<?xml version=\"1.0\" ?><data> <sig TargetName=\"sig\" value=\"{0}\" verbose=\"1\"/></data>";

	public static string AUTHP => "<?xml version=\"1.0\" ?><data> <sig TargetName=\"sig\" size_in_bytes=\"{0}\" verbose=\"1\"/></data>";
}
