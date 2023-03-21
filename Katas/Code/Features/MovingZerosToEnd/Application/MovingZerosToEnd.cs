using Code.Features.MovingZerosToEnd.Domain;

namespace Code.Features.MovingZerosToEnd.Application
{
    internal class MovingZerosToEnd : IMovingZerosToEnd
    {
        public int[] Ordernate(int[] value)
            => value.OrderBy(o => o< 1).ToArray();
    }
}
