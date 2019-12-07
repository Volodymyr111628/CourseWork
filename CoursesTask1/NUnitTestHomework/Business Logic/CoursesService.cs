using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NUnitTestHomework.Business_Logic
{
    public class CoursesService : ICoursesService
    {
        public School AddStudentToCourse(School school, string courseName, Student student)
        {
            if(!ValidateStudent(student))
            {
                throw new Exception("Student name or Id isn't correct," +
                    " make sure Id is in range 10000 - 99999 and Name is not empty");
            }
            for (int i = 0; i < school.Courses.Count; i++)
            {
                if (courseName == school.Courses[i].CourseName)
                {
                    if(school.Courses[i].Students.Count==30)
                    {
                        throw new Exception("Max students count for this course reached");
                    }
                    if (CheckForUniqueStudentId(school, student.Id))
                    {
                        school.Courses[i].Students.Add(student);
                        return school;
                    }
                    else
                    {
                        throw new Exception("Student id is not unique");
                    }
                }
            }
            return school;
        }

        private bool ValidateStudent(Student student)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(student);
            return Validator.TryValidateObject(student, context, results, true);
        }

        public School DeleteStudentFromCourse(School school, string courseName, int studentID)
        {
            throw new NotImplementedException();
        }

        public bool CheckForUniqueStudentId(School school, int newStudentId)
        {
            for (int i = 0; i < school.Courses.Count; i++)
            {
                for (int j = 0; j < school.Courses[i].Students.Count; j++)
                {
                    if (newStudentId == school.Courses[i].Students[j].Id)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
