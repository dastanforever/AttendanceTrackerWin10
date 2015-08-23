using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace AttendanceTracker.Model
{
    public class Userdata
    { 
        public string Name { get; set; }

        public int Age { get; set; }
        
        public int NumberOfSubjects { get; set; }

        public void addData(string name, int age, int numbersub)
        {
            Name = name;

            Age = age;

            NumberOfSubjects = numbersub;
        }

        public string getName()
        {
            return Name;
        }

    }
}
