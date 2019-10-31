using System;
using System.Collections.Generic;
using Classes.Common.Runner;
using Classes.Common.Printer;
using Classes.Common.Logger;
using CoursesTask4.Common;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;

namespace CoursesTask4.Tasks
{
    public class Task1 : IRunnable
    {
        private readonly IPrinter _printer;
        private readonly ILogger<Task1> _logger;

        public Task1(ILogger<Task1> logger, IPrinter printer)
        {
            _printer = printer;
            _logger = logger;
        }

        public void Run()
        {
            _printer.Print("-----TASK1-----\n");
            var cars = new List<Car>
            {
                new Car(10,100550,512,2230),
                new Car(134,1234400,100,2450),
                new Car(1321,59000,320,3240),
                new Car(23,124920,540,2350),
                new Car(240,213000,520,2130),
                new Car(15,20344,90,2023)
            };

            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fs = new FileStream("Cars.dat", FileMode.OpenOrCreate);
            try
            {
                formatter.Serialize(fs, cars);
            }
            catch (IOException ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message} \n"));
                _logger.WriteMessage(ex.ToString(),LevelOfDetalization.Error);
            }
            finally
            {
                fs.Close();
            }

            fs = new FileStream("Cars.dat", FileMode.Open);

            try
            {

                List<Car> carsDeseralizedBinary = (List<Car>)formatter.Deserialize(fs);

                foreach (var car in carsDeseralizedBinary)
                {
                    _printer.Print(car.ReturnString());
                }

            }
            catch (FileNotFoundException ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message} \n"));
                _logger.WriteMessage(ex.ToString(),LevelOfDetalization.Error);
            }
            catch (IOException ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message} \n"));
                _logger.WriteMessage(ex.ToString(),LevelOfDetalization.Error);
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message} \n"));
                _logger.WriteMessage(ex.ToString(),LevelOfDetalization.Error);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}