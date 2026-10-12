namespace QcomTool;

public struct FIREHOSE_CONFIG
{
	public int Version;

	public string MemoryName;

	public int SkipWrite;

	public int SkipStorageInit;

	public int ZLPAwareHost;

	public int ActivePartition;

	public int MaxPayloadSizeToTargetInBytes;

	public int AckRawDataEveryNumPackets;

	public int maxPayloadSizeFromTargetInBytes;
}
