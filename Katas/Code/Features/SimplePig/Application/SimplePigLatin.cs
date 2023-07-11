using Code.Features.SimplePig.Domain;
using System.Text;

namespace Code.Features.SimplePig.Application
{
    internal class SimplePigLatin : ISimplePigLatin
    {
        public string PigIt(string str)
        {
            return string.Join(' ', str
                .Split()
                .Select(s => s.Any(char.IsPunctuation) ? s : $"{s.Substring(1)}{s[0]}ay"));
        }
    }
}
