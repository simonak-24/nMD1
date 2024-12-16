using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using UniversityClasses;

namespace MD2.StudentVM
{
    [ObservableObject]
    public partial class StudentViewModel // : IStudentViewModel
    {
        private StudentManager _studentManager { get; set; }

        public StudentViewModel() : base()
        {
            _studentManager = new StudentManager();
            refresh();
        }
        

        [ObservableProperty]
        private string? name = "Jane";

        [ObservableProperty]
        private string? surname = "Doe";

        [ObservableProperty]
        private string? gender = "Woman";

        [ObservableProperty]
        private string? studentIdNumber = "jn01234";
        [ObservableProperty]

        private string? info = "";

        [ObservableProperty]
        private string submitButtonText = "Add Student";

        [ObservableProperty]
        private ObservableCollection<Student> studentList = new ObservableCollection<Student>() { new UniversityClasses.Student() };

        [ObservableProperty]
        private Student selectedStudent;

        [ObservableProperty]
        private bool isSubmitVisible = true;

        private Student UpdateStudent = null;

        [RelayCommand]
        private void add()
        {
            if (UpdateStudent is null)
            {
                _studentManager.AddStudent(name, surname, gender, studentIdNumber);
                Info = "Student Added";
            }
            else
            {
                UpdateStudent.Name = Name;
                UpdateStudent.Surname = Surname;
                UpdateStudent.Gender = Gender;
                UpdateStudent.StudentIdNumber = StudentIdNumber;
                _studentManager.Update();
                Info = "Student updated!";
                endEdit();
            }
            refresh();
        }

        [RelayCommand]
        private void refresh()
        {
            studentList.Clear();
            foreach (var r in _studentManager.GetStudents())
            {
                StudentList.Add(r);
            }
        }

        [RelayCommand]
        private void delete()
        {
            if (UpdateStudent != null)
            {

                _studentManager.RemoveStudent(UpdateStudent);
                Info = "Student deleted!";
                endEdit();
                refresh();
            }
        }

        private void endEdit()
        {
            UpdateStudent = null;
            SelectedStudent = null;
            SubmitButtonText = "Add Student";
            IsSubmitVisible = true;
        }

        private void startEdit()
        {
            SubmitButtonText = "Update Student";
            IsSubmitVisible = false;
        }

        [RelayCommand]
        private void itemSelected()
        {
            if (SelectedStudent != null)
            {
                Name = SelectedStudent.Name;
                Surname = SelectedStudent.Surname;
                Gender = UpdateStudent.Gender;
                StudentIdNumber = UpdateStudent.StudentIdNumber;
                if (SelectedStudent is Student)
                {
                    UpdateStudent = (Student)SelectedStudent;
                }
                startEdit();
            }
        }
    }
}