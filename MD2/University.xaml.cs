// visā MD2 tika izmantoti kursa lekciju slaidi, kursa lekciju ieraksti, un
// specifiskāki resursi, kas darbā norādīti blakus vietai, kur tie tika pielietoti

using UniversityClasses;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
// using Android.Content;
// using static Android.Renderscripts.ScriptGroup;

namespace MD2;

public partial class University : ContentPage
{
    // UniversityList universityList;  // MD1 veidotā klase tika pārveidota, lai tā izmantotu List, nevis Array
    public University()
    {
        InitializeComponent();
        // universityList = new UniversityList();   // 3MD,kur izmanto datubāzi, UniversityList vairs netiek izmantots
        HideAllForms();                             // palaižot programmu, tiek noslēpti visi elementi, kas ir paredzēti noteiktas funkcijas izpildei,
                                                    // jo tie būs nepieciešami lietotājam tikai tad, kad tiks veikta šī noteiktā funckcija
        DisplayLabel.IsVisible = true;
        DisplayLabel.Text = "The full row of buttons is visible when application is set to fullscreen.";  // pievienoto pogu dēļ visas neietilpst vienā rindiņā, ja aplikācija nav pilnekrāna režīmā
    }
    private void DisplayAllButton_Clicked(object sender, EventArgs e)
    {
        // funkcija paslēpj visus elementus, kas neattiecas uz datu parādīšanu lietotājam vai navigāciju starp funkcijām
        HideAllForms();
        DisplayLabel.IsVisible = true;
        DisplayChanges();   // izsauc funkciju, kas parāda visus datubāzē esošos datus
    }

    private void GenerateDataButton_Clicked(object sender, EventArgs e)
    {
        // funkcija saražo testa datus un tos parāda lietotājam
        try
        {
            using (var context = new UniContext())
            {
                // sākumā funkcija iztīra datubāzi, lai nenotiktu datu dublēšana
                var submissions = context.Submission.ToList();
                context.Submission.RemoveRange(submissions);        // no datubāzes tiek izdzēsts pilnais saraksts ar datiem, tāpēc izmanto .RemoveRange()s
                var assignments = context.Assignment.ToList();
                context.Assignment.RemoveRange(assignments);
                var courses = context.Course.ToList();
                context.Course.RemoveRange(courses);
                var students = context.Students.ToList();
                context.Students.RemoveRange(students);
                var teachers = context.Teachers.ToList();
                context.Teachers.RemoveRange(teachers);
                context.SaveChanges();

                // katrs objekts tiek izveidots, tam tiek piešķirtas nepieciešamās vērtības, un tas tiek saglabāts datubāzē
                var teacher = new Teacher();
                teacher.Name = "Robert";
                teacher.Surname = "Sawyer";
                teacher.Gender = "Man";
                teacher.ContractDate = DateTime.Now;
                context.Teachers.Add(teacher);
                context.SaveChanges();
                teacher = new Teacher();
                teacher.Name = "Maria";
                teacher.Surname = "Gold";
                teacher.Gender = "Woman";
                teacher.ContractDate = DateTime.Now;
                context.Teachers.Add(teacher);
                context.SaveChanges();
                teacher = new Teacher();
                teacher.Name = "Ezra";
                teacher.Surname = "Barriston";
                teacher.Gender = "Other";
                teacher.ContractDate = DateTime.Now;
                context.Teachers.Add(teacher);
                context.SaveChanges();

                var student = new Student();
                student.Name = "Sofia";
                student.Surname = "Kane";
                student.Gender = "Woman";
                student.StudentIdNumber = "sk21009";
                context.Students.Add(student);
                context.SaveChanges();
                student = new Student();
                student.Name = "Edward";
                student.Surname = "Kane";
                student.Gender = "Man";
                student.StudentIdNumber = "ek24359";
                context.Students.Add(student);
                context.SaveChanges();
                student = new Student();
                student.Name = "August";
                student.Surname = "Williams";
                student.Gender = "Man";
                student.StudentIdNumber = "aw21671";
                context.Students.Add(student);
                context.SaveChanges();
                student = new Student();
                student.Name = "Anna";
                student.Surname = "Garcia";
                student.Gender = "Woman";
                student.StudentIdNumber = "ag23040";
                context.Students.Add(student);
                context.SaveChanges();

                var course = new Course();
                teachers = context.Teachers.ToList();           // tur, kur nepieciešama atsauce uz citu klašu objektiem, no datubāzes tiek paņemts
                                                                // šīs klases objektu saraksts, no saraksta attiecīgi izvēloties nepieciešamo objektu
                course.Name = "Mathematical Analysis I";        
                course.Teacher = teachers[1];
                context.Course.Add(course);
                context.SaveChanges();
                course = new Course();
                course.Name = "Mathematical Analysis II";
                course.Teacher = teachers[1];
                context.Course.Add(course);
                context.SaveChanges();
                course = new Course();
                course.Name = "Analytical Geometry";
                course.Teacher = teachers[0];
                context.Course.Add(course);
                context.SaveChanges();

                var assignment = new Assignment();
                courses = context.Course.ToList();
                assignment.Description = "Final presentation.";
                assignment.Deadline = DateTime.Now;
                assignment.Course = courses[2];
                context.Assignment.Add(assignment);
                context.SaveChanges();
                assignment = new Assignment();
                assignment.Description = "Essay.";
                assignment.Deadline = DateTime.Now;
                assignment.Course = courses[0];
                context.Assignment.Add(assignment);
                context.SaveChanges();
                assignment = new Assignment();
                assignment.Description = "This week's homework.";
                assignment.Deadline = DateTime.Now;
                assignment.Course = courses[1];
                context.Assignment.Add(assignment);
                context.SaveChanges();
                assignment = new Assignment();
                assignment.Description = "Homework, Task 4.";
                assignment.Deadline = DateTime.Now;
                assignment.Course = courses[0];
                context.Assignment.Add(assignment);
                context.SaveChanges();

                var submission = new Submission();
                students = context.Students.ToList();
                assignments = context.Assignment.ToList();
                submission.SubmissionTime = DateTime.Now;
                submission.Score = 10;
                submission.Student = students[0];
                submission.Assignment = assignments[0];
                context.Submission.Add(submission);
                context.SaveChanges();
                submission = new Submission();
                submission.SubmissionTime = DateTime.Now;
                submission.Score = 5;
                submission.Student = students[1];
                submission.Assignment = assignments[0];
                context.Submission.Add(submission);
                context.SaveChanges();
                submission = new Submission();
                submission.SubmissionTime = DateTime.Now;
                submission.Score = 16;
                submission.Student = students[1];
                submission.Assignment = assignments[2];
                context.Submission.Add(submission);
                context.SaveChanges();
                submission = new Submission();
                submission.SubmissionTime = DateTime.Now;
                submission.Score = 6;
                submission.Student = students[1];
                submission.Assignment = assignments[0];
                context.Submission.Add(submission);
                context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }
        DisplayChanges();   // atmiņā esošie dati tiek izmainīti, un, lai lietotājs
                            // tam varētu izsekot, tiek parādītas šīs izmaiņas
    }

    private void HideAllForms()
    {
        // funkcija paslēpj visus elementus, kas neattiecas uz navigāciju starp programmas funkcijām
        DisplayLabel.IsVisible = false;

        StudentForm.IsVisible = false;
        DeleteStudentForm.IsVisible = false;
        AssignmentForm.IsVisible = false;
        DeleteAssignmentForm.IsVisible = false;
        SubmissionForm.IsVisible = false;
        DeleteSubmissionForm.IsVisible = false;

        SelectEditStudent.IsVisible = false;
        SelectEditAssignment.IsVisible = false;
        SelectEditSubmission.IsVisible = false;

        ErrorLabel.IsVisible = false;

        // sākot MD2, nesapratu, kā vienu un to pašu parametru padot dažādiem Page, tāpēc nolēmu taisīt
        // lapu ar noteiktiem elementiem, kurus slēpt / rādīt lietotājam pēc nepieciešamības -
        // apzinos, ka tā nav pati labākā pieeja, taču es neesmu gatava visu pārtaisīt, ja arī šobrīd strādā
    }
    private void DisplayChanges()
    {
        // lai lietotājs spētu izsekot datu izmaiņām, šī funkcija parāda visus atmiņā
        // esošos datus un tiek izsaukta pēc darbībām, kas izmaina programmā esošos datus
        HideAllForms();
        DisplayLabel.IsVisible = true;
        DisplayLabel.Text = "";

        try
        {
            using (UniContext db = new UniContext()) { 
                DisplayLabel.Text += "TEACHERS: \n";
            // dažādo query izveidei tika izmantots sekojošais resurss:
            // https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/ado-net-code-examples
            var tQuery = from t in db.Teachers
                         select new
                         {
                             tName = t.Name,
                             tSurname = t.Surname,
                             tGender = t.Gender,
                             tContractDate = t.ContractDate
                         };
            foreach (var info in tQuery)
            {
                DisplayLabel.Text += info.tName + " " + info.tSurname + ", " + info.tGender + ", Contract date: " + info.tContractDate + "\n";
            }

            DisplayLabel.Text += "STUDENTS: \n";
            var sQuery = from s in db.Students
                         select new
                         {
                             sName = s.Name,
                             sSurname = s.Surname,
                             sGender = s.Gender,
                             sIdNumber = s.StudentIdNumber
                         };
            foreach (var info in sQuery)
            {
                DisplayLabel.Text += info.sName + " " + info.sSurname + ", " + info.sGender + ", " + info.sIdNumber + "\n";
            }

            DisplayLabel.Text += "COURSES: \n";
            var cQuery = from c in db.Course
                         select new
                         {
                             cName = c.Name,
                             cTeacher = c.Teacher
                         };
            foreach (var info in cQuery)
            {
                DisplayLabel.Text += info.cName + ", " + info.cTeacher + "\n";
            }

            DisplayLabel.Text += "ASSIGNMENTS: \n";
            var aQuery = from a in db.Assignment
                         select new
                         {
                             aCourse = a.Course,
                             aDeadline = a.Deadline,
                             aDescription = a.Description
                         };
            foreach (var info in aQuery)
            {
                DisplayLabel.Text += info.aCourse + ", Deadline: " + info.aDeadline + ", " + info.aDescription + "\n";
            }

            DisplayLabel.Text += "SUBMISSIONS: \n";
            var bQuery = from b in db.Submission
                         select new
                         {
                             bAssignment = b.Assignment,
                             bStudent = b.Student,
                             bSubmissionTime = b.SubmissionTime,
                             bScore = b.Score
                         };
            foreach (var info in bQuery)
            {
                DisplayLabel.Text += info.bAssignment + ", Submitted by " + info.bStudent + ", " + info.bScore + ", Submitted at " + info.bSubmissionTime + "\n";
            }
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }
    }

    private void AddStudentButton_Clicked(object sender, EventArgs e)
    {
        // funkcija sagatavo un lietotājam parāda formu, kurā ievadīt Student objekta datus
        HideAllForms();
        StudentForm.IsVisible = true;    // lietotājam top redzama Student objekta ievadei paredzētā forma

        // tiek dzēsti dati, kas varētu atrasties formā no iepriekšējā objekta pievienošanas
        StudentNameEntry.Text = "";
        StudentSurnameEntry.Text = "";
        StudentIdEntry.Text = "";
        StudentGenderPicker.SelectedIndex = 0;
    }

    private void AddStudentSubmit_Clicked(object sender, EventArgs e)
    {
        // funkcija izveido un sarakstam pievieno jaunu Student objektu
        try
        {
            using (var context = new UniContext())
            {
                Student temp_student = new Student();
                temp_student.Name = StudentNameEntry.Text;
                temp_student.Surname = StudentSurnameEntry.Text;
                temp_student.StudentIdNumber = StudentIdEntry.Text;
                if (StudentGenderPicker.SelectedIndex == 0)
                { temp_student.Gender = "Man"; }
                else if (StudentGenderPicker.SelectedIndex == 1)
                { temp_student.Gender = "Woman"; }
                else
                { temp_student.Gender = "Other"; }              // netiek veikta pārbaude attiecībā uz SelectedIndex == -1, jo jau iepriekš tiek iestatīts cits sākuma indekss
                context.Students.Add(temp_student);     // tā vietā, lai objekts tiktu saglabāts sarakstā, tas tiek pievienots datubāzē
                context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }
        DisplayChanges();       // atmiņā esošie dati tiek izmainīti, un, lai lietotājs
                                // tam varētu izsekot, tiek parādītas šīs izmaiņas
    }
    private void EditStudentButton_Clicked(object sender, EventArgs e)
    {
        // funkcija sagatavo izvēlni, kas ļauj lietotājam izvēlēties, kuru no esošajiem Student labot
        HideAllForms();
        SelectEditStudent.IsVisible = true;

        try
        {
            using (var context = new UniContext())
            {
                // Student objektu saraksts var mainīties, tāpēc Picker izmantotais saraksts tiek mainīts katru reizi, kad to jāizmanto
                SelectEditStudent.Items.Clear();
                var sQuery = from s in context.Students                                           // pievienojot datubāzi, visu Student objektu saraksts tiek iegūts caur vaicājumu
                             select new
                             {
                                 sName = s.Name,
                                 sSurname = s.Surname,
                                 sGender = s.Gender,
                                 sIdNumber = s.StudentIdNumber
                             };
                foreach (var info in sQuery)
                {
                    SelectEditStudent.Items.Add(info.sName + " " + info.sSurname + ", " + info.sGender + ", " + info.sIdNumber);                            // for cikla izmantošanai, lai pievienotu objektus, tika izmantots sekojošais resurss:
                }                                                                                                                                           // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-8.0
                SelectEditStudent.SelectedIndex = -1;
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }
    }

    private void SelectEditStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        // funkcija aizpilda formas laukus ar labojamā Assignment objekta vērtībām, un sagatavotu formu parāda lietotājam
        try
        {
            using (var context = new UniContext())
            {
                Student temp_student = new Student();
                if (SelectEditStudent.SelectedIndex != -1)      // pārbauda, vai lietotājs ir izvēlējies labojamo Student objektu
                {
                    var sQuery = from s in context.Students
                                 where s.Id == SelectEditStudent.SelectedIndex + 1       // datubāzēs esošie id un programmā izmantotie indeksi atšķiras par 1
                                 select new { sStudent = s };                                    // lai tiktu iegūts ne tikai Assignment, bet arī atbilstošais Course objekts, tiek izmantots vaicājums
                    foreach (var info in sQuery)
                    {
                        temp_student = info.sStudent;
                    }

                    StudentNameEntry.Text = temp_student.Name;
                    StudentSurnameEntry.Text = temp_student.Surname;
                    if (temp_student.Gender == "Man")
                    { StudentGenderPicker.SelectedIndex = 0; }
                    else if (temp_student.Gender == "Woman")
                    { StudentGenderPicker.SelectedIndex = 1; }
                    else
                    { StudentGenderPicker.SelectedIndex = 2; ; }              // netiek veikta pārbaude attiecībā uz SelectedIndex == -1, jo jau iepriekš tiek iestatīts cits sākuma indekss
                    StudentIdEntry.Text = temp_student.StudentIdNumber;

                    StudentForm.IsVisible = true;
                    AddStudentSubmit.IsVisible = false;      // forma tiek izmantota gan objektu izveidei, gan labošanai, bet ir nepieciešama tieši
                    EditStudentSubmit.IsVisible = true;      // objektu labošana, tāpēc labošanas poga tiek parādīta, kāmēr izveides - paslēpta 
                }
                else
                {
                    HideAllForms();                         // lietotājam obligāti jāizvēlas Student, lai to varētu labot,
                    SelectEditStudent.IsVisible = true;     // tāpēc tiek turpināta rādīt tikai izvēlne, kur to var izvēlēties
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }
    }
    private void EditStudentSubmit_Clicked(object sender, EventArgs e)
    {
        // funkcija izvēlētajam Student objektam piešķir labotās vērtības
        try
        {
            using (var context = new UniContext())
            {
                ErrorLabel.IsVisible = false;
                var students = context.Students.ToList();
                students[SelectEditStudent.SelectedIndex].Name = StudentNameEntry.Text;             // Picker indeksācija neatšķiras no saraksta indeksācijas, tāpēc izvēlētais indekss tiek izmantots saraksta piekļuvei bez pārveidojumiem
                students[SelectEditStudent.SelectedIndex].Surname = StudentSurnameEntry.Text;
                students[SelectEditStudent.SelectedIndex].StudentIdNumber = StudentIdEntry.Text;
                if (StudentGenderPicker.SelectedIndex == 0)
                { students[SelectEditStudent.SelectedIndex].Gender = "Man"; }
                else if (StudentGenderPicker.SelectedIndex == 1)
                { students[SelectEditStudent.SelectedIndex].Gender = "Woman"; }
                else
                { students[SelectEditStudent.SelectedIndex].Gender = "Other"; }
                context.SaveChanges();
                DisplayChanges();       // atmiņā esošie dati tiek izmainīti, un, lai lietotājs
                                        // tam varētu izsekot, tiek parādītas šīs izmaiņas
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }
    }

    private void DeleteStudentButton_Clicked(object sender, EventArgs e)
    {
        // lietotājam sagatavo un parāda formu, kas paredzēta Student objekta dzēšanai
        HideAllForms();
        DeleteStudentForm.IsVisible = true;
        DeleteStudentSubmit.IsEnabled = false;   // ir jāizvēlas objekts, pirms to var dzēst

        try
        {
            using (var context = new UniContext())
            {
                // Student objektu saraksts var mainīties, tāpēc Picker izmantotais saraksts tiek mainīts katru reizi, kad to jāizmanto
                SelectDeleteStudent.Items.Clear();
                var sQuery = from s in context.Students         // izmantojot datubāzi, visu Student objektu saraksts tiek iegūts, pielietojot vaicājumu
                             select new
                             {
                                 sName = s.Name,
                                 sSurname = s.Surname,
                                 sGender = s.Gender,
                                 sIdNumber = s.StudentIdNumber
                             };
                foreach (var info in sQuery)
                {
                    SelectDeleteStudent.Items.Add(info.sName + " " + info.sSurname + ", " + info.sGender + ", " + info.sIdNumber);                         // for cikla izmantošanai, lai pievienotu objektus, tika izmantots sekojošais resurss:
                }                                                                                                                                           // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-8.0
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }
    }
    private void SelectDeleteStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        DeleteStudentSubmit.IsEnabled = true;
    }

    private void DeleteStudentSubmit_Clicked(object sender, EventArgs e)
    {
        // funkcija no saraksta dzēš izvēlēto Student objektu, ja tas ir iespējams
        try
        {
            using (var context = new UniContext())
            {
                if (SelectDeleteStudent.SelectedIndex != -1)  // ir jāizvēlas objekts, pirms to var dzēst
                {
                    ErrorLabel.IsVisible = false;
                    var temp_student = new Student();
                    var students = context.Students.ToList();
                    temp_student = students[SelectDeleteStudent.SelectedIndex];         // Picker indeksācija neatšķiras no saraksta indeksācijas, tāpēc izvēlētais indekss tiek izmantots saraksta piekļuvei bez pārveidojumiem
                    context.Students.Remove(temp_student);
                    context.SaveChanges();
                    DisplayChanges();   // atmiņā esošie dati tiek izmainīti, un, lai lietotājs
                                        // tam varētu izsekot, tiek parādītas šīs izmaiņas
                }
                else
                {
                    ErrorLabel.Text = "No student has been selected.";      // lietotājam tiek parādīts kļūdas paziņojums,
                    ErrorLabel.IsVisible = true;                            //  lai šī kļūda tālāk tiktu novērsta
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }

        DeleteStudentSubmit.IsEnabled = false;
    }

    private void AddAssignmentButton_Clicked(object sender, EventArgs e)
    {
        // funkcija sagatavo un lietotājam parāda formu, kurā ievadīt Assignment objekta datus
        HideAllForms();
        AssignmentForm.IsVisible = true;
        AddAssignmentSubmit.IsVisible = true;       // forma tiek izmantota gan objektu izveidei, gan labošanai, bet ir nepieciešama tieši
        EditAssignmentSubmit.IsVisible = false;     // objektu izveide, tāpēc izveides poga tiek parādīta, kāmēr labošanas - paslēpta

        try
        {
            using (var context = new UniContext())
            {
                // Course objektu saraksts var mainīties, tāpēc Picker izmantotais saraksts tiek mainīts katru reizi, kad to jāizmanto
                AssignmentCoursePicker.Items.Clear();
                var cQuery = from c in context.Course                                           // pievienojot datubāzi, visu Course objektu saraksts tiek iegūts caur vaicājumu
                             select new
                             { cName = c.Name };
                foreach (var info in cQuery)
                {
                    AssignmentCoursePicker.Items.Add(info.cName);                               // for cikla izmantošanai, lai pievienotu objektus, tika izmantots sekojošais resurss:
                }                                                                               // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-8.0
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }

        AssignmentDatePicker.Date = DateTime.Now;   // tiek dzēsti / atgriezti uz noklusētajiem dati, kas varētu
        AssignmentDescriptionEntry.Text = "";       // atrasties formā no iepriekšējā objekta pievienošanas
    }

    private void AddAssignmentSubmit_Clicked(object sender, EventArgs e)
    {
        // funkcija izveido un sarakstam pievieno jaunu Assignment objektu
        try
        {
            if (AssignmentCoursePicker.SelectedIndex != -1)         // tiek veikta pārbaude, vai ir izvēlēta jaunā Assignment objekta
            {                                                       // Course vērtība - nav paredzēts, ka tā paliek tukša
                using (var context = new UniContext())
                {
                    Assignment temp_assignment = new Assignment();
                    var courses = context.Course.ToList();
                    ErrorLabel.IsVisible = false;

                    temp_assignment.Course = courses[AssignmentCoursePicker.SelectedIndex];         // Picker indeksācija sakrīt ar saraksta indeksāciju, tāpēc bez pārveidošanas 
                                                                                                    // var iestatīt Assignment objekta Course vērtību no esošā saraksta
                    temp_assignment.Deadline = AssignmentDatePicker.Date;
                    temp_assignment.Description = AssignmentDescriptionEntry.Text;
                    context.Assignment.Add(temp_assignment);                                // saraksta vietā jaunizveidotais objekts tiek pievienots datubāzē
                    context.SaveChanges();
                    DisplayChanges();       // atmiņā esošie dati tiek izmainīti, un, lai lietotājs
                                            // tam varētu izsekot, tiek parādītas šīs izmaiņas
                }
            }
            else
            {
                ErrorLabel.Text = "No course has been selected.";       // lietotājam tiek parādīts kļūdas paziņojums,
                ErrorLabel.IsVisible = true;                            //  lai šī kļūda tālāk tiktu novērsta
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }
    }

    private void EditAssignmentButton_Clicked(object sender, EventArgs e)
    {
        // funkcija sagatavo izvēlni, kas ļauj lietotājam izvēlēties, kuru no esošajiem Assignment labot
        HideAllForms();
        SelectEditAssignment.IsVisible = true;

        try
        {
            using (var context = new UniContext())
            {
                // Assignment objektu saraksts var mainīties, tāpēc Picker izmantotais saraksts tiek mainīts katru reizi, kad to jāizmanto
                SelectEditAssignment.Items.Clear();
                var aQuery = from a in context.Assignment                                           // pievienojot datubāzi, visu Assignment objektu saraksts tiek iegūts caur vaicājumu
                             select new
                             {
                                 aCourse = a.Course,
                                 aDeadline = a.Deadline,
                                 aDescription = a.Description
                             };
                foreach (var info in aQuery)
                {
                    SelectEditAssignment.Items.Add(info.aCourse.Name + ", Deadline: " + info.aDeadline + ", " + info.aDescription);                         // for cikla izmantošanai, lai pievienotu objektus, tika izmantots sekojošais resurss:
                }                                                                                                                                           // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-8.0
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }
    }

    private void SelectEditAssignment_SelectedIndexChanged(object sender, EventArgs e)
    {
        // funkcija aizpilda formas laukus ar labojamā Assignment objekta vērtībām, un sagatavotu formu parāda lietotājam
        try
        {
            using (var context = new UniContext())
            {
                Assignment temp_assignment = new Assignment();
                Course temp_course = new Course();
                if (SelectEditAssignment.SelectedIndex != -1)   // pārbauda, vai lietotājs ir izvēlējies labojamo Assignment objektu
                {
                    var aQuery = from a in context.Assignment where a.Id == SelectEditAssignment.SelectedIndex+ 1       // datubāzēs esošie id un programmā izmantotie indeksi atšķiras par 1
                                 select new { aAssignment = a, aCourse = a.Course };                                    // lai tiktu iegūts ne tikai Assignment, bet arī atbilstošais Course objekts, tiek izmantots vaicājums
                    foreach (var info in aQuery)
                    {
                        temp_assignment = info.aAssignment;
                        temp_course = info.aCourse;
                    }
                }
                else
                {
                    HideAllForms();                         // lietotājam obligāti jāizvēlas Assignment, lai to varētu labot,
                    SelectEditAssignment.IsVisible = true;  // tāpēc tiek turpināta rādīt tikai izvēlne, kur to var izvēlēties
                }

                // Course objektu saraksts var mainīties, tāpēc Picker izmantotais saraksts tiek mainīts katru reizi, kad to jāizmanto
                AssignmentCoursePicker.Items.Clear();
                var cQuery = from c in context.Course                                           // pievienojot datubāzi, visu Course objektu saraksts tiek iegūts caur vaicājumu
                             select new { cName = c.Name };
                foreach (var info in cQuery)
                {
                    AssignmentCoursePicker.Items.Add(info.cName);                               // for cikla izmantošanai, lai pievienotu objektus, tika izmantots sekojošais resurss:
                }
                AssignmentCoursePicker.SelectedIndex = temp_course.Id-1;        // datubāzēs esošie id un programmā izmantotie indeksi atšķiras par 1

                AssignmentDatePicker.Date = temp_assignment.Deadline;
                AssignmentDescriptionEntry.Text = temp_assignment.Description;

                AssignmentForm.IsVisible = true;
                AddAssignmentSubmit.IsVisible = false;      // forma tiek izmantota gan objektu izveidei, gan labošanai, bet ir nepieciešama tieši
                EditAssignmentSubmit.IsVisible = true;      // objektu labošana, tāpēc labošanas poga tiek parādīta, kāmēr izveides - paslēpta                                                                                                                                          // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-8.0
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }
    }

    private void EditAssignmentSubmit_Clicked(object sender, EventArgs e)
    {
        // funkcija izvēlētajam Assignment objektam piešķir labotās vērtības
        try
        {
            using (var context = new UniContext())
            {
                ErrorLabel.IsVisible = false;
                var assignments = context.Assignment.ToList();
                var courses = context.Course.ToList();
                assignments[SelectEditAssignment.SelectedIndex].Course = courses[AssignmentCoursePicker.SelectedIndex];         // Picker indeksācija sakrīt ar saraksta indeksāciju, tāpēc bez pārveidošanas 
                                                                                                                                // var iestatīt Assignment objekta Course vērtību no esošā saraksta
                assignments[SelectEditAssignment.SelectedIndex].Deadline = AssignmentDatePicker.Date;
                assignments[SelectEditAssignment.SelectedIndex].Description = AssignmentDescriptionEntry.Text;
                context.SaveChanges();
                DisplayChanges();       // atmiņā esošie dati tiek izmainīti, un, lai lietotājs
                                        // tam varētu izsekot, tiek parādītas šīs izmaiņas
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }
    }

    private void DeleteAssignmentButton_Clicked(object sender, EventArgs e)
    {
        // lietotājam sagatavo un parāda formu, kas paredzēta Assignment objekta dzēšanai
        HideAllForms();
        DeleteAssignmentForm.IsVisible = true;
        DeleteAssignmentSubmit.IsEnabled = false;   // ir jāizvēlas objekts, pirms to var dzēst

        try
        {
            using (var context = new UniContext())
            {
                // Assignment objektu saraksts var mainīties, tāpēc Picker izmantotais saraksts tiek mainīts katru reizi, kad to jāizmanto
                SelectDeleteAssignment.Items.Clear();
                var aQuery = from a in context.Assignment                                           // pievienojot datubāzi, visu Assignment objektu saraksts tiek iegūts caur vaicājumu
                             select new
                             {
                                 aCourse = a.Course,
                                 aDeadline = a.Deadline,
                                 aDescription = a.Description
                             };
                foreach (var info in aQuery)
                {
                    SelectDeleteAssignment.Items.Add(info.aCourse.Name + ", Deadline: " + info.aDeadline + ", " + info.aDescription);                       // for cikla izmantošanai, lai pievienotu objektus, tika izmantots sekojošais resurss:
                }                                                                                                                                           // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-8.0
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }
    }

    private void SelectDeleteAssignment_SelectedIndexChanged(object sender, EventArgs e)
    {
        DeleteAssignmentSubmit.IsEnabled = true;
    }

    private void DeleteAssignmentSubmit_Clicked(object sender, EventArgs e)
    {
        // funkcija no saraksta dzēš izvēlēto Assignment objektu, ja tas ir iespējams
        try
        {
            using (var context = new UniContext())
            {
                if (SelectDeleteAssignment.SelectedIndex != -1)  // ir jāizvēlas objekts, pirms to var dzēst
                {
                    ErrorLabel.IsVisible = false;
                    var temp_assignment = new Assignment();
                    var assignments = context.Assignment.ToList();
                    temp_assignment = assignments[SelectDeleteAssignment.SelectedIndex];
                    context.Assignment.Remove(temp_assignment);
                    context.SaveChanges();
                    DisplayChanges();   // atmiņā esošie dati tiek izmainīti, un, lai lietotājs
                                        // tam varētu izsekot, tiek parādītas šīs izmaiņas
                }
                else
                {
                    ErrorLabel.Text = "No assignment has been selected.";   // lietotājam tiek parādīts kļūdas paziņojums,
                    ErrorLabel.IsVisible = true;                            //  lai šī kļūda tālāk tiktu novērsta
                }                                                                                                                                // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-8.0
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }

        DeleteAssignmentSubmit.IsEnabled = false;
    }

    private void AddSubmissionButton_Clicked(object sender, EventArgs e)
    {
        // funkcija sagatavo un lietotājam parāda formu, kurā ievadīt Submission objekta datus
        HideAllForms();
        SubmissionForm.IsVisible = true;
        AddSubmissionSubmit.IsVisible = true;       // funkcija sagatavo un lietotājam parāda formu, kurā ievadīt Submission objekta datus
        EditSubmissionSubmit.IsVisible = false;     // objektu izveide, tāpēc izveides poga tiek parādīta, kāmēr labošanas - paslēpta

        try
        {
            using (var context = new UniContext())
            {
                // Student un Assignment objektu saraksti var mainīties, tāpēc Picker izmantotie saraksti tiek mainīti katru reizi, kad tie jāizmanto
                SubmissionStudentPicker.Items.Clear();
                var sQuery = from s in context.Students                                           // pievienojot datubāzi, visu Student objektu saraksts tiek iegūts caur vaicājumu
                             select new
                             { sName = s.Name,
                               sSurname = s.Surname };
                foreach (var info in sQuery)
                {
                    SubmissionStudentPicker.Items.Add(info.sName + " " + info.sSurname);                                 // for cikla izmantošanai, lai pievienotu objektus, tika izmantots sekojošais resurss:
                }                                                                                                        // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-8.0

                SubmissionAssignmentPicker.Items.Clear();
                var aQuery = from a in context.Assignment                                           // pievienojot datubāzi, visu Assignment objektu saraksts tiek iegūts caur vaicājumu
                             select new
                             {
                                 aCourse = a.Course,
                                 aDeadline = a.Deadline,
                                 aDescription = a.Description
                             };
                foreach (var info in aQuery)
                {
                    SubmissionAssignmentPicker.Items.Add(info.aCourse.Name + ", Deadline: " + info.aDeadline + ", " + info.aDescription);                               // for cikla izmantošanai, lai pievienotu objektus, tika izmantots sekojošais resurss:
                }                                                                                                                                                       // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-8.0
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }

        SubmissionDatePicker.Date = DateTime.Now;   // tiek dzēsti / atgriezti uz noklusētajiem dati, kas varētu
        SubmissionScoreEntry.Text = "";             // atrasties formā no iepriekšējā objekta pievienošanas
    }

    private void AddSubmissionSubmit_Clicked(object sender, EventArgs e)
    {
        // funkcija izveido un sarakstam pievieno jaunu Submission objektu
        try
        {
            using (var context = new UniContext())
            {
                if (SubmissionStudentPicker.SelectedIndex == -1 || SubmissionAssignmentPicker.SelectedIndex == -1)  // tiek veikta pārbaude, vai ir izvēlēta jaunā Assignment objekta
                {                                                                                                   // Student un Course vērtības - nav paredzēts, ka tās paliek tukšas
                    ErrorLabel.Text = "Both a student and an assignment must be selected.";
                    ErrorLabel.IsVisible = true;
                }
                else
                {
                    Submission temp_submission = new Submission();
                    // Score ir ar tipu int, tāpēc tiek veikta pārbaude
                    // pārbaudes izveidei tika izmantots sekojošais resurss:
                    // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number
                    try
                    {
                        int temp_score = Int32.Parse(SubmissionScoreEntry.Text);    // pirmkārt, tiek pārbaudīts Score tips - ja tur radīsies kļūda,
                                                                                    // nav vērts tālāk veidot galējo Submission objektu
                        var students = context.Students.ToList();
                        temp_submission.Student = students[SubmissionStudentPicker.SelectedIndex];
                        var assignments = context.Assignment.ToList();
                        temp_submission.Assignment = assignments[SubmissionAssignmentPicker.SelectedIndex];
                        temp_submission.SubmissionTime = SubmissionDatePicker.Date;
                        temp_submission.Score = temp_score;

                        context.Submission.Add(temp_submission);
                        context.SaveChanges();
                        ErrorLabel.IsVisible = false;
                        DisplayChanges();       // atmiņā esošie dati tiek izmainīti, un, lai lietotājs
                                                // tam varētu izsekot, tiek parādītas šīs izmaiņas
                    }
                    catch (FormatException)
                    {
                        ErrorLabel.Text = "A number must be entered as a score.";   // lietotājam tiek parādīts kļūdas paziņojums,
                        ErrorLabel.IsVisible = true;                                //  lai šī kļūda tālāk tiktu novērsta
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }
    }

    private void EditSubmissionButton_Clicked(object sender, EventArgs e)
    {
        // funkcija sagatavo izvēlni, kas ļauj lietotājam izvēlēties, kuru no esošajiem Submission labot
        HideAllForms();
        SelectEditSubmission.IsVisible = true;

        try
        {
            using (var context = new UniContext())
            {
                // Submission objektu saraksts var mainīties, tāpēc Picker izmantotais saraksts tiek mainīts katru reizi, kad to jāizmanto
                SelectEditSubmission.Items.Clear();
                var bQuery = from b in context.Submission                                           // pievienojot datubāzi, visu Submission objektu saraksts tiek iegūts caur vaicājumu
                             select new
                             {
                                 bAssignment = b.Assignment,
                                 bACourse = b.Assignment.Course,
                                 bACTeacher = b.Assignment.Course.Teacher,
                                 bStudent = b.Student,
                                 bSubmissionTime = b.SubmissionTime,
                                 bScore = b.Score
                             };
                foreach (var info in bQuery)
                {
                    SelectEditSubmission.Items.Add(info.bAssignment + ",  Submitted by " + info.bStudent + ", Score: " + info.bScore + ", Submitted at " + info.bSubmissionTime);       // for cikla izmantošanai, lai pievienotu objektus, tika izmantots sekojošais resurss:
                }                                                                                                                                                           // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-8.0
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }
    }

    private void SelectEditSubmission_SelectedIndexChanged(object sender, EventArgs e)
    {
        // funkcija aizpilda formas laukus ar labojamā Submission objekta vērtībām, un sagatavotu formu parāda lietotājam
        try
        {
            using (var context = new UniContext())
            {
                Submission temp_submission = new Submission();
                Assignment temp_assignment = new Assignment();
                Student temp_student = new Student();
                if (SelectEditSubmission.SelectedIndex != -1)   // pārbauda, vai lietotājs ir izvēlējies labojamo Assignment objektu
                {
                    var bQuery = from b in context.Submission
                                 where b.Id == SelectEditSubmission.SelectedIndex + 1                                   // datubāzēs esošie id un programmā izmantotie indeksi atšķiras par 1
                                 select new { bSubmission = b, bAssignment = b.Assignment, bStudent = b.Student };      // lai tiktu iegūts ne tikai Assignment, bet arī atbilstošais Course objekts, tiek izmantots vaicājums
                    foreach (var info in bQuery)
                    {
                        temp_submission = info.bSubmission;
                        temp_assignment = info.bAssignment;
                        temp_student = info.bStudent;
                    }
                }
                else
                {
                    HideAllForms();                         // lietotājam obligāti jāizvēlas Assignment, lai to varētu labot,
                    SelectEditSubmission.IsVisible = true;  // tāpēc tiek turpināta rādīt tikai izvēlne, kur to var izvēlēties
                }

                // Assignment objektu saraksts var mainīties, tāpēc Picker izmantotais saraksts tiek mainīts katru reizi, kad to jāizmanto
                SubmissionAssignmentPicker.Items.Clear();
                var aQuery = from a in context.Assignment                                           // pievienojot datubāzi, visu Assignment objektu saraksts tiek iegūts caur vaicājumu
                             select new
                             {
                                 aCourse = a.Course,
                                 aDeadline = a.Deadline,
                                 aDescription = a.Description
                             };
                foreach (var info in aQuery)
                {
                    SubmissionAssignmentPicker.Items.Add(info.aCourse.Name + ", Deadline: " + info.aDeadline + ", " + info.aDescription);                               // for cikla izmantošanai, lai pievienotu objektus, tika izmantots sekojošais resurss:
                }
               SubmissionAssignmentPicker.SelectedIndex = temp_assignment.Id - 1;        // datubāzēs esošie id un programmā izmantotie indeksi atšķiras par 1

                // Student objektu saraksts var mainīties, tāpēc Picker izmantotais saraksts tiek mainīts katru reizi, kad to jāizmanto
                SubmissionStudentPicker.Items.Clear();
                var sQuery = from s in context.Students                                           // pievienojot datubāzi, visu Student objektu saraksts tiek iegūts caur vaicājumu
                             select new
                             {
                                 sName = s.Name,
                                 sSurname = s.Surname,
                                 sGender = s.Gender,
                                 sIdNumber = s.StudentIdNumber
                             };
                foreach (var info in sQuery)
                {
                    SubmissionStudentPicker.Items.Add(info.sName + " " + info.sSurname + ", " + info.sGender + ", " + info.sIdNumber);                               // for cikla izmantošanai, lai pievienotu objektus, tika izmantots sekojošais resurss:
                }
                SubmissionStudentPicker.SelectedIndex = temp_student.Id - 1;        // datubāzēs esošie id un programmā izmantotie indeksi atšķiras par 1

                SubmissionDatePicker.Date = temp_submission.SubmissionTime;
                SubmissionScoreEntry.Text = temp_submission.Score.ToString();                                                                                                                                       // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-8.0
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }

        SubmissionForm.IsVisible = true;
        AddSubmissionSubmit.IsVisible = false;      // forma tiek izmantota gan objektu izveidei, gan labošanai, bet ir nepieciešama tieši
        EditSubmissionSubmit.IsVisible = true;      // objektu labošana, tāpēc labošanas poga tiek parādīta, kāmēr izveides - paslēpta
    }

    private void EditSubmissionSubmit_Clicked(object sender, EventArgs e)
    {
        // funkcija izvēlētajam Submission objektam piešķir labotās vērtības, ja tas ir iespējams
        try
        {
            using (var context = new UniContext())
            {
                if (SubmissionStudentPicker.SelectedIndex == -1 || SubmissionAssignmentPicker.SelectedIndex == -1)  // tiek veikta pārbaude, vai ir izvēlēta jaunā Assignment objekta
                {                                                                                                   // Student un Course vērtības - nav paredzēts, ka tās paliek tukšas
                    ErrorLabel.Text = "Both a student and an assignment must be selected.";
                    ErrorLabel.IsVisible = true;
                }
                else
                {
                    try
                    {
                        var submissions = context.Submission.ToList();
                        var assignments = context.Assignment.ToList();
                        var students = context.Students.ToList();
                        submissions[SelectEditSubmission.SelectedIndex].Score = Int32.Parse(SubmissionScoreEntry.Text);                 // pirmkārt, tiek pārbaudīts Score tips - ja tur radīsies kļūda,
                                                                                                                                        // nav vērts tālāk veidot galējo Submission objektu
                        submissions[SelectEditSubmission.SelectedIndex].Assignment = assignments[SubmissionAssignmentPicker.SelectedIndex];         // Picker indeksācija sakrīt ar saraksta indeksāciju, tāpēc bez pārveidošanas 
                                                                                                                                                    // var iestatīt Submission objekta Assignment vērtību no esošā saraksta
                        submissions[SelectEditSubmission.SelectedIndex].Student = students[SubmissionStudentPicker.SelectedIndex];                  // Picker indeksācija sakrīt ar saraksta indeksāciju, tāpēc bez pārveidošanas 
                                                                                                                                                    // var iestatīt Submission objekta Student vērtību no esošā saraksta
                        submissions[SelectEditSubmission.SelectedIndex].SubmissionTime = SubmissionDatePicker.Date;
                        context.SaveChanges();
                        ErrorLabel.IsVisible = false;
                        DisplayChanges();       // atmiņā esošie dati tiek izmainīti, un, lai lietotājs
                                                // tam varētu izsekot, tiek parādītas šīs izmaiņas
                    }
                    catch (FormatException)
                    {
                        ErrorLabel.Text = "A number must be entered as a score.";   // lietotājam tiek parādīts kļūdas paziņojums,
                        ErrorLabel.IsVisible = true;                                //  lai šī kļūda tālāk tiktu novērsta
                    }
                }

            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }
    }

    private void DeleteSubmissionButton_Clicked(object sender, EventArgs e)
    {
        // lietotājam sagatavo un parāda formu, kas paredzēta Submission objekta dzēšanai
        HideAllForms();
        DeleteSubmissionForm.IsVisible = true;

        try
        {
            using (var context = new UniContext())
            {
                // Submission objektu saraksts var mainīties, tāpēc Picker izmantotais saraksts tiek mainīts katru reizi, kad to jāizmanto
                SelectDeleteSubmission.Items.Clear();
                var bQuery = from b in context.Submission                                           // pievienojot datubāzi, visu Assignment objektu saraksts tiek iegūts caur vaicājumu
                             select new
                             {
                                 bAssignment = b.Assignment,
                                 bACourse = b.Assignment.Course,
                                 bACTeacher = b.Assignment.Course.Teacher,
                                 bStudent = b.Student,
                                 bSubmissionTime = b.SubmissionTime,
                                 bScore = b.Score
                             };
                foreach (var info in bQuery)
                {
                    SelectDeleteSubmission.Items.Add(info.bAssignment + ",  Submitted by " + info.bStudent + ", Score: " + info.bScore + ", Submitted at " + info.bSubmissionTime);       // for cikla izmantošanai, lai pievienotu objektus, tika izmantots sekojošais resurss:
                }                                                                                                                                                           // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-8.0
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }

        DeleteSubmissionSubmit.IsEnabled = false;   // ir jāizvēlas objekts, pirms to var dzēst
    }

    private void SelectDeleteSubmission_SelectedIndexChanged(object sender, EventArgs e)
    {
        DeleteSubmissionSubmit.IsEnabled = true;
    }

    private void DeleteSubmissionSubmit_Clicked(object sender, EventArgs e)
    {
        // funkcija no saraksta dzēš izvēlēto Assignment objektu, ja tas ir iespējams
        try
        {
            using (var context = new UniContext())
            {
                if (SelectDeleteSubmission.SelectedIndex != -1)  // ir jāizvēlas objekts, pirms to var dzēst
                {
                    ErrorLabel.IsVisible = false;
                    var temp_submission = new Submission();
                    var submissions = context.Submission.ToList();
                    temp_submission = submissions[SelectDeleteSubmission.SelectedIndex];    // Picker indeksācija neatšķiras no saraksta indeksācijas, tāpēc izvēlētais indekss tiek izmantots saraksta piekļuvei bez pārveidojumiem
                    context.Submission.Remove(temp_submission);
                    context.SaveChanges();
                    DisplayChanges();   // atmiņā esošie dati tiek izmainīti, un, lai lietotājs
                                        // tam varētu izsekot, tiek parādītas šīs izmaiņas
                }
                else
                {
                    ErrorLabel.Text = "No submission has been selected.";   // lietotājam tiek parādīts kļūdas paziņojums,
                    ErrorLabel.IsVisible = true;                            //  lai šī kļūda tālāk tiktu novērsta
                }                                                                                                                                // https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-8.0
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "Program could not complete the requested action due to the following error: " + ex.Message;  // lietotājam tiek parādīts kļūdas paziņojums,
            ErrorLabel.IsVisible = true;                                                                                    //  lai šī kļūda tālāk tiktu novērsta
        }

        DeleteSubmissionSubmit.IsEnabled = false;
    }
}