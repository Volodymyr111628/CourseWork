using System;
using System.Collections.Generic;
using System.Text;
using Classes.Common.Logger;
using Classes.Common.Printer;
using Classes.Common.Runner;
using CoursesTask9.Common;
using System.Configuration;
using System.IO;

namespace CoursesTask9.Tasks
{
    public class Task1 : IRunnable
    {
        private readonly IPrinter _printer;
        private readonly ILogger<Task1> _logger;
        private FilesManager _filesManager;

        public Task1(ILogger<Task1> logger, IPrinter printer, FilesManager filesManager)
        {
            _printer = printer;
            _logger = logger;
            _filesManager = filesManager;
        }

        public void Run()
        {
            var fileNames = new StringBuilder();

            try
            {
                fileNames.Append(_filesManager.Manage(ConfigurationManager.AppSettings["SourceFile1"].ToString()));

                fileNames.Append(_filesManager.Manage(ConfigurationManager.AppSettings["SourceFile2"].ToString()));
            }
            catch (FileNotFoundException ex)
            {
                _printer.Print($"Exception occured: {ex.Message}");
                _logger.WriteMessage(ex.ToString(), LevelOfDetalization.Error);
            }
            catch (Exception ex)
            {
                _printer.Print($"Exception occured: {ex.Message}");
                _logger.WriteMessage(ex.ToString(), LevelOfDetalization.Error);
            }

            var values = fileNames.ToString().Split('|');

            var dictionary = new Dictionary<string, int>();

            int countOfDuplicates = 0;

            foreach (var item in values)
            {
                if (dictionary.ContainsKey(item))
                {
                    dictionary[item]++;
                }
                else
                {
                    dictionary.Add(item, 1);
                }
            }

            _printer.Print("UNIQUE VALUES:\n");

            foreach (var item in dictionary)
            {
                if (item.Value == 1)
                {
                    _printer.Print($"\t{item.Key}\n");
                }
            }

            _printer.Print("DUPLICATE VALUES:\n");

            foreach (var item in dictionary)
            {
                if (item.Value != 1)
                {
                    _printer.Print($"\t{item.Key}\n");

                    countOfDuplicates += item.Value;
                }
            }

            _printer.Print($"\n COUNT OF DUPLICATES: {countOfDuplicates}\n");
        }
    }
}
