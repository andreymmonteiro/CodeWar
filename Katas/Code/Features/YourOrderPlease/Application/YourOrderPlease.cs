using Code.Features.YourOrderPlease.Domain;
using System.Text;

namespace Code.Features.YourOrderPlease.Application
{
    internal class YourOrderPlease : IYourOrderPlease
    {
        public string SortString(string value)
            => string.Join(" ", value.Split().OrderBy(o => o.FirstOrDefault(char.IsDigit)));
    }
}
