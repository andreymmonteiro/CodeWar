using BenchmarkDotNet.Attributes;
using System.Text;

namespace Code.Features.YourOrderPlease.Benchmarks
{
    [MemoryDiagnoser]
    public class YopBenchmarks
    {
        private StringBuilder _result;

        [Benchmark]
        public string SortString()
        {
            _result = new StringBuilder();
            string value = "is2 Thi1s T4est 3a";

            var valueSplited = value.Split(" ");
            for (int i = 0; i < value.Length; i++)
                GetCorrectOrderWord(valueSplited, i);

            return _result.ToString().TrimStart().TrimEnd();
        }

        private void GetCorrectOrderWord(string[] value, int index)
            => _result.Append($"{value.OrderBy(f => f.FirstOrDefault(char.IsDigit))} ");

        [Benchmark]
        public string SortStringUsingJoin()
        {
            string value = "is2 Thi1s T4est 3a";

            return string.Join(" ", value.Split().OrderBy(w => w.FirstOrDefault(char.IsDigit)));
        }
    }
}
