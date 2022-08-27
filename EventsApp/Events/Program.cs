


CollageClassModel history = new("History 101", 3);
CollageClassModel math = new("Calculus 201", 2);

history.EnrollmentFull += CollegeClass_EnrollmentFull;



history.SignUpStudent("Mate Toth").PrintToConsole();
history.SignUpStudent("Tim Coury").PrintToConsole();
history.SignUpStudent("Sue Storm").PrintToConsole();
history.SignUpStudent("Joe Smith").PrintToConsole();
history.SignUpStudent("Mary Jones").PrintToConsole();
history.SignUpStudent("Sandy Patty").PrintToConsole();
Console.WriteLine();


math.EnrollmentFull += CollegeClass_EnrollmentFull;



math.SignUpStudent("Tim Coury").PrintToConsole();
math.SignUpStudent("Sue Storm").PrintToConsole();
math.SignUpStudent("Joe Smith").PrintToConsole();


Console.ReadLine();



void CollegeClass_EnrollmentFull(object? sender, string e)
{
    CollageClassModel model = (CollageClassModel)sender;

    Console.WriteLine();
    Console.WriteLine($"{model.CourseTitile} Full.");
    Console.WriteLine();
}



