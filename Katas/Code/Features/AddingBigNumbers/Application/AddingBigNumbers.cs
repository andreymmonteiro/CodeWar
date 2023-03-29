using Code.Features.AddingBigNumbers.Domain;
using System.Numerics;

namespace Code.Features.AddingBigNumbers.Application
{
    internal class AddingBigNumbers : IAddingBigNumbers
    {
        public string Add(string a, string b)
        {
            if(BigInteger.TryParse(a, out var aResult) && BigInteger.TryParse(b, out var bResult)) 
            {
                var result = (aResult + bResult);

                return result.ToString();
            }
            return string.Empty;
        }
    }
}
