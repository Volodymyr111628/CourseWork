using System;
using Classes.Common.Printer;
using System.IO;

namespace Classes.Common.Logger
{
    public class ExceptionLogger<T> : ILogger<T>
    {
        private readonly string className;
        private ILogPrinter Src;

        public ExceptionLogger(IPrinter src, ILogPrinter logPrinter)
        {
            Src = logPrinter;
            className = typeof(T).FullName;
        }

        public void WriteMessage(object message, LevelOfDetalization levelOfDetalization = LevelOfDetalization.Error)
        {
            try
            {
                Src.Print(string.Format("{0} | {1} | {2} - {3} \n", levelOfDetalization, DateTime.Now, message, className));
            }
            catch (IOException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
