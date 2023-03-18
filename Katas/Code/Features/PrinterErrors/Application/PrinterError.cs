using Code.Features.PrinterErrors.Domain;
using System.Text.RegularExpressions;

namespace Code.Features.PrinterErrors.Application
{
    internal class PrinterError : IPrinterError
    {
        public string Print(string labels)
        {
            var length = labels.Length;
            var countError = 0;

            for (int i = 0; i < length; i++)
            {
                countError += labels[i] <= 'm' ? 0 : 1;
            }

            return $"{countError.ToString()}/{length}";
        }
    }
}
