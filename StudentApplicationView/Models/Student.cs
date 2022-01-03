using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApplicationView.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        /*[Display(Name = "Department")]
        [Required(ErrorMessage = "Department is required")]*/
        public string Gender { get; set; }
        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
