using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Common.Printer;
using System.IO;

namespace Classes.Common.Logger
{
    public class ExceptionLogger : ILogger
    {
        private readonly IPrinter _filePrinter;
        private readonly IPrinter _printer;
        
        public ExceptionLogger()
        {
            _filePrinter = new FilePrinter();
            _printer = new ConsolePrinter();
        }

        public ExceptionLogger(string path)
        {
            _filePrinter = new FilePrinter(path);
            _printer = new ConsolePrinter();
        }

        public void Log(object value)
        {
            try
            {
                _filePrinter.Print(string.Format("{0}\n",((Exception)value).ToString()));
            }
            catch(IOException ex)
            {
                _printer.Print(string.Format("Exception occured: {0}\n",ex.Message));
            }
            catch(Exception ex)
            {
                _printer.Print(string.Format("Exception occured: {0}\n", ex.Message));
                throw;
            }
        }
    }
}
