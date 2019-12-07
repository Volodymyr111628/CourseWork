using System;
using System.ComponentModel.DataAnnotations;

namespace NUnitTestHomework.Business_Logic
{
    public class Student
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [Range(10000, 99999)]
        public int Id { get; set; }

    }
}
