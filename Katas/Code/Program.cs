// See https://aka.ms/new-console-template for more information

using Code.Features.AddingBigNumbers.Application;
using Code.Features.AddingBigNumbers.Domain;
using Code.Features.CreditCard.Application;
using Code.Features.CreditCard.Domain;
using Code.Features.DigitalRoot.Application;
using Code.Features.DigitalRoot.Domain;
using Code.Features.FindDivisor.Application;
using Code.Features.FindDivisor.Domain;
using Code.Features.MostFrequentlyUsedWords.Application;
using Code.Features.MostFrequentlyUsedWords.Domain;
using Code.Features.MovingZerosToEnd.Application;
using Code.Features.MovingZerosToEnd.Domain;
using Code.Features.PlayingWithDigits.Application;
using Code.Features.PlayingWithDigits.Domain;
using Code.Features.PrinterErrors.Application;
using Code.Features.PrinterErrors.Domain;
using Code.Features.RegexValidadePIN.Application;
using Code.Features.RegexValidadePIN.Domain;
using Code.Features.Rot13.Application;
using Code.Features.Rot13.Domain;
using Code.Features.SplitStrings.Application;
using Code.Features.SplitStrings.Domain;
using Code.Features.WeightForWeight.Application;
using Code.Features.WeightForWeight.Domain;
using Code.Features.YourOrderPlease.Application;
using Code.Features.YourOrderPlease.Domain;
using NUnit.Framework;

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

#region Find Divisor

IFindDivisor divisorFinder = new FindDivisor();

var resultDivisors = divisorFinder.GetDivisors(12);

//BenchmarkRunner.Run<FdBenchmark>();

Console.WriteLine(String.Join(", ",resultDivisors.Select(s => s.ToString())));

#endregion

#region Your Order Please

IYourOrderPlease yourOrderPlease = new YourOrderPlease();
yourOrderPlease.SortString("is2 Thi1s T4est 3a");

//BenchmarkRunner.Run<YopBenchmarks>();

#endregion

#region Moving zeros to end

IMovingZerosToEnd movingZerosToEnd = new MovingZerosToEnd();

movingZerosToEnd.Ordernate(new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 });

#endregion

#region Rot13

IRot13 rot13 = new Rot13();
//BenchmarkRunner.Run<R13Benchmarks>();

//rot13.GenerateCipher("test");


#endregion

#region Weight For Weight
IWeightForWeight weightForWeight = new WeightForWeight();

Console.WriteLine($"Weight ordenated: {weightForWeight.OrderWeight("103 123 4444 99 2000")}");

Console.WriteLine($"Weight ordenated: {weightForWeight.OrderWeight("496636983114762 59544965313 85246814996697 3 16 9 38 95 11312...")}");

Console.WriteLine($"Weight ordenated: {weightForWeight.OrderWeight("103 123 4444 99 2000")}");


#endregion

#region Adding Big Numbers
IAddingBigNumbers addingBigNumbers = new AddingBigNumbers();

Console.WriteLine($"Sum of big numbers: {addingBigNumbers.Add("321321321564654", "7897897898794")}");

#endregion


#region Most Frequently used words
IMostFrequentlyUsedWords mostFrequentlyUsedWords = new MostFrequentlyUsedWords();

Console.WriteLine($@"The most frequently used words are: {string.Join(", ", mostFrequentlyUsedWords.Top3(string.Join("\n", new string[]{"In a village of La Mancha, the name of which I have no desire to call to",
                  "mind, there lived not long since one of those gentlemen that keep a lance",
                  "in the lance-rack, an old buckler, a lean hack, and a greyhound for",
                  "coursing. An olla of rather more beef than mutton, a salad on most",
                  "nights, scraps on Saturdays, lentils on Fridays, and a pigeon or so extra",
                  "on Sundays, made away with three-quarters of his income." })))}");

#endregion