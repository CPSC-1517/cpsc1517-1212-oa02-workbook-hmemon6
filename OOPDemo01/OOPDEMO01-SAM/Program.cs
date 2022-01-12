// See https://aka.ms/new-console-template for more information
using OOPDEMO01_SAM;








Console.WriteLine("This program keeps track of the students in the course if given the coruse name, number, and student name");
Console.WriteLine();
const int ExitProgram = 0;
int menuChoice = 0;
const string Prompt = "1. Add student\n"
                    + "2. Drop student\n"
                    + "3. Show results\n"
                    + "0. quit program\n"
                    + "Enter Choice >>>>>>>>>>>>  ";
bool validInput = false;
while(!validInput)
{ 
try
{
Console.WriteLine("Enter Course name: ");
string courseName = Console.ReadLine();
Console.WriteLine("Enter 8 digit Course number: ");
string courseNumber = Console.ReadLine();
Course courseOne = new Course(courseNumber, courseName);
        validInput = true;
    do
    {
        Console.Write(Prompt);
        menuChoice = int.Parse(Console.ReadLine());
        switch (menuChoice)
        {
            case 1:
                {
                    AddStudent(courseOne);
                }
                break;
            case 2:
                {
                    RemoveStudent(courseOne);
                }
                break;
            case 3:
                {
                    ShowResults(courseOne);
                }
                break;

            case ExitProgram: { Console.WriteLine("Thank you for using the program"); } break;
            default: { Console.WriteLine("Invalid Choice! Please try again."); } break;
        }
    } while (menuChoice != ExitProgram);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
        validInput = false;
}
}
static void AddStudent(Course courseOne)
{ 
char yesNoAnswer = 'n';
    do
    {
        Console.Write("Enter Student name: ");
        courseOne.AddStudent(Console.ReadLine());
        Console.WriteLine("Do you want to add more students? (y/n): ");
        yesNoAnswer = Console.ReadKey().KeyChar;
        Console.WriteLine();

    }while (yesNoAnswer == 'y');

}
static void RemoveStudent(Course courseOne)
{
    char yesNoAnswer = 'n';
    do
    {

        Console.Write("Enter Student name to remove: ");
        courseOne.RemoveStudent(Console.ReadLine());
        Console.WriteLine("Do you want to remove more students? (y/n): ");
        yesNoAnswer = Console.ReadKey().KeyChar;
        Console.WriteLine();

    } while (yesNoAnswer == 'y');

}

static void ShowResults(Course courseOne)
{

    Console.WriteLine($"Course number: {courseOne.CourseNo} Course name: {courseOne.CourseName}");   
    Console.WriteLine($"Student Count: {courseOne.Students.Count}");

}