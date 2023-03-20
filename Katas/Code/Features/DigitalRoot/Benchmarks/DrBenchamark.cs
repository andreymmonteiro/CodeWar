using BenchmarkDotNet.Attributes;

namespace Code.Features.DigitalRoot.Benchmarks
{
    [MemoryDiagnoser]
    public class DrBenchamark
    {
        private long _result;


        [Benchmark]
        public int GetSumOfDigitsWithoutParseStringWithoutArray()
        {
            SumNumbers(493193);

            int digital = Convert.ToInt32(_result);

            return digital;
        }

        [Benchmark]
        public int GetSumOfDigitsWithoutParseStringWithoutArrayWithCast()
        {
            SumNumbersWithCast(493193);

            int digital = Convert.ToInt32(_result);

            return digital;
        }

        [Benchmark]
        public int GetSumOfDigitsWithoutParseStringWithoutArrayAndDivisionOperation()
        {
            SumNumbersWithCastWithDivisionPeration(493193);

            int digital = Convert.ToInt32(_result);

            return digital;
        }

        [Benchmark]
        public int GetSumOfDigitsUsingArrayWithoutParsingString()
        {
            long n = 493193;

            long[] arrayDigits = GetArrayDigits(n);
            long digitalRoot = SumArray(arrayDigits);

            while (digitalRoot >= 10)
            {
                digitalRoot = SumArray(GetArrayDigits(digitalRoot));
            }
            int digital = Convert.ToInt32(digitalRoot);

            return digital;
        }

        [Benchmark]
        public int GetSumOfDigitsWithParseString()
            => SumDigits(493193);

        private void SumNumbers(long n)
        {
            _result = default;
            while (n != 0)
            {
                _result += n % 10;
                n = n / 10;
            }

            if (_result >= 10)
                SumNumbers(_result);
        }

        private void SumNumbersWithCast(long n)
        {
            _result = default;
            while (n != 0)
            {
                _result += n % 10;
                n = n / 10;
            }

            if (((decimal)_result) >= 10)
                SumNumbers(_result);
        }

        private void SumNumbersWithCastWithDivisionPeration(long n)
        {
            _result = default;
            while (n != 0)
            {
                _result += n % 10;
                n = n / 10;
            }

            if (((decimal)_result) / 10 > 1)
                SumNumbers(_result);
        }

        private int SumDigits(long n)
        {
            _result = default;

            var nString = n.ToString();

            for (int i = 0; i < nString.Length; i++)
                _result += Convert.ToInt32(nString[i].ToString());

            if (_result.ToString().Length > 1)
                SumDigits(_result);

            return Convert.ToInt32(_result);
        }


        private long[] GetArrayDigits(long n)
        {
            long[] digits = new long[19];
            int amount = 0;
            while (n != 0)
            {
                digits[amount++] = n % 10;
                n = n / 10;
            }
            Array.Resize(ref digits, amount);

            return digits;
        }

        private long SumArray(long[] array)
        {
            long sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

    }
}
