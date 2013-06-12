namespace AOUT.CH6.LogAN
{
    public interface IStringParser
    {
        string StringToParse { get; }

        bool HasCorrectHeader();
        string GetStringVersionFromHeader();
    }
}