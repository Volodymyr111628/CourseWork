using System;
using Classes.Common.Printer;
using System.IO;

namespace Classes.Common.Logger
{
    public class ExceptionLogger : ILogger
    {
        public IPrinter Src { get; set; }
        public string LevelOfDetalization { get; set; }

        public ExceptionLogger()
        {
            LevelOfDetalization = ""; 
        }

        public ExceptionLogger(IPrinter src, string levelOfDetalization)
        {
            Src = src;
            LevelOfDetalization = levelOfDetalization;
        }
        

        public void WriteMessage(object value)
        {
            try
            {
                Src.Print(string.Format("{0}\n", value.ToString()));
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
