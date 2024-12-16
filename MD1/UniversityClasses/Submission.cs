using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClasses
{
    public class Submission
    {
        public int Id { get; set; }
        public Assignment Assignment { get; set; }
        public Student Student { get; set; }
        public DateTime SubmissionTime { get; set; }
        public int Score { get; set; }

        public override string? ToString()
        {
            return "Assignment: " + Assignment.ToString() + ", Student: " + Student.ToString() + ", Score: " + Score.ToString() + ", Submitted at: " + SubmissionTime.ToString();
        }
    }
}
