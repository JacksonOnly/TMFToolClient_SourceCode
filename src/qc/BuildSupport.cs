namespace qc;

// Preserve native-sized decompiler locals without taking managed stack addresses.
internal static class NativeValues
{
    internal static bool TryParseBoolean(string text, out nint result)
    {
        bool success = bool.TryParse(text, out bool value);
        result = value ? 1 : 0;
        return success;
    }

    internal static bool TryParseInt32(string text, out nint result)
    {
        bool success = int.TryParse(text, out int value);
        result = value;
        return success;
    }
}

internal sealed class PartitionSelection
{
    public string Label { get; set; }
    public string Filename { get; set; }
    public string SDName { get; set; }
    public string FilePath { get; set; }
}

internal sealed class ProgramEntry
{
    public string Label { get; set; }
    public string Filename { get; set; }
    public string SDname { get; set; }
    public string Size { get; set; }
}
