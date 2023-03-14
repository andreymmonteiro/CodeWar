namespace Code.Features.CreditCard.Domain
{
    internal interface ICreditCard
    {
        string CreateMask(string cardNumber);
    }
}
