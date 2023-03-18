using BenchmarkDotNet.Attributes;
using System.Text.RegularExpressions;

namespace Code.Features.PrinterErrors.Benchmarks
{
    [MemoryDiagnoser]
    public class PeBenchmarks
    {
        [Benchmark]
        public string PrinterErrorsWithWhere()
        {
            var labels = "aaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyz";
            return labels.Where(w => !(w <= 'm')).Count().ToString();
        }

        [Benchmark]
        public string PrinterErrorsWithFor()
        {
            var labels = "aaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyz";

            var length = labels.Length;
            var countError = 0;
            
            for(int i =0; i < length; i++)
            {
                countError += labels[i] <= 'm' ? 0 : 1;
            }
            return countError.ToString();
        }

        [Benchmark]
        public string PrinterErrorsWithRegex()
        {
            var s = "aaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyz";
            const string pattern = @"[^a-m]";

            return $"{Regex.Matches(s, pattern).Count}/{s.Length}";
        }
        

    }
}
