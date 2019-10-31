using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Common.Logger;
using Classes.Common.Printer;
using System.IO;

namespace Classes.Common.Reader
{
    public class FileReader : IFileReader
    {
        private readonly ILogger<FileReader> _logger;
        private readonly IPrinter _printer;
        public string Path { get; set; }

        public FileReader(ILogger<FileReader> logger, IPrinter printer,string path)
        {
            _logger = logger;
            _printer = printer;
            Path = path;
        }
        
        public string Read()
        {
            if (!File.Exists(Path))
            {
                throw new FileNotFoundException();
            }

            var streamReader = new StreamReader(Path);

            string data = string.Empty;

            try
            {
                data = streamReader.ReadToEnd();
            }
            catch(IOException ex)
            {
                _printer.Print(string.Format($"Exception occured: {ex.Message}"));
                _logger.WriteMessage(ex.ToString(), LevelOfDetalization.Error);
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format($"Exception occured: {ex.Message}"));
                throw;
            }
            return data;
        }

        public string ReadLine()
        {
            throw new NotImplementedException();
        }
    }
}
