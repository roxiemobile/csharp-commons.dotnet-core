namespace RoxieMobile.CSharpCommons.Cryptography.Abstractions
{
    public interface ISipHash64Provider
    {
        byte[] GetSipHash64(byte[] key);
    }
}
