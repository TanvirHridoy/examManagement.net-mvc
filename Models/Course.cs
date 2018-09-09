using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public ICollection<string> OrganizationName { get; set; }
        [Required]
        [MaxLength(50)]
        public string CourseName { get; set; }
        [Required]
        [MaxLength(50)]
        public string CourseCode { get; set; }
        public double Duration { get; set; }
        public double   Credit{ get; set; }
        public string Outline { get; set; }
        public List<Tags> TagsList { get; set; }
        public List<Trainer> TrainerList { get; set; }
        public bool TrainerType { get; set; }
        public List<Student> Students { get; set; }
        public List<Exams> Examses { get; set; }
    }
}
