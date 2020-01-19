namespace RoxieMobile.CSharpCommons.Cryptography.Abstractions
{
    public interface IHighwayHash64Provider
    {
        byte[] GetHighwayHash64(byte[] key);
    }
}
