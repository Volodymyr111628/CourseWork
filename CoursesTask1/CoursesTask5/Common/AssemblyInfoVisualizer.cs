using Classes.Common.Printer;
using System.Reflection;

namespace CoursesTask5.Common
{
    public class AssemblyInfoVisualizer
    {
        public string AssemblyName { get; set; }

        private readonly IPrinter _consolePrinter;


        public AssemblyInfoVisualizer()
        {
            _consolePrinter = new ConsolePrinter();

            AssemblyName = "";
        }

        public AssemblyInfoVisualizer(string assemblyName)
        {
            _consolePrinter = new ConsolePrinter();

            AssemblyName = assemblyName;
        }

        public void VisualizeAssemblyInfo()
        {
            var assembly = Assembly.Load(AssemblyName);

            _consolePrinter.Print(string.Format($"{assembly.FullName} \n"));

            foreach (var item in assembly.GetModules(true))
            {
                _consolePrinter.Print(string.Format($"{item.Name} \n"));
            }

            foreach (var type in assembly.GetExportedTypes())
            {
                _consolePrinter.Print(string.Format($"{type.Name} \n"));

                foreach (var member in type.GetMembers())
                {
                    _consolePrinter.Print(string.Format($"\t {member} \n"));

                    if (member.MemberType == MemberTypes.Method)
                    {
                        foreach (ParameterInfo parInfo in ((MethodInfo)member).GetParameters())
                        {
                            _consolePrinter.Print(string.Format($"\t\t {parInfo} \n"));
                        }
                    }
                }
            }
        }

    }
}
