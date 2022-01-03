using System;
using System.Collections.Generic;

namespace StudentApplicationApi.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
