using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClasses
{
    public class Teacher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Gender { get; set; }
        public DateTime ContractDate { get; set; }
        public ICollection<Course> Courses { get; }
        
        public override string? ToString()
        {
            return Name + " " + Surname + ", " + Gender + ", Contract date: " + DateOnly.FromDateTime(ContractDate).ToString();  // nosacījumos tiek lūgts tikai Date, tāpēc tiek atgriezta tikai Date vērtība
        }
    }
}
