using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Common.Printer;

namespace CoursesTask1
{
    enum Months { January, February, March, April, May, June, July, August, September, October, November, December };
    public enum Colors { Green = 12, Red = 123, Purple = 9, Blue = 233, Yellow = 20 };
    enum LongRange : long { Max = long.MaxValue, Min = long.MinValue };

    class Program
    {

        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>()
            {
                new Person(20,"Volodymyr","Kuhivchak"),
                new Person(25,"Ivan","Perk"),
                new Person(19,"Arsen","Del"),
                new Person(31,"Max","Jo"),
                new Person(15,"Peter","Jobs")
            };

            foreach (Person person in persons)
            {
                Console.WriteLine("{0}", person.ReturnString(20));
            }

            List<Rectangle> rectangles = new List<Rectangle>()
            {
                new Rectangle(0,0,20,15),
                new Rectangle(0,0,10,25),
                new Rectangle(0,0,882.1,123.21),
                new Rectangle(0,0,20.232,283.123),
                new Rectangle(0,0,40.2332,15.231)
            };

            foreach (Rectangle rectangle in rectangles)
            {
                Console.WriteLine("Perimeter: {0}", rectangle.Perimeter());
            } 

            int n = Convert.ToInt32(Console.ReadLine());
            if (n < 0 || n >= 12)
                Console.WriteLine("Invalid argument");
            else
                Console.WriteLine(Enum.GetName(typeof(Months), n));

            foreach (long value in Enum.GetValues(typeof(LongRange)))
            {
                Console.WriteLine(value);
            }

            Colors.Blue.Sort();
        }

    }

    public static class Extensions
    {
        public static void Sort(this Colors color)
        {
            var enumValues = Enum.GetValues(typeof(Colors));
            Array.Sort(enumValues);
            foreach (var item in enumValues)
            {
                Console.WriteLine("{0}, {1}", (int)item, item.ToString());
            }
        }
    }
}
