internal static class _003CPrivateImplementationDetails_003E
{
    // FNV-1a string hash used by the compiler-generated switch dispatch.
    internal static uint _0(string value)
    {
        uint hash = 2166136261;
        if (value != null)
        {
            foreach (char character in value)
                hash = unchecked((hash ^ character) * 16777619);
        }
        return hash;
    }
}
