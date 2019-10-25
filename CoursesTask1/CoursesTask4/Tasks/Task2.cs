﻿using System;
using System.Collections.Generic;
using Classes.Common.Runner;
using Classes.Common.Printer;
using Classes.Common.Logger;
using CoursesTask4.Common;
using System.IO;
using Classes.Common.Serializer;


namespace CoursesTask4.Tasks
{
    public class Task2 : IRunnable
    {
        private readonly IPrinter _printer;
        private readonly ILogger _logger;
        private readonly FilePrinter _filePrinter;

        public Task2()
        {
            _printer = new ConsolePrinter();
            _logger = new ExceptionLogger(new FilePrinter("Exceptions.txt"), "Thread");
            _filePrinter = new FilePrinter();
        }

        public void Run()
        {
            _printer.Print("\n-----TASK2-----\n");

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
                XmlSerializer<List<Car>> xmlSerializer = new XmlSerializer<List<Car>>("Cars.xml", cars);
                xmlSerializer.Serialize();
            }
            catch (IOException ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message}"));
                _logger.WriteMessage(ex.ToString());
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message}"));
                throw;
            }

            try
            {
                XmlSerializer<List<Car>> xmlSerializer = new XmlSerializer<List<Car>>("Cars.xml");
                var deserializedCars = xmlSerializer.Deserialize();

                foreach (var car in deserializedCars)
                {
                    _printer.Print(car.ReturnString());
                }
            }
            catch (IOException ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message}"));
                _logger.WriteMessage(ex.ToString());
            }
            catch (Exception ex)
            {
                _printer.Print(string.Format($"Exception occured {ex.Message}"));
                throw;
            }
        }
    }
}