using Code.Features.MostFrequentlyUsedWords.Domain;
using System.Text;
using System.Text.RegularExpressions;

namespace Code.Features.MostFrequentlyUsedWords.Application
{
    internal class MostFrequentlyUsedWords : IMostFrequentlyUsedWords
    {
        public List<string> Top3(string s)
        {
            var inputResult = s
                                .OnlyAllowCaracters()
                                .Split()
                                .Where(value => value.IsOnlyAllowValues());

            return inputResult
                        .GroupBy(g => g)
                        .OrderByDescending(word => word.Count())
                        .ThenBy(word => word.Key)
                        .Select(m => m.Key.ToLower())
                        .Take(3)
                        .ToList();

        }


    }
    internal static class StringHelper
    {
        public static string OnlyAllowCaracters(this string s, bool onlyLetters = false)
        {
            var build = new StringBuilder();
            foreach (var value in s)
            {
                if (value.IsOnlyLetters() || value.IsAllowCaracter(onlyLetters))
                {
                    build.Append(value);
                    continue;
                }
                build.Append(' ');
            }
            return build.ToString();
        }



        public static bool IsOnlyAllowValues(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            for(int i=0; i < value.Length; i++)
            {
                return value[i].IsOnlyLetters();
            }
            return false;
        }

        private static bool IsOnlyLetters(this char value)
            => (value >= 'a' && value <= 'z') || (value >= 'A' && value <= 'Z');

        public static bool IsAllowCaracter(this char value, bool onlyLetters)
        {
            return !onlyLetters && value == '\'' || value == ' ';
        }
    }

}
