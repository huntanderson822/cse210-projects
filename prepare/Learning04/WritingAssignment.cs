// The WritingAssignment class inherits 
//from the Assignment class 
public class WritingAssignment : Assignment
{
    private string _title;
    // My Constructor for WritingAssignment
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }
    //Get the writing info 
    public string GetWritingInformation()
    {
        string studentName = GetStudentName();
        return $"{_title} by {studentName}";
    }
}