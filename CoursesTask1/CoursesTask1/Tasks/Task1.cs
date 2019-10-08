using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Common.Runner;
using Classes.Common.Printer;

namespace CoursesTask1.Tasks
{
    public class Task1 : IRunnable
    {
        private readonly IPrinter _printer;

        public Task1()
        {
            _printer = new ConsolePrinter();
        }

        public void Run()
        {
            List<Person> persons = new List<Person>()
            {
                new Person(20,"Volodymyr","Kuhivchak"),
                new Person(25,"Ivan","Perk"),
                new Person(19,"Arsen","Del"),
                new Person(31,"Max","Jo"),
                new Person(15,"Peter","Jobs")
            };

            _printer.Print("Task1\n");

            foreach (Person person in persons)
            {
                _printer.Print(string.Format("{0}", person.ReturnString(20)));
            }
        }
    }
}
