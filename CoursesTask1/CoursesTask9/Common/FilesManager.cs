using System.IO;
using System.Text;
using Classes.Common.Logger;
using Classes.Common.Printer;

namespace CoursesTask9.Common
{
    public class FilesManager
    {
        private readonly ILogger<FilesManager> _Logger;
        private readonly IPrinter _printer;

        public FilesManager(ILogger<FilesManager> logger, IPrinter printer)
        {
            _Logger = logger;
            _printer = printer;
        }

        public StringBuilder Manage(string Path, StringBuilder fileNames = null)
        {
            if (fileNames == null)
            {
                fileNames = new StringBuilder();
            }

            var info = new DirectoryInfo(Path);

            var files = info.GetFiles();

            foreach (var file in files)
            {
                fileNames.Append(file);
                fileNames.Append("|");
            }

            foreach (var item in info.GetDirectories())
            {
                Manage(item.FullName, fileNames);
            }

            return fileNames;
        }
    }
}
