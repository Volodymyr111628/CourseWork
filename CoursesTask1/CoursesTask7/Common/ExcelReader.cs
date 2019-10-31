using System;
using System.Text;
using Classes.Common.Reader;
using Classes.Common.Printer;
using Classes.Common.Logger;
using System.IO;
using ExcelDataReader;
using System.Data;

namespace CoursesTask7.Common
{
    public class ExcelReader : IFileReader
    {
        private readonly ILogger<ExcelReader> _logger;
        private readonly IPrinter _printer;

        public ExcelReader(ILogger<ExcelReader> logger, IPrinter printer)
        {
            _logger = logger;
            _printer = printer;
        }

        public string Read(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            FileInfo _file = new FileInfo(path);

            FileStream stream = File.Open(_file.FullName, FileMode.Open, FileAccess.Read);

            StringBuilder data = new StringBuilder();

            try
            {
                IExcelDataReader excelReader;

                if (_file.Extension == ".xls")
                {
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                else if (_file.Extension == ".xlsx")
                {
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }
                else throw new Exception("Unknown format!");

                DataSet result = excelReader.AsDataSet();

                excelReader.Close();

                foreach (DataTable sheet in result.Tables)
                {
                    for (int j = 0; j < sheet.Columns.Count; j++)
                    {
                        for (int i = 0; i < sheet.Rows.Count; i++)
                        {
                            data.Append(sheet.Rows[i].ItemArray[j].ToString() + "|");
                        }
                    }
                }

                return data.ToString();
            }
            catch(IOException ex)
            {
                _logger.WriteMessage(ex.Message, LevelOfDetalization.Error);
                _printer.Print($"Exception occured {ex.Message}");
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                stream.Close();
            }
            return data.ToString();
        }
    }
}
