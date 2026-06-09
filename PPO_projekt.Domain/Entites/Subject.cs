namespace PPO_projekt.Domain.Entites;

public class Subject
{
    public string Name { get; set; }
    
    private readonly List<Student> _students = new();
    
    public Subject(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Subject name cannot be empty.");

        Name = name;
    }

    public void AddStudent(Student student)
    {
        if (student == null)
            throw new ArgumentNullException(nameof(student));

        if (_students.Contains(student))
            return;

        _students.Add(student);
    }

    public IReadOnlyList<Student> GetStudents()
    {
        return _students.AsReadOnly();
    }
}