using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClasses
{

    public abstract class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Gender { get; set; }

        public override string? ToString()
        {
            return Name + " " + Surname + ", " + Gender;
        }
    }

}
