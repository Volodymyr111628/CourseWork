﻿using System.Collections.Generic;
using Classes.Common.Runner;
using CoursesTask6.Tasks;

namespace CoursesTask5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRunnable> tasks = new List<IRunnable>()
            {
                new Task1(),
                new Task2()
            };

            foreach (var task in tasks)
            {
                task.Run();
            }
        }
    }
}