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

namespace CoursesTask4.Tasks
{
    public class Task1 : IRunnable
    {
        private readonly IPrinter _printer;
        private readonly ILogger _logger;
        private readonly FilePrinter _filePrinter;

        public Task1()
        {
            _printer = new ConsolePrinter();
            _logger = new ExceptionLogger(new FilePrinter("Exceptions.txt"), "Thread");
            _filePrinter = new FilePrinter();
        }

        public void Run()
        {
            List<Car> cars = new List<Car>
            {
                new Car(10,100550,512,2230),
                new Car(134,1234400,100,2450),
                new Car(1321,59000,320,3240),
                new Car(23,124920,540,2350),
                new Car(240,213000,520,2130),
                new Car(15,20344,90,2023)
            };

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("Cars.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, cars);
            }

            using (FileStream fs = new FileStream("Cars.dat", FileMode.Open))
            {
                List<Car> carsDeseralizedBinary = (List<Car>)formatter.Deserialize(fs);

                foreach (var car in carsDeseralizedBinary)
                {
                    _printer.Print(car.ReturnString());
                }
            }

            XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<Car>));

            using (FileStream fs = new FileStream("Cars.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(fs, cars);
            }

            using (FileStream fs = new FileStream("Cars.xml", FileMode.Open))
            {
                List<Car> carsDeserializedXml = (List<Car>)xmlFormatter.Deserialize(fs);

                foreach (var car in carsDeserializedXml)
                {
                    _printer.Print(car.ReturnString());
                }
            }

            var jsonCars = JsonConvert.SerializeObject(cars);
            ((FilePrinter)_filePrinter).Path = "Cars.json";
            _filePrinter.RePrint(jsonCars);

            List<Car> carsDeserializedJson = JsonConvert.DeserializeObject<List<Car>>(File.ReadAllText("Cars.json"));

            foreach (var car in carsDeserializedJson)
            {
                _printer.Print(car.ReturnString());
            }
            
        }
    }
}
