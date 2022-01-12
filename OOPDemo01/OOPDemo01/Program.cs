// See https://aka.ms/new-console-template for more information

using OOPDemo01;

const int ExitProgram = 0;
int menuChoice = 0;
const string Prompt = "1. Add student\n"
                    + "2. Drop student\n"
                    + "3. Student Count\n"
                    + "Enter Choice >>>>>>>>>>>>  ";

List<Course> studentList = new List<Course>();

Console.WriteLine("This program keeps track of the students in the course if given the coruse name, number, and student name");
Console.WriteLine();

do
{
    Console.Write(Prompt);
    menuChoice = int.Parse(Console.ReadLine());
    switch (menuChoice)
    {
        case 1:
            {
                AddStudent(studentList);
            }
            break;
        case 2:
            {
                DropStudent(studentList);
            }
            break;
        case 3:
            {

            }
            break;
        case ExitProgram: { Console.WriteLine("Thank you for using the program"); } break;
        default: { Console.WriteLine("Invalid Choice! Please try again."); } break;
    }
}while (menuChoice != ExitProgram);


static void AddStudent(List<Course> studentList)
{
    string courseNumber,
           courseName;
    Console.Write("Enter course number: ");
    courseNumber = Console.ReadLine();
    Console.Write("Enter course name: ");
    courseName = Console.ReadLine();
    Course currentStudent = new Course(courseNumber, courseName);
    Console.Write("Enter name of the student: ");
    currentStudent.AddStudent(Console.ReadLine());
    studentList.Add(currentStudent);
}

static void DropStudent(List<Course> studentList)
{
    string courseNumber,
           courseName;
    Console.Write("Enter course number: ");
    courseNumber = Console.ReadLine();
    Console.Write("Enter course name: ");
    courseName = Console.ReadLine();
    Course currentStudent = new Course(courseNumber, courseName);
    Console.Write("Enter name of the student: ");
    currentStudent.DropStudent(Console.ReadLine());
    studentList.Remove(currentStudent);
}

