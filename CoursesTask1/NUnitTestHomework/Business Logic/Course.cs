using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NUnitTestHomework.Business_Logic
{
    public class Course
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string CourseName { get; set; }

        [Required]
        public List<Student> Students { get; set; }
    }
}
