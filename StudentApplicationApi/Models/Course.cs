using System;
using System.Collections.Generic;

namespace StudentApplicationApi.Models
{
    public partial class Course
    {
        public Course()
        {
            Student = new HashSet<Student>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
