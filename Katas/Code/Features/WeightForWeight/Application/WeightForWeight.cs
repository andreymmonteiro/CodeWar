using Code.Features.WeightForWeight.Domain;

namespace Code.Features.WeightForWeight.Application
{
    public class WeightForWeight : IWeightForWeight
    {
        public string OrderWeight(string strng)
        {
            var numbers = strng.Split(" ");

            var numberList = numbers.OrderBy(s => s.Sum(char.GetNumericValue)).ThenBy(x => x);

            return string.Join(" ", numberList);
        }
    }
}
