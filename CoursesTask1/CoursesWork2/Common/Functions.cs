using System;
using Classes.Common.Printer;

namespace CoursesTask2.Common
{
    public static class Functions
    {
        private static readonly IPrinter _printer = new ConsolePrinter();

        public static void RecursiveFunction(int n)
        {
            RecursiveFunction(n + 1);
        }

        public static void Iteration()
        {
            int[] array = new int[10];

            try
            {
                for (int i = 0; i < 20; i++)
                {
                    array[i] = 5;
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                _printer.Print(string.Format("{0}\n", ex.Message));
            }
        }

        public static void DoSomeMath(int a, int b)
        {
            if (a < 0)
            {
                throw new ArgumentException("Bad argument", "a");
            }
            if (b > 0)
            {
                throw new ArgumentException("Bad argument", "b");
            }
        }
    }
}
