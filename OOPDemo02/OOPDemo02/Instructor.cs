using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo02
{
    internal class Instructor
    {
        public string Name { get; set; }
        public EmploymentType EmploymentType { get; private set; } = EmploymentType.FullTime;

        public Instructor(string Name, EmploymentType employmentType)
        {
            if(Utilities.IsValidNameLength(Name,5) == false)
            {
                throw new ArgumentException("Instructor Name must not be empty and must contain at least 5 character in length");
            }
        }
    }
}
