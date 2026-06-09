using System.Collections.ObjectModel;
using PPO_projekt.Application.Services;
using PPO_projekt.Domain.Entities;
using System.Collections.ObjectModel;

namespace PPO_projekt.MAUI.ViewModels;

public class MainViewModel
{
    private readonly SchoolService _schoolService;

    public ObservableCollection<Student> Students { get; set; } = new();

    public string NewStudentName { get; set; }
    public string GradeStudentName { get; set; }
    public int GradeValue { get; set; }

    //di
    public MainViewModel(SchoolService schoolService)
    {
        _schoolService = schoolService;
    }

    public void AddStudent()
    {
        if (string.IsNullOrWhiteSpace(NewStudentName))
            return;

        _schoolService.AddStudent(NewStudentName);

        RefreshStudents();
        NewStudentName = string.Empty;
    }

    public void RefreshStudents()
    {
        Students.Clear();

        foreach (var s in _schoolService.GetStudents())
            Students.Add(s);
    }

    public void AddGrade()
    {
        _schoolService.AddGrade(GradeStudentName, GradeValue);
        RefreshStudents();
    }
}