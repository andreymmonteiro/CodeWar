using Code.Features.FindDivisor.Domain;

namespace Code.Features.FindDivisor.Application
{
    internal class FindDivisor : IFindDivisor
    {
        public int[] GetDivisors(int value)
        {
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
                
            }

            Array.Resize(ref arrayDivisors, resize);

            return arrayDivisors.Length == default ? null : arrayDivisors;
        }
    }
}
