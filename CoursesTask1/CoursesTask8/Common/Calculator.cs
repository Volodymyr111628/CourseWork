using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Common.Logger;
using Classes.Common.Printer;
using Classes.Common.Reader;
using System.Data;

namespace CoursesTask8.Common
{
    public class Calculator : ICalculator
    {
        private readonly ILogger<Calculator> _logger;
        private readonly IPrinter _printer;

        public Calculator(ILogger<Calculator> logger,IPrinter printer)
        {
            _logger = logger;
            _printer = printer;
        }

        public string Calculate(string expression)
        {
            string result = string.Empty;

            try
            {
                result = Convert.ToDouble(new DataTable().Compute(expression, string.Empty)).ToString();
            }
            catch(FormatException ex)
            {
                _printer.Print(string.Format($"Exception occured: {ex.Message}"));
                _logger.WriteMessage(ex.ToString(), LevelOfDetalization.Error);
            }
            catch(Exception ex)
            {
                _printer.Print(string.Format($"Exception occured: {ex.Message}"));
                throw;
            }

            return result.ToString();
        }
    }
}
