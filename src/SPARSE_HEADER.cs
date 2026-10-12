public struct SPARSE_HEADER
{
	public int dwMagic;

	public short wVerMajor;

	public short wVerMinor;

	public short wSparseHeaderSize;

	public short wChunkHeaderSize;

	public int dwBlockSize;

	public int dwTotalBlocks;

	public int dwTotalChunks;

	public int dwImageChecksum;
}
