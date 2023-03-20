// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Code.Features.CreditCard.Application;
using Code.Features.CreditCard.Domain;
using Code.Features.DigitalRoot.Application;
using Code.Features.DigitalRoot.Benchmarks;
using Code.Features.DigitalRoot.Domain;
using Code.Features.PlayingWithDigits.Application;
using Code.Features.PlayingWithDigits.Benchmarks;
using Code.Features.PlayingWithDigits.Domain;
using Code.Features.PrinterErrors.Application;
using Code.Features.PrinterErrors.Benchmarks;
using Code.Features.PrinterErrors.Domain;
using Code.Features.RegexValidadePIN.Application;
using Code.Features.RegexValidadePIN.Domain;
using Code.Features.SplitStrings.Application;
using Code.Features.SplitStrings.Domain;
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

#region Printer Errors

IPrinterError printer = new PrinterError();

Console.WriteLine(printer.Print("aaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyz"));
Console.WriteLine(printer.Print("aaabbbbhaijjjm"));
Console.WriteLine(printer.Print("aaaxbbbbyyhwawiwjjjwwm"));

//BenchmarkRunner.Run<PeBenchmarks>();

#endregion

#region Split Strings

ISplitString splitString = new SplitString();

var splitStringValues = string.Join(' ',splitString.SplitInTwoCharacteres("abc"));
var splitStringValuesSecondTest = string.Join(' ', splitString.SplitInTwoCharacteres("abcdef"));

Console.WriteLine(splitStringValues);
Console.WriteLine(splitStringValuesSecondTest);

#endregion

#region Digital Root
IDigitalRoot digitalRoot = new DigitalRoot();

Console.WriteLine(digitalRoot.GetSumOfDigits(493193));
Console.WriteLine(digitalRoot.GetSumOfDigits(86167));

//BenchmarkRunner.Run<DrBenchamark>();
#endregion
