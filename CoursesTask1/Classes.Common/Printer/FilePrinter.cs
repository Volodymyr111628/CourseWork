using System;
using System.IO;

namespace Classes.Common.Printer
{
    public class FilePrinter : IPrinter
    {
        public string Path { get; set; }
        private readonly IPrinter _printer;

        public FilePrinter()
        {
            Path = "";
            _printer = new ConsolePrinter();
        }

        public FilePrinter(string path)
        {
            Path = path;
            _printer = new ConsolePrinter();
        }
        
        public void Print(string value)
        {
            WriteToFile(value);
        }

        public void Print(int value)
        {
            WriteToFile(value.ToString());
        }

        public void Print(object value)
        {
            WriteToFile(value.ToString());
        }

        public void Print(double value)
        {
            WriteToFile(value.ToString());
        }

        public void RePrint(string value)
        {
            StreamWriter sw = new StreamWriter(Path, false);

            try
            {
                if (!File.Exists(Path))
                {
                    File.Create(Path);
                }
                sw.WriteLine(string.Format("\n{0}\n", value));
            }
            catch (IOException ex)
            {
                _printer.Print(ex.Message);
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format("Exception occured:{0}\n", ex.Message));
                throw;
            }
            finally
            {
                sw.Close();
            }
        }

        private void WriteToFile(string value)
        {
            StreamWriter sw = new StreamWriter(Path, true);

            try
            {
                if(!File.Exists(Path))
                {
                    File.Create(Path);
                }
                sw.WriteLine(string.Format("{0} \n", value));
            }
            catch (IOException ex)
            {
                _printer.Print(ex.Message);
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format("Exception occured:{0} \n", ex.Message));
                throw;
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
