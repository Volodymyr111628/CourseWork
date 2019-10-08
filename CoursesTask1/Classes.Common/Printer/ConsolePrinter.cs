﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Common.Printer
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string value)
        {
            Console.Write(value);
        }

        public void Print(int value)
        {
            Console.Write(value);
        }

        public void Print(object value)
        {
            Console.Write(value);
        }

        public void Print(double value)
        {
            Console.Write(value);
        }
    }
}
