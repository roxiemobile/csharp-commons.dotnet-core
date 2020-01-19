namespace RoxieMobile.CSharpCommons.Cryptography.Abstractions
{
    public interface IHighwayHash128Provider
    {
        byte[] GetHighwayHash128(byte[] key);
    }
}
