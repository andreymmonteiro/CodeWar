using Code.Features.StringsEndsWith.Domain;

namespace Code.Features.StringsEndsWith.Application
{
    internal class StringsEndsWith : IStringsEndsWith
    {
        public bool IsStringEndsWith(string str, string ending)
            => str.Length >= ending.Length && str.EndsWith(ending,StringComparison.OrdinalIgnoreCase);
    }
}
