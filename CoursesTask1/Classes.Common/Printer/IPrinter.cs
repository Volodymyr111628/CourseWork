using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Common.Printer
{
    public interface IPrinter
    {
        void Print(string value);
        void Print(int value);
        void Print(object value);
        void Print(double value);
    }
}
