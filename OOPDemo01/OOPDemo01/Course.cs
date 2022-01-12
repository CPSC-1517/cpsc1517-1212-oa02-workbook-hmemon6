using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo01
{
    internal class Course
    {
        public string CourseNo { get; set; } = "Unknown";
        public string CourseName { get; set; } = "Unknown";
        public string Students { get; set; } = "Unknown";

        public Course(string courseNo, string courseName)
        {
            CourseNo = courseNo;
            CourseName = courseName;
        }
        public string AddStudent(string student)
        {
            Students = student;
            return student;
        }
        public string DropStudent(string student)
        {
            Students = student;
            return student;
        }
        public int StudentCount()
        {
            int studentCount;
            studentCount += ;
            
            return studentCount;
        }
    }



}
