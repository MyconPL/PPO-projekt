namespace PPO_projekt.Domain.Entites;

public class Student
{
    public string Name { get; private  set; }
    private readonly List<int> _grades = new();

    public Student(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name cannot be empty.");
        }
        Name = name;
    }
    
    public void AddGrade(int grade)
    {
        if (grade < 1 || grade > 6)
        {
            throw new ArgumentException("Grade must be between 1 and 6.");
        }
        _grades.Add(grade);
    }

    public IReadOnlyList<int> GetGrades()
    {
        return _grades.AsReadOnly();
    }

    public double GetAverage()
    {
        if (_grades.Count == 0) return 0;
        return _grades.Average();
    }
}