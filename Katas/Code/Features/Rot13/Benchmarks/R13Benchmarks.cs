using BenchmarkDotNet.Attributes;
using System.Text;

namespace Code.Features.Rot13.Benchmarks
{
    [MemoryDiagnoser]
    public class R13Benchmarks
    {
        [Benchmark]
        public string GenerateCipherWithForAndStringBuilder()
        {
            string input = "asdlkjoiwkjalskAs";
            var builder = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]) && char.IsUpper(input[i]))
                {
                    var difference = 'Z' - input[i];

                    if (difference < 13)
                        builder.Append((char)('A' + 12 - difference));
                    else
                        builder.Append((char)(input[i] + 13));
                }
                else if (char.IsLetter(input[i]))
                {
                    var difference = 'z' - input[i];

                    if (difference < 13)
                        builder.Append((char)('a' + 12 - difference));
                    else
                        builder.Append((char)(input[i] + 13));
                }
                else
                {
                    builder.Append(input[i]);
                }
            }
            return builder.ToString();
        }

        [Benchmark]
        public string GenerateCipherWithForAndArrayChar()
        {
            string input = "asdlkjoiwkjalskAs";
            var builder = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]) && char.IsUpper(input[i]))
                {
                    var difference = 'Z' - input[i];

                    if (difference < 13)
                        builder[i] = (char)('A' + 12 - difference);
                    else
                        builder[i] = (char)(input[i] + 13);
                }
                else if (char.IsLetter(input[i]))
                {
                    var difference = 'z' - input[i];

                    if (difference < 13)
                        builder[i] = (char)('a' + 12 - difference);
                    else
                        builder[i] = (char)(input[i] + 13);
                }
                else
                {
                    builder[i] = input[i];
                }
            }
            return string.Join(string.Empty,builder);
        }

        [Benchmark]
        public string GenerateCipherWithForeachAndStringConcat()
        {
            string message = "asdlkjoiwkjalskAs";
            string result = "";
            foreach (var s in message)
            {
                if ((s >= 'a' && s <= 'm') || (s >= 'A' && s <= 'M'))
                    result += Convert.ToChar((s + 13)).ToString();
                else if ((s >= 'n' && s <= 'z') || (s >= 'N' && s <= 'Z'))
                    result += Convert.ToChar((s - 13)).ToString();
                else result += s;
            }
            return result;
        }

        [Benchmark]
        public string GenerateCipherWithJoinAndSelect()
        {
            string message = "asdlkjoiwkjalskAs";
            return String.Join("", message.Select(x => char.IsLetter(x) ? (x >= 65 && x <= 77) || (x >= 97 && x <= 109) ? (char)(x + 13) : (char)(x - 13) : x));
        }

        [Benchmark]
        public string GenerateCipherWithMapValuesAndStringConcat()
        {
            string message = "asdlkjoiwkjalskAs";
            string r = "";
            string cap = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < message.Length; i++)
            {
                if (cap.Contains(message.Substring(i, 1)))
                {
                    r += Encrypt(message.Substring(i, 1)).ToUpper();
                }
                else
                {
                    r += Encrypt(message.Substring(i, 1));
                }
            }
            return r;
        }

        private static string Encrypt(string letter)
        {
            switch (letter.ToLower())
            {
                case "a":
                    return "n";
                case "b":
                    return "o";
                case "c":
                    return "p";
                case "d":
                    return "q";
                case "e":
                    return "r";
                case "f":
                    return "s";
                case "g":
                    return "t";
                case "h":
                    return "u";
                case "i":
                    return "v";
                case "j":
                    return "w";
                case "k":
                    return "x";
                case "l":
                    return "y";
                case "m":
                    return "z";
                case "n":
                    return "a";
                case "o":
                    return "b";
                case "p":
                    return "c";
                case "q":
                    return "d";
                case "r":
                    return "e";
                case "s":
                    return "f";
                case "t":
                    return "g";
                case "u":
                    return "h";
                case "v":
                    return "i";
                case "w":
                    return "j";
                case "x":
                    return "k";
                case "y":
                    return "l";
                case "z":
                    return "m";
                default:
                    return letter;
            }
        }
    }
}
