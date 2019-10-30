using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Common.Logger;
using Classes.Common.Printer;
using Classes.Common.Runner;
using System.Configuration;
using System.IO;
using ExcelDataReader;
using System.Data;
using System.Diagnostics;

namespace CoursesTask7.Tasks
{
    public class Task1 : IRunnable
    {
        private readonly IPrinter _printer = new ConsolePrinter();
        private readonly ILogger _logger = new ExceptionLogger(
            new FilePrinter(ConfigurationManager.AppSettings["FileToWrite"].ToString()),
            ConfigurationManager.AppSettings["LevelOfDetalization"].ToString());

        public void Run()
        {
            Stopwatch sw_total = new Stopwatch();
            sw_total.Start();

            FileInfo _file = new FileInfo("Text.xlsx");
            FileStream stream = File.Open(_file.FullName, FileMode.Open, FileAccess.Read);
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

            DataTable table1 = result.Tables[0];
            DataTable table2 = result.Tables[1];

            excelReader.Close();

            Dictionary<string, int> items = new Dictionary<string, int>();
            for (int j = 0; j < table1.Columns.Count; j++)
            {
                for (int i = 0; i < table1.Rows.Count; i++)
                {
                    string key = table1.Rows[i].ItemArray[j].ToString();
                    if (items.ContainsKey(table1.Rows[i].ItemArray[j].ToString()))
                    {
                        items[key] += 1;
                    }
                    else
                    {
                        items[key] = 1;
                    }
                }
            }
            for (int j = 0; j < table2.Columns.Count; j++)
            {
                for (int i = 0; i < table2.Rows.Count; i++)
                {
                    string key = table1.Rows[i].ItemArray[j].ToString();
                    if (items.ContainsKey(table1.Rows[i].ItemArray[j].ToString()))
                    {
                        items[key] += 1;
                    }
                    else
                    {
                        items[key] = 1;
                    }
                }
            }
            sw_total.Stop();
            _printer.Print("Reading: " + sw_total.ElapsedMilliseconds + " ms \n");
            
            _printer.Print(string.Format($"Unique items: \n"));
            foreach(var item in items)
            {
                if(item.Value==1)
                {
                    _printer.Print(string.Format($"{item.Key}\n"));
                }
            }

        }
    }
}
