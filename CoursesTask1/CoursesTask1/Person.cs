using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesTask1
{
    struct Person
    {
        public int age;
        public string name;
        public string surname;

        public Person(int _age, string _name, string _surname)
        {
            age = _age;
            name = _name;
            surname = _surname;
        }

        public string ReturnString(int n)
        {
            if (n < age)
            {
                return string.Format("{0} {1} older than {2} \n", name, surname, n);
            }
            else if (n > age)
            {
                return string.Format("{0} {1} younger than {2} \n", name, surname, n);
            }
            else
            {
                return string.Format("{0} {1} is {2} \n", name, surname, n);
            }
        }
    }
}
