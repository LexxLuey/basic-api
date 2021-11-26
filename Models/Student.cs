using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basic_api.Models;

namespace basic_api.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; } = string.Empty;  
        public string FirstMidName { get; set; } = string.Empty;  
        public DateTime EnrollmentDate { get; set; } 
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}