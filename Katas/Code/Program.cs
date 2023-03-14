// See https://aka.ms/new-console-template for more information


#region Credit Card Number

using Code.Features.CreditCard.Application;
using Code.Features.CreditCard.Domain;

ICreditCard creditCard = new CreditCard();

Console.WriteLine(creditCard.CreateMask("1234 4565 8899"));

#endregion
