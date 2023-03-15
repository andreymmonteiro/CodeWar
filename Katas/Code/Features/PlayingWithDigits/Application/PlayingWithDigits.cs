using BenchmarkDotNet.Attributes;
using Code.Features.PlayingWithDigits.Domain;

namespace Code.Features.PlayingWithDigits.Application
{
    [MemoryDiagnoser]
    public class PlayingWithDigits : IPlayingWithDigits
    {
        public int KValue(int n, int p)
        {
            if(n <= default(int) || p <= default(int))
                return 0;

            var result = GeneratePowResult(n, p);

            var k = result / n;

            if (n * k == result)
                return int.TryParse(k.ToString(), out var value) ? value : default;

            return -1;
        }

        private static double GeneratePowResult(int n, int p)
        {
            var nConverted = n.ToString().ToCharArray();

            double result = 0;

            for (int i = 0; i < nConverted.Length; i++)
            {
                result += Math.Pow(int.Parse(nConverted[i].ToString()), p);
                p++;
            }
            return result;
        }
    }
}
