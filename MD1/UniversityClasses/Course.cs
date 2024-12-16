using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClasses
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Assignment> Assignments { get; }

        public override string? ToString()
        {
            return "Course \"" + Name + "\" (Teacher: " + Teacher.ToString() + ")";     // pasniedzēja detaļas tiek ieliktas iekavās vieglākai pārskatei
        }
    }
}
