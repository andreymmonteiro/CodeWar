// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Code.Features.CreditCard.Application;
using Code.Features.CreditCard.Domain;
using Code.Features.PlayingWithDigits.Application;
using Code.Features.PlayingWithDigits.Benchmarks;
using Code.Features.PlayingWithDigits.Domain;
using Code.Features.RegexValidadePIN.Application;
using Code.Features.RegexValidadePIN.Domain;
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

Console.WriteLine("K Value is " + playingWithDigits.KValue(41, 5)); //1025
Console.WriteLine("K Value is " + playingWithDigits.KValue(114, 3)); //1026
Console.WriteLine("K Value is " + playingWithDigits.KValue(8, 3)); //512


//BenchmarkRunner.Run<PwdBenchamark>();

#endregion

#region Validate PIN 

IValidatePIN validate = new ValidatePIN();

Console.WriteLine("Should be true: " + validate.IsValidPIN("1234"));
Console.WriteLine("Should be false: " + validate.IsValidPIN(".234"));
Console.WriteLine("Should be false: " + validate.IsValidPIN("12345"));
Console.WriteLine("Should be false: " + validate.IsValidPIN("as45"));
Console.WriteLine("Should be true: " + validate.IsValidPIN("123476"));

#endregion

