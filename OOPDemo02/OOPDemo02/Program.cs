// See https://aka.ms/new-console-template for more information
using OOPDemo02;


try
{
    Instructor newInstructor = new("Johnathan", EmploymentType.Sessional);
    Console.WriteLine("Instructor name created successfully");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}