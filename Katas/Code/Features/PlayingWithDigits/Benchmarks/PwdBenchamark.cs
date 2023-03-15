using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;

namespace Code.Features.PlayingWithDigits.Benchmarks
{
    [MemoryDiagnoser]
    public class PwdBenchamark
    {
        [Benchmark]
        public double GeneratePowResult()
        {
            var n = 46288;
            var p = 3;

            var nConverted = n.ToString().ToCharArray();

            double result = 0;

            for (int i = 0; i < nConverted.Length; i++)
            {
                result += Math.Pow(int.Parse(nConverted[i].ToString()), p);
                p++;
            }
            return result;
        }

        [Benchmark]
        public double GeneratePowResultAsSpan()
        {
            var n = 46288;
            var p = 3;

            var nConverted = CollectionsMarshal.AsSpan(n.ToString().ToCharArray().ToList());

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
