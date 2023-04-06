using Code.Features.DirectionsReduction.Domain;

namespace Code.Features.DirectionsReduction.Application
{
    internal class DirectionsReduction : IDirectionsReduction
    {
        private readonly Dictionary<string, string> opposites = new Dictionary<string, string>()
        {
            {"NORTH", "SOUTH"},
            {"SOUTH", "NORTH"},
            {"EAST", "WEST"},
            {"WEST", "EAST"}
        };

        public string[] Reducer(string[] args)
        {
            var argsList = args.ToList();

            for (int i = 0; i < argsList.Count; i++)
            {

                if (i + 1 >= argsList.Count) 
                {
                    break;
                }

                if (IsOpposite(argsList.ElementAt(i), argsList.ElementAt(i + 1)))
                {
                    argsList.RemoveAt(i);
                    argsList.RemoveAt(i);

                    while(i > default(int) && argsList.Count > i)
                    {
                        if ((argsList.Count > 1) &&
                            IsOpposite(argsList.ElementAt(i), argsList.ElementAt(i - 1)))
                        {
                            argsList.RemoveAt(i);
                            argsList.RemoveAt(i - 1);
                            i--;
                            continue;
                        }
                        break;
                    }
                    i--;
                }

            }

            return argsList.ToArray();
        }

        private bool IsOpposite(string actual, string condition)
            => (opposites.TryGetValue(actual, out var actualResult) && actualResult == condition) ||
                (opposites.TryGetValue(condition, out var conditionResult) && conditionResult == actual);
    }
}
