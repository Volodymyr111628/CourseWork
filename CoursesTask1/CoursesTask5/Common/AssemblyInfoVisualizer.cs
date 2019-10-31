using Classes.Common.Printer;
using System.Reflection;
using Classes.Common.Logger;

namespace CoursesTask5.Common
{
    public class AssemblyInfoVisualizer
    {
        
        private readonly IPrinter _printer;

        private readonly ILogger<AssemblyInfoVisualizer> _logger;

        public AssemblyInfoVisualizer(string assemblyName,IPrinter printer,ILogger<AssemblyInfoVisualizer> logger)
        {
            _printer = printer;
            _logger = logger;
            AssemblyName = assemblyName;
        }

        public string AssemblyName { get; set; }

        public void VisualizeAssemblyInfo()
        {
            var assembly = Assembly.Load(AssemblyName);

            _printer.Print(string.Format($"{assembly.FullName} \n"));

            foreach (var item in assembly.GetModules(true))
            {
                _printer.Print(string.Format($"{item.Name} \n"));
            }

            foreach (var type in assembly.GetExportedTypes())
            {
                _printer.Print(string.Format($"{type.Name} \n"));

                foreach (var member in type.GetMembers())
                {
                    _printer.Print(string.Format($"\t {member} \n"));

                    if (member.MemberType == MemberTypes.Method)
                    {
                        foreach (var parInfo in ((MethodInfo)member).GetParameters())
                        {
                            _printer.Print(string.Format($"\t\t {parInfo} \n"));
                        }
                    }
                }
            }
        }

    }
}
