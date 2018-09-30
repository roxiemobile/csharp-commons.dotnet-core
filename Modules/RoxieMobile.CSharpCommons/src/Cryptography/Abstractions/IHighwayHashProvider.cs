namespace RoxieMobile.CSharpCommons.Cryptography.Abstractions
{
    public interface IHighwayHashProvider :
        IHighwayHash64Provider,
        IHighwayHash128Provider,
        IHighwayHash256Provider
    {}
}