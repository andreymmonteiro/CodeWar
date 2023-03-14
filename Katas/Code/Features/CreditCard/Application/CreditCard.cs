using Code.Features.CreditCard.Domain;

namespace Code.Features.CreditCard.Application
{
    internal record class CreditCard : ICreditCard
    {
        public string CreateMask(string cardNumber)
        {
            var length = cardNumber.Length;

            if(length < 4)
                return cardNumber;

            return cardNumber.Substring(length - 4).PadLeft(length - 4, '#');
        }
    }
}
