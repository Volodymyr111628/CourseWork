using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CoursesTask5
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.Load(@"Classes.Common");

            Console.WriteLine(assembly.FullName);

            foreach (var item in assembly.GetModules(true))
            {
                Console.WriteLine(item.Name);
            }

            foreach (var type in assembly.GetExportedTypes())
            {
                Console.WriteLine(type.Name);

                foreach (var member in type.GetMembers())
                {
                    Console.WriteLine("\t {0}",member);

                    if (member.MemberType == MemberTypes.Method)
                    {
                        foreach (ParameterInfo parInfo in ((MethodInfo)member).GetParameters())
                        {
                            Console.WriteLine("\t\t {0}",parInfo);
                        }
                    }
                }
            }
        }
    }
}
