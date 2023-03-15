// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Code.Features.CreditCard.Application;
using Code.Features.CreditCard.Domain;
using Code.Features.PlayingWithDigits.Application;
using Code.Features.PlayingWithDigits.Benchmarks;
using Code.Features.PlayingWithDigits.Domain;
using System.Runtime.InteropServices;

#region Credit Card Number

ICreditCard creditCard = new CreditCard();

Console.WriteLine(creditCard.CreateMask("1234 4565 8899"));

#endregion


#region Playing with digits

IPlayingWithDigits playingWithDigits = new PlayingWithDigits();

Console.WriteLine("K Value is " + playingWithDigits.KValue(89, 1));
Console.WriteLine("K Value is " + playingWithDigits.KValue(92, 1));
Console.WriteLine("K Value is " + playingWithDigits.KValue(46288, 3));

#endregion
