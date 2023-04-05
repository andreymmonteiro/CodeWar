using Code.Features.YourOrderPlease.Domain;

namespace Code.Features.YourOrderPlease.Application
{
    internal class YourOrderPlease : IYourOrderPlease
    {
        public string SortString(string value)
            => string.Join(" ", value.Split().OrderBy(o => o.FirstOrDefault(char.IsDigit)));
    }
}
