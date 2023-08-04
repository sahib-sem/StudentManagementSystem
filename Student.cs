using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    internal class Student
    {
        private static int currentRollNum = 0;

        public readonly int RollNumber = Student.NextRollNum();

        public string Name { get; set; }
        public int Age { get; set; }
        public StudentGrade Grade { get; set; }

       public Student( string name,StudentGrade Grade, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = Grade;
        }

        public static int NextRollNum()
        {
            currentRollNum++;
            return currentRollNum;
        }

        public override string ToString()
        {
            return $"RollNum: {RollNumber} ,Name: {Name}, Age: {Age}, Grade: {Grade}";
        }


    }
}
