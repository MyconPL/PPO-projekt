namespace PPO_projekt.Domain.Entites;

public class Teacher
{
    public string Name { get; private set; }

    private readonly List<Subject> _subjects = new();

    public Teacher(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Teacher name cannot be empty.");

        Name = name;
    }

    public void AddSubject(Subject subject)
    {
        if (subject == null)
            throw new ArgumentNullException(nameof(subject));

        if (_subjects.Contains(subject))
            return;

        _subjects.Add(subject);
    }

    public IReadOnlyList<Subject> GetSubjects()
    {
        return _subjects.AsReadOnly();
    }
}