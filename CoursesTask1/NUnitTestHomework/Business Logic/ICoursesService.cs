namespace NUnitTestHomework.Business_Logic
{
    public interface ICoursesService
    {
         School AddStudentToCourse(School school, string courseName, Student student);

         School DeleteStudentFromCourse(School school, string courseName, int studentID);
    }
}
