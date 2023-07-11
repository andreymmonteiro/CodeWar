using Code.Features.Greed.Domain;

namespace Code.Features.Greed.Application
{
    internal class Greed : IGreed
    {
        public int Score(int[] dice) => dice.GroupBy(g => g).Sum(GetScore);

        private int GetScore(IGrouping<int, int> s)
        {
            var count = s.Count();
            int result = 0;

            if(count == 3)
            {
                return Rulle(s.Key, true);
            }

            if(count < 3)
            {
                for(int i=0; i< count; i++)
                {
                    result += Rulle(s.Key, false);
                }
                return result;
            }

            for (int i = 3; i <= s.Count(); i++)
            {
                result += Rulle(s.Key, i % 3 == 0);
            }

            return result;
        }

        private int Rulle(int value, bool isThreeTimes)
            => value switch
        {
            1 => isThreeTimes ? 1000 : 100,
            2 => isThreeTimes ? 200 : 0,
            3 => isThreeTimes ? 300 : 0,
            4 => isThreeTimes ? 400 : 0,
            5 => isThreeTimes ? 500 : 50,
            6 => isThreeTimes ? 600 : 0,
            _ => 0,
        };
    }
}
