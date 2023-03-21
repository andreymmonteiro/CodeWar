using BenchmarkDotNet.Attributes;

namespace Code.Features.FindDivisor.Benchmarks
{
    [MemoryDiagnoser]
    public class FdBenchmark
    {
        [Benchmark]
        public int[] GetDivisorsWithList()
        {
            int value = 12;

            if (!(value > 1))
                return null;

            var arrayDivisors = new List<int>();
            for (int i = 2; i < value; i++)
            {
                if (value % i == 0)
                {
                    arrayDivisors.Add(i);
                }
            }

            return arrayDivisors.ToArray();
        }

        [Benchmark]
        public int[] GetDivisorsWithArray()
        {
            int value = 12;

            if (!(value > 1))
                return null;

            var arrayDivisors = new int[value];
            int resize = default;

            for (int i = 2; i < value; i++)
            {
                if (value % i == 0)
                {
                    arrayDivisors[resize] = i;
                    resize++;
                }
                resize++;
            }

            Array.Resize(ref arrayDivisors, resize);
            return arrayDivisors;
        }
    }
}
