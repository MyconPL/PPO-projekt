namespace PPO_projekt.Application.Services;
using PPO_projekt.Domain.Entities;

public class SchoolService
{
    private readonly List<Student> _students = new();
    private readonly List<Subject> _subjects = new();
    private readonly List<Teacher> _teachers = new();

    public void AddStudent(string name)
    {
        if (_students.Any(s => s.Name == name))
            return;

        _students.Add(new Student(name));
    }

    public IReadOnlyList<Student> GetStudents()
    {
        return _students.AsReadOnly();
    }

    public Student? FindStudent(string name)
    {
        return _students.FirstOrDefault(s => s.Name == name);
    }

    public void AddSubject(string name)
    {
        if (_subjects.Any(s => s.Name == name))
            return;

        _subjects.Add(new Subject(name));
    }

    public IReadOnlyList<Subject> GetSubjects()
    {
        return _subjects.AsReadOnly();
    }

    public Subject? FindSubject(string name)
    {
        return _subjects.FirstOrDefault(s => s.Name == name);
    }

    public void AddTeacher(string name)
    {
        if (_teachers.Any(t => t.Name == name))
            return;

        _teachers.Add(new Teacher(name));
    }

    public IReadOnlyList<Teacher> GetTeachers()
    {
        return _teachers.AsReadOnly();
    }

    public void AssignStudentToSubject(string studentName, string subjectName)
    {
        var student = FindStudent(studentName);
        var subject = FindSubject(subjectName);

        if (student == null || subject == null)
            return;

        subject.AddStudent(student);
    }

    public void AssignSubjectToTeacher(string subjectName, string teacherName)
    {
        var subject = FindSubject(subjectName);
        var teacher = _teachers.FirstOrDefault(t => t.Name == teacherName);

        if (subject == null || teacher == null)
            return;

        teacher.AddSubject(subject);
    }

    public void AddGrade(string studentName, int grade)
    {
        var student = FindStudent(studentName);

        if (student == null)
            return;

        student.AddGrade(grade);
    }

    public double GetStudentAverage(string studentName)
    {
        var student = FindStudent(studentName);

        return student?.GetAverage() ?? 0;
    }
}