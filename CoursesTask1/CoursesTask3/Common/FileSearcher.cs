using Classes.Common.Printer;
using Classes.Common.Logger;
using System.IO;

namespace CoursesTask3.Common
{
    public class FileSearcher
    {
        private readonly IPrinter _printer;

        private readonly ILogger<FileSearcher> _logger;

        public FileSearcher(ILogger<FileSearcher> logger, IPrinter printer)
        {
            _printer = printer;
            _logger = logger;
        }

        public void FindTxtFileByPartialName(string path, string fileName)
        {
            var info = new DirectoryInfo(path);

            var files = info.GetFiles();

            foreach (var file in files)
            {
                if (Path.GetExtension(file.FullName) == ".txt" && file.Name.Contains(fileName))
                {
                    _printer.Print(string.Format($"{file.FullName} \n"));
                }
            }

            foreach (var item in info.GetDirectories())
            {
                FindTxtFileByPartialName(item.FullName, fileName);
            }
        }
    }
}
