using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UniversityClasses
{
    public class Assignment
    {
        public int Id { get; set; }
        public DateTime Deadline { get; set; }
        public Course Course { get; set; }
        public string? Description { get; set; }
        public ICollection<Submission> Submissions { get; }

        public override string? ToString()
        {
            return Description + ", Deadline: "  + DateOnly.FromDateTime(Deadline).ToString() + ", " + Course.ToString();   // nosacījumos tiek lūgts tikai Date, tāpēc tiek atgriezta tikai Date vērtība
        }
    }
}
