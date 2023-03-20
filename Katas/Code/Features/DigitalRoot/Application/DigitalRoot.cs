using Code.Features.DigitalRoot.Domain;

namespace Code.Features.DigitalRoot.Application
{
    internal class DigitalRoot : IDigitalRoot
    {
        private long _result;

        public int GetSumOfDigits(long n)
            => SumDigits(n);

        public int SumDigits(long n)
        {
            SumNumbers(n);

            int digital = Convert.ToInt32(_result);

            return digital;
        }

        private void SumNumbers(long n)
        {
            _result = default;
            while (n != 0)
            {
                _result += n % 10;
                n = n / 10;
            }

            if(_result >= 10)
                SumNumbers(_result);
        }
    }
}
