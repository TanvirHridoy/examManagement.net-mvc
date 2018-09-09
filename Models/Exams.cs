using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Exams
    {
        public int Id { get; set; }
        public List<Organization> OrganizationName { get; set; }
        public List<Course> CourseName { get; set; }
        public string ExamType { get; set; }
        public string ExamCode { get; set; }
        public string Topic { get; set; }
        public double FullMarks { get; set; }
        public double Duration { get; set; }
        public string Serial { get; set; }  
    }
}
