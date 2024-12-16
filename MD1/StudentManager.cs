using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClasses
{
    public class StudentManager
    {
        private UniContext _context;
        public StudentManager()
        {
            _context = new UniContext();
        }

        public bool AddStudent(string name, string surname, string gender, string id)
        {
            Student temp_student = new Student();
            temp_student.Name = name;
            temp_student.Surname = surname;
            temp_student.Gender = gender;
            temp_student.StudentIdNumber = id;
            return AddStudent(temp_student);
        }

        public bool AddStudent(Student s)
        {
            try
            {
                _context.Students.Add(s);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool RemoveStudent(Student s)
        {
            try
            {
                _context.Students.Remove(s);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool Update()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }
    }
}
