using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityClasses;
using CommunityToolkit.Mvvm.Input;

namespace MD2.StudentVM
{
    public interface IStudentViewModel
    {
        string? Name { get; set; }
        string? Surname { get; set; }
        string? Gender { get; set; }
        string? StudentIdNumber { get; set; }

        ObservableCollection<Student> StudentList { get; set; }
        Student SelectedStudent { get; set; }
        bool IsSubmitVisible { get; set; }

        
        IRelayCommand addCommand { get; }

        IRelayCommand deleteCommand { get; }

        IRelayCommand itemSelectedCommand { get; }
        
    }
}
