using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClasses
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Gender { get; set; }
        public string? StudentIdNumber { get; set; }

        public override string? ToString()
        {
            return Name + " " + Surname +  " " + StudentIdNumber + ", " + Gender;
        }
    }
}
