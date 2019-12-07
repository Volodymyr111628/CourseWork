using NUnit.Framework;
using NUnitTestHomework.Business_Logic;
using System.Collections.Generic;
using System;

namespace NUnitTestHomework
{
    public class Tests
    {
        List<School> schools = new TestData().InitializeSchools();
        CoursesService coursesService = new CoursesService();

        [Test]
        public void TestIfAddStudentWithExistingIdThrowsException()
        {
            
            
            Exception ex = Assert.Throws<Exception>(() => coursesService
            .AddStudentToCourse(schools[0], "Math", new Student { Id = 10023, Name = "Peter" }));

            Assert.That(ex.Message, Is.EqualTo("Student id is not unique"));
        }
        
        [Test]
        public void TestIfAddEmptyNameOrWrongIdStudentThrowsException()
        {
            Exception ex = Assert.Throws<Exception>(() => coursesService
            .AddStudentToCourse(schools[0], "Math", new Student { Id = 0, Name = "" }));

            Assert.That(ex.Message, Is.EqualTo("Student name or Id isn't correct," +
                    " make sure Id is in range 10000 - 99999 and Name is not empty"));
        }

        [Test]
        public void TestIfAddaMoreStudentsThatPossible()
        {
            // Course swimming already have 30 students so adding add more will raise exception

            Exception ex = Assert.Throws<Exception>(() => coursesService
            .AddStudentToCourse(schools[0], "Swimming", new Student { Id = 10677, Name = "Max" }));

            Assert.That(ex.Message, Is.EqualTo("Max students count for this course reached"));
        }

    }
}