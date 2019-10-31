using System.Collections.Generic;
using Classes.Common.Runner;
using Classes.Common.Printer;
using Classes.Common.Logger;
using CoursesTask4.Common;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;

namespace CoursesTask4.Tasks
{
    public class Task3 : IRunnable
    {
        private readonly IPrinter _printer;
        private readonly ILogger<Task3> _logger;

        public Task3(ILogger<Task3> logger, IPrinter printer)
        {
            _printer = printer;
            _logger = logger;
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
                
                _printer.Print(jsonCars);

                List<Car> carsDeserializedJson = JsonConvert.DeserializeObject<List<Car>>(File.ReadAllText("Cars.json"));

                foreach (var car in carsDeserializedJson)
                {
                    _printer.Print(car.ReturnString());
                }
            }
            catch(IOException ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message} \n"));
                _logger.WriteMessage(ex.ToString(),LevelOfDetalization.Error);
            }
        }
    }
}
