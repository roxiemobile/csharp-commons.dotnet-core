namespace RoxieMobile.CSharpCommons.Cryptography.Abstractions
{
    public interface IHighwayHash256Provider
    {
        byte[] GetHighwayHash256(byte[] key);
    }
}