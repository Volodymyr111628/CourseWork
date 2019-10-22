using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Common.Runner;
using Classes.Common.Printer;
using Classes.Common.Logger;
using CoursesTask4.Common;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Classes.Common.Serializer;
using System.Configuration;

namespace CoursesTask4.Tasks
{
    public class Task3 : IRunnable
    {
        private readonly IPrinter _printer;
        private readonly ILogger _logger;
        private readonly FilePrinter _filePrinter;

        public Task3()
        {
            _printer = new ConsolePrinter();
            _logger = new ExceptionLogger(new FilePrinter(ConfigurationManager.AppSettings["FileToWrite"].ToString())
                , ConfigurationManager.AppSettings["LevelOfDetalization"].ToString());
            _filePrinter = new FilePrinter();
        }

        public void Run()
        {
            _printer.Print("\n-----TASK3-----\n");

            List<Car> cars = new List<Car>
            {
                new Car(10,100550,512,2230),
                new Car(134,1234400,100,2450),
                new Car(1321,59000,320,3240),
                new Car(23,124920,540,2350),
                new Car(240,213000,520,2130),
                new Car(15,20344,90,2023)
            };

            try
            {
                var jsonCars = JsonConvert.SerializeObject(cars);
                _filePrinter.Path = "Cars.json";
                _filePrinter.RePrint(jsonCars);

                List<Car> carsDeserializedJson = JsonConvert.DeserializeObject<List<Car>>(File.ReadAllText("Cars.json"));

                foreach (var car in carsDeserializedJson)
                {
                    _printer.Print(car.ReturnString());
                }
            }
            catch(IOException ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message} \n"));
                _logger.WriteMessage(ex.ToString());
            }
        }
    }
}
