using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct StreamWriteResponse
{
	public byte uResponse;

	public int uAddress;
}
