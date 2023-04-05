namespace Code.Features.MostFrequentlyUsedWords.Domain
{
    internal interface IMostFrequentlyUsedWords
    {
        List<string> Top3(string input);
    }
}
