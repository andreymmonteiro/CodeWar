using Code.Features.RegexValidadePIN.Domain;

namespace Code.Features.RegexValidadePIN.Application
{
    internal class ValidatePIN : IValidatePIN
    {
        public bool IsValidPIN(string pin)
        {
            if (pin.Length == 4 || pin.Length == 6)
                return !pin.Any(a => !int.TryParse(a.ToString(), out var value));
            return false;
        }
    }
}
