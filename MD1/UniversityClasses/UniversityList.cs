using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UniversityClasses
{
    public class UniversityList : IDataManager      // MD1 veidotā klase tika pārveidota, lai tā izmantotu List, nevis Array
    {
        public List<Person> people = new List<Person>();            // kā prasīts 7. punktā, var saglabāt 1.-6. izveidoto klašu instances
        public List<Teacher> teachers = new List<Teacher>();
        public List<Student> students = new List<Student>();
        public List<Course> courses = new List<Course>();
        public List<Assignment> assignments = new List<Assignment>();
        public List<Submission> submissions = new List<Submission>();

        public void CreateTestData()
        {
            /*
            int TEST_AMOUNT = 3;
            Random rnd = new Random();
            // lai testa dati būtu atšķirīgi, tiek izveidoti masīvi ar dažādām saturīgām vērtībām, no kurām nejauši izvēlēties klašu instanču īpašību vērtības
            string[] names = new string[] { "August", "Chad", "Eduard", "Martin", "Oliver", "Amelia", "Juliet", "Lois", "Maria", "Sandra", "Kai" };
            string[] surnames = new string[] { "Black", "White", "Grey", "Green", "Brown", "Wood", "Stone", "Smith", "Jones", "Taylor" };
            string[] crs = new string[] { "Algebra", "Geometry", "Mathematical Analysis", "Mathematical Analysis II", "Graph Theory", "Linear Algebra", "Linear Algebra II", "Probability & Mathematical Statistics", "Automata Theory", "Discrete Mathematics" };
            string[] asg = new string[] { "Test", "Essay", "Presentation", "Group Work" };

            for (int i=0; i<TEST_AMOUNT; i++)
            {
                teachers.Add(new Teacher());
                int nameIndex = rnd.Next(names.Length);                             // izvēlētais indekss tiek izmantots arī tālākā programmas darbībā,
                teachers[i].Name = names[nameIndex];                                // tāpēc tā vērtība tiek saglabāta

                if (nameIndex < 5) { teachers[i].Gender = "Man"; }             // īpašība Gender tiek piešķirta atbilstoši vārdam,
                else if (nameIndex < 10) { teachers[i].Gender = "Woman"; }     // jo noteikti vārdi ir biežāk sastopami noteiktam dzimumam
                else { teachers[i].Gender = "Other"; }

                teachers[i].Surname = surnames[rnd.Next(surnames.Length)];
                teachers[i].ContractDate = DateTime.Now.AddYears(-rnd.Next(10));    // lai testa dati būtu dažādi, no datuma tiek noņemts nejaušs gadu skaits
            }

            students.Add(new Student());                    // konstruktora bez argumentiem testēšanai
            for (int i = 1; i < TEST_AMOUNT; i++)
            {
                int nameIndex = rnd.Next(names.Length);
                string temp_name = names[nameIndex];

                string temp_gender;
                if (nameIndex < 5) { temp_gender = "Man"; }             // īpašība Gender tiek piešķirta atbilstoši vārdam,
                else if (nameIndex < 10) { temp_gender = "Woman"; }     // jo noteikti vārdi ir biežāk sastopami noteiktam dzimumam
                else { temp_gender = "Other"; }

                string temp_surname = surnames[rnd.Next(surnames.Length)];

                string temp_id = "";
                for (int j = 0; j < 2; j++) { temp_id += (char)(rnd.Next(97, 123)); }   // īpašībai StudentIdNumber nosacījumos netika dots noteikts apraksts,
                for (int j = 2; j < 7; j++) { temp_id += (char)(rnd.Next(48, 58)); }    // tāpēc risinājumā par paraugu tika ņemts Latvijas Universitātes studenta numurs - 2 burti un 5 cipari
                
                // students.Add(new Student(temp_name, temp_surname, temp_gender, temp_id));
            }

            for (int i = 0; i < TEST_AMOUNT; i++)
            {
                courses.Add(new Course());
                courses[i].Name = crs[rnd.Next(crs.Length)];
                courses[i].Teacher = teachers[rnd.Next(teachers.Count)];
            }

            for (int i = 0; i < TEST_AMOUNT; i++)
            {
                assignments.Add(new Assignment());
                assignments[i].Deadline = DateTime.Now.AddDays(rnd.Next(10));
                assignments[i].Course = courses[rnd.Next(courses.Count)];
                assignments[i].Description = asg[rnd.Next(asg.Length)];
            }

            for (int i = 0; i < TEST_AMOUNT; i++)
            {
                submissions.Add(new Submission());
                submissions[i].Assignment = assignments[rnd.Next(assignments.Count)];
                submissions[i].Student = students[rnd.Next(students.Count)];
                submissions[i].SubmissionTime = DateTime.Now.AddMinutes(rnd.Next(500));
                submissions[i].Score = rnd.Next(100);
            }
            */
        }

        public void Load(string path)
        {
            /*
            if (File.Exists(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UniversityList));
                using (TextReader reader = new StreamReader(path))
                {
                    var temp = (UniversityList)serializer.Deserialize(reader);
                    people = temp.people;
                    teachers = temp.teachers;
                    students = temp.students;
                    courses = temp.courses;
                    assignments = temp.assignments;
                    submissions = temp.submissions;
                }
            }
            else
            {
                Console.WriteLine("File not found!");
            }
            */
        }

        public string Print()
        {
            
            string res = "";
            
            res += "Teachers: \n";
            for (int i = 0; i < teachers.Count; i++)
            {
                if (teachers[i] != null)
                {
                    res += teachers[i].ToString() + "\n";
                }
            }
            res += "Students: \n";
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i] != null)
                    {
                    res += students[i].ToString() + "\n";
                }
                }
            res += "Courses: \n";
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i] != null)
                {
                    res += courses[i].ToString() + "\n";
                }
            }
            res += "Assignments: \n";
            for (int i = 0; i < assignments.Count; i++)
            {
                if (assignments[i] != null)
                {
                    res += assignments[i].ToString() + "\n";
                }
            }
            res += "Submissions: \n";
            for (int i = 0; i < submissions.Count; i++)
            {
                if (submissions[i] != null)
                {
                    res += submissions[i].ToString() + "\n";
                }
            }
            
            return res;
            
        }

        public void Reset()
        {
            
            people.Clear();
            teachers.Clear();
            students.Clear();
            courses.Clear();
            assignments.Clear();
            submissions.Clear();
            
        }

        public void Save(string path)
        {
            /*
            XmlSerializer serializer = new XmlSerializer(typeof(UniversityList));
            using (TextWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, this);
            }
            */
        }
    }
}
