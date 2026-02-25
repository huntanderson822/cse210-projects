// MathAssignment.cs (takes the Asignment class deets
// and adds the section and problems for the math assignment)
public class MathAssignment : Assignment
{
    private string _section;
    private string _problems;

    // The Constructor for MathAssignment
    public MathAssignment(string studentName, string topic, string section, string problems)
        : base(studentName, topic)
    {
        _section = section;
        _problems = problems;
    }
    // Get the homework list
    public string GetHomeworkList()
    {
        return $"Section {_section} Problems {_problems}";
    }
}