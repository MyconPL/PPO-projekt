using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PPO_projekt.Application.Services;
using PPO_projekt.Domain.Entities;

namespace PPO_projekt.MAUI.ViewModels;

public partial class SchoolViewModel : ObservableObject
{
    private readonly SchoolService _schoolService;

    public SchoolViewModel(SchoolService schoolService)
    {
        _schoolService = schoolService;
        RefreshLists();
    }

    // Kolekcje powiązane z UI
    public ObservableCollection<Student> Students { get; } = new();
    public ObservableCollection<Subject> Subjects { get; } = new();
    public ObservableCollection<Teacher> Teachers { get; } = new();

    // Pola tekstowe dla formularzy
    [ObservableProperty] private string _studentName = string.Empty;
    [ObservableProperty] private string _subjectName = string.Empty;
    [ObservableProperty] private string _teacherName = string.Empty;
    [ObservableProperty] private string _gradeInput = string.Empty;

    // Pola do zaznaczania elementów w Pickerach (dropdownach)
    [ObservableProperty] private Student? _selectedStudent;
    [ObservableProperty] private Subject? _selectedSubject;
    [ObservableProperty] private Teacher? _selectedTeacher;
    [ObservableProperty] private Student? _gradeSelectedStudent;

    // --- KOMENDY DODAWANIA ---

    [RelayCommand]
    private void AddStudent()
    {
        if (string.IsNullOrWhiteSpace(StudentName)) return;
        _schoolService.AddStudent(StudentName);
        StudentName = string.Empty;
        RefreshLists();
    }

    [RelayCommand]
    private void AddSubject()
    {
        if (string.IsNullOrWhiteSpace(SubjectName)) return;
        _schoolService.AddSubject(SubjectName);
        SubjectName = string.Empty;
        RefreshLists();
    }

    [RelayCommand]
    private void AddTeacher()
    {
        if (string.IsNullOrWhiteSpace(TeacherName)) return;
        _schoolService.AddTeacher(TeacherName);
        TeacherName = string.Empty;
        RefreshLists();
    }

    // --- KOMENDY RELACJI ---

    [RelayCommand]
    private void AssignStudentToSubject()
    {
        if (SelectedStudent == null || SelectedSubject == null) return;
        _schoolService.AssignStudentToSubject(SelectedStudent.Name, SelectedSubject.Name);
        App.Current?.MainPage?.DisplayAlert("Sukces", $"Przypisano ucznia {SelectedStudent.Name} do przedmiotu {SelectedSubject.Name}", "OK");
    }

    [RelayCommand]
    private void AssignSubjectToTeacher()
    {
        if (SelectedSubject == null || SelectedTeacher == null) return;
        _schoolService.AssignSubjectToTeacher(SelectedSubject.Name, SelectedTeacher.Name);
        App.Current?.MainPage?.DisplayAlert("Sukces", $"Przypisano przedmiot {SelectedSubject.Name} nauczycielowi {SelectedTeacher.Name}", "OK");
    }

    [RelayCommand]
    private void AddGrade()
    {
        if (GradeSelectedStudent == null || !int.TryParse(GradeInput, out int grade)) return;
        _schoolService.AddGrade(GradeSelectedStudent.Name, grade);
        GradeInput = string.Empty;
        
        double avg = _schoolService.GetStudentAverage(GradeSelectedStudent.Name);
        App.Current?.MainPage?.DisplayAlert("Ocena dodana", $"Nowa średnia ucznia {GradeSelectedStudent.Name} wynosi: {avg:F2}", "OK");
    }

    // --- METODA POMOCNICZA ---
    private void RefreshLists()
    {
        // Odświeżanie studentów
        Students.Clear();
        foreach (var s in _schoolService.GetStudents()) Students.Add(s);

        // Odświeżanie przedmiotów
        Subjects.Clear();
        foreach (var sub in _schoolService.GetSubjects()) Subjects.Add(sub);

        // Odświeżanie nauczycieli
        Teachers.Clear();
        foreach (var t in _schoolService.GetTeachers()) Teachers.Add(t);
    }
}