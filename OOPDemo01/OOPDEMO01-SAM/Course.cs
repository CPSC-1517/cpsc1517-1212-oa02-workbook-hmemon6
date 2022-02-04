using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDEMO01_SAM
{
    public class Course
    {
        #region Readonly Data Fields
        // Degine readonly data fields
        public readonly string CourseNo;

        // Define a backing field
        private string _CourseName;
        //Define a private set property for CourseName
        public string CourseName
        {
            get { return _CourseName; }
            private set // allows internal access within current class only. External code will not be allowed to change the property.
            {
                // Validate that courseName is not null or an empty string
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Course CourseName value is requried.");
                }
                _CourseName = value.Trim();
                
            }
        }
        public readonly List<string> Students = new List<string>();
        #endregion

        #region Readonly Property
        public int StudentCount
        {
            get { return Students.Count; }
        }
        #endregion

        #region Constructors
        public Course(string courseNo, string courseName)
        {
            // Validate that courseNo is not null, or an empty string and must contain exactly 8 characters
            // where the first 4 characters are letters and the last 4 characters are digits.
            if (string.IsNullOrEmpty(courseNo))
            {
                throw new ArgumentException("CourseNo is requried.");
            }
            if(courseNo.Length != 8)
            {
                throw new ArgumentException("CourseNo must contain exactly 8 characters");
            }

            CourseNo = courseNo;
            CourseName = courseName;

        }
        #endregion

        #region Instance-Level Methods
        public void AddStudent(string name)
        {
            Students.Add(name);
        }
        public void RemoveStudent(string name)
        {
            Students.Remove(name);
        }

        public bool SaveToFile(string filePath)
        {
            bool success = false;

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    //Write to the file CourseNo and CourseName
                    writer.WriteLine($"{CourseNo}");
                    writer.WriteLine($"{CourseName}");
                    //Write the name of all the students in the course
                    foreach (var currentStudent in Students)
                    {
                        writer.WriteLine(currentStudent);
                    }
                    writer.Close(); // optional if you use using but never hurts to put in there
                    success = true;
                }
            }
            catch
            {
                success = false;
            }

            return success;
        }
        public bool LoadFromFile(string filePath)
        {
            bool success = false;
            try
            {
                //Read the CourseNo and CourseName from the file
                using (StreamReader reader = new StreamReader(filePath))
                {
                    var CourseNo = reader.ReadLine();
                    var CourseName = reader.ReadLine();
                    //Read the student names from the file
                    while(reader.EndOfStream == false)
                    {
                        string? lineData = reader.ReadLine();
                        if (!string.IsNullOrEmpty(lineData))
                        {
                            Students.Add(lineData);
                        }

                    }
                }
                success = true;

            }
            catch
            {
                success = false;
            }
            
            return success;
        }
        #endregion

        public override string ToString()
        {
            return $"{CourseNo}, {CourseName}";

        }
    }
}
