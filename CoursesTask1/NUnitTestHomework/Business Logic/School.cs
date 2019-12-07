using System.Collections.Generic;

namespace NUnitTestHomework.Business_Logic
{
    public class School
    {
        public string SchoolName { get; set; }
        public List<Course> Courses { get; } = new List<Course>();


        public void AddCourse(string courseName)
        {
            var course = new Course { CourseName = courseName, Students = new List<Student>() };

            Courses.Add(course);
        }
    }
}
