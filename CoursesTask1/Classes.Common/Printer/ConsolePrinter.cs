using System;

namespace Classes.Common.Printer
{
    public class ConsolePrinter : IPrinter,ILogPrinter
    {
        public void Print(string value)
        {
            Console.Write(value);
        }
    }
}
