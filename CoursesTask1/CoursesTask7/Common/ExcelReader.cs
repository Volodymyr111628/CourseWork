using System;
using System.Text;
using Classes.Common.Reader;
using Classes.Common.Printer;
using Classes.Common.Logger;
using System.IO;
using ExcelDataReader;
using System.Data;
using System.Configuration;

namespace CoursesTask7.Common
{
    public class ExcelReader : IFileReader
    {
        private readonly ILogger<ExcelReader> _logger;
        private readonly IPrinter _printer;
        public string Path { get; set; }

        public ExcelReader(ILogger<ExcelReader> logger, IPrinter printer,string path)
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

            FileInfo _file = new FileInfo(Path);

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
                    int cols = Math.Max(Math.Min(
                        Convert.ToInt32(ConfigurationManager.AppSettings["Columns"].ToString()),
                        sheet.Columns.Count), 0);

                    int rows = Math.Max(Math.Min(
                        Convert.ToInt32(ConfigurationManager.AppSettings["Rows"].ToString()),
                        sheet.Rows.Count), 0);

                    for (int j = 0; j < sheet.Columns.Count; j++)
                    {
                        for (int i = 0; i < sheet.Rows.Count; i++)
                        {
                            data.Append(sheet.Rows[i].ItemArray[j].ToString());
                            data.Append("|");
                        }
                    }
                }

                return data.ToString();
            }
            catch (IOException ex)
            {
                _logger.WriteMessage(ex.Message, LevelOfDetalization.Error);
                _printer.Print($"Exception occured {ex.Message}");
            }
            catch (Exception)
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
