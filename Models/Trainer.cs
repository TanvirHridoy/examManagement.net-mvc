using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Organization> Organizations { get; set; }
        public List<Course> Courses { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public byte Image { get; set; } 

    }
}
