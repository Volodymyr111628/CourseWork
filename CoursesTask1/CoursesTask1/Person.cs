using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Common.Printer;

namespace CoursesTask1
{
    struct Person
    {
        public int age;
        public string name;
        public string surname;
        private readonly IPrinter _printer;

        public Person(int _age, string _name, string _surname)
        {
            age = _age;
            name = _name;
            surname = _surname;
            _printer = new ConsolePrinter();
        }

        public void ReturnString(int n)
        {
            if (n < age)
            {
                _printer.Print(string.Format("{0} {1} older than {2}", name, surname, n));
            }
            else if (n > age)
            {
                _printer.Print(string.Format("{0} {1} younger than {2}", name, surname, n));
            }
            else
            {
                _printer.Print(string.Format("{0} {1} is {2}", name, surname, n));
            }
        }
    }
}
