namespace Code.Features.RegexValidadePIN.Domain
{
    internal interface IValidatePIN
    {
        bool IsValidPIN(string pin);
    }
}
