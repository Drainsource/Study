
















public class CollageClassModel
{
    public event EventHandler<string> EnrollmentFull;

    private List<string> enrolledStudents = new List<string>();
    private List<string> waitingList = new List<string>();

    public string CourseTitile { get; private set; }
    public int MaximumStudents { get; private set; }


    public CollageClassModel(string title, int maximumStudents)
    {
        CourseTitile = title;
        MaximumStudents = maximumStudents;
    }

    public string SignUpStudent(string studentName)
    {
        string output = "";
        if (enrolledStudents.Count < MaximumStudents)
        {
            enrolledStudents.Add(studentName);
            output = $"{studentName} was added enrolled in {CourseTitile}";
            if (enrolledStudents.Count == MaximumStudents)
            {
                EnrollmentFull?.Invoke(this, $"{CourseTitile} enrollment is full.");
            }
        }
        else
        {
            waitingList.Add(studentName);
            output = $"{studentName} was added wait list in {CourseTitile}";
        }

        return output;
    }
}



