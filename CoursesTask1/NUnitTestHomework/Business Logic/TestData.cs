using System.Collections.Generic;

namespace NUnitTestHomework.Business_Logic
{
    public class TestData
    {
        List<Student> LocalStudentsFirstCourse = new List<Student>
        {
            new Student{Id=10023, Name="Ivan" },
            new Student{Id=10045, Name="Max" },
            new Student{Id=12400, Name="Oleg" },
            new Student{Id=10560, Name="Alex" },
            new Student{Id=10200, Name="Paul" },
        };

        List<Student> LocalStudentsSecondCourse = new List<Student>
        {
            new Student{Id=10341, Name="Ivan" },
            new Student{Id=13445, Name="Max" },
            new Student{Id=12504, Name="Oleg" },
            new Student{Id=14365, Name="Alex" },
            new Student{Id=16332, Name="Paul" },
        };

        List<Student> LocalStudentsThirdCourse = new List<Student>
        {
            new Student{Id=20123, Name="Ivan" },
            new Student{Id=30045, Name="Max" },
            new Student{Id=42400, Name="Oleg" },
            new Student{Id=50560, Name="Alex" },
            new Student{Id=60200, Name="Paul" },
        };

        List<Student> LocalStudentsFourthCourse = new List<Student>
        {
            new Student{Id=35341, Name="Ivan" },
            new Student{Id=64445, Name="Max" },
            new Student{Id=64504, Name="Oleg" },
            new Student{Id=78365, Name="Alex" },
            new Student{Id=69332, Name="Paul" },
        };

        public List<School> InitializeSchools()
        {
            School firstSchool = new School();
            School secondSchool = new School();

            firstSchool.AddCourse("Math");
            firstSchool.AddCourse("Literature");
            firstSchool.AddCourse("Swimming");

            secondSchool.AddCourse("Art");
            secondSchool.AddCourse("Programming");

            CoursesService coursesService = new CoursesService();

            for (int i = 0; i < 30; i++)
            {
                firstSchool = coursesService.AddStudentToCourse(firstSchool, "Swimming", new Student{ Id = 70000+i, Name="Den"});
            }

            foreach (var student in LocalStudentsFirstCourse)
            {
                firstSchool=coursesService.AddStudentToCourse(firstSchool, "Math", student);
            }
            foreach (var student in LocalStudentsSecondCourse)
            {
               firstSchool= coursesService.AddStudentToCourse(firstSchool, "Literature", student);
            }
            foreach (var student in LocalStudentsThirdCourse)
            {
                secondSchool = coursesService.AddStudentToCourse(secondSchool, "Art", student);
            }
            foreach (var student in LocalStudentsFourthCourse)
            {
                secondSchool = coursesService.AddStudentToCourse(secondSchool, "Programming", student);
            }

            return new List<School> { firstSchool, secondSchool };
        }
    }
}