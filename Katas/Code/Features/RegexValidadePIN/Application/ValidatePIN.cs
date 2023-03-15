using Code.Features.RegexValidadePIN.Domain;

namespace Code.Features.RegexValidadePIN.Application
{
    internal class ValidatePIN : IValidatePIN
    {
        public bool IsValidPIN(string pin)
            => (pin.Length == 4 || pin.Length == 6) && pin.All(Char.IsDigit);
    }
}
