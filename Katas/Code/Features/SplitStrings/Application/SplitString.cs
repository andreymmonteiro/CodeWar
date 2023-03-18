using Code.Features.SplitStrings.Domain;

namespace Code.Features.SplitStrings.Application
{
    internal class SplitString : ISplitString
    {
        public string[] SplitInTwoCharacteres(string value)
        {
            var length = value.Length;

            var result = new List<string>();

            for(int i=1; i <= length; i++)
            {
                if (i % 2 == default)
                    result.Add($"{value[i - 2]}{value[i - 1]}");
                if (i == length && !(length % 2 == default))
                    result.Add($"{value[i - 1]}_");
            }

            return result.ToArray();
        }
    }
}
