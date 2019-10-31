using System.Collections.Generic;
using Classes.Common.Runner;
using Classes.Common.Printer;
using CoursesTask1.Common;

namespace CoursesTask1.Tasks
{
    public class Task1 : IRunnable
    {
        private readonly IPrinter _printer;

        public Task1(IPrinter printer=null)
        {
            _printer = printer ?? new ConsolePrinter();
        }

        public void Run()
        {

            var persons = new List<Person>()
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
