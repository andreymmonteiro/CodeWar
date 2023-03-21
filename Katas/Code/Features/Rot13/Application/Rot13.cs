using Code.Features.Rot13.Domain;
using System.Text;

namespace Code.Features.Rot13.Application
{
    internal class Rot13 : IRot13
    {
        public string GenerateCipher(string input)
        {
            var builder =  new StringBuilder();

            for(int i =0; i < input.Length; i++)
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
    }
}
