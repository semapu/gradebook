using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book  // We want to expose this classe to be accesable from the UnitTest
    {
        // Explicit CONSTRUCTOR. Same name than int he class
        public Book(string name)  // "name" is constructor parameter. Requiered when creating a new object
        {
            Name = name; // Implicity name 
            grades = new List<double>();  // Initiallization
        }

        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid value");
            }
        }

        public Statisitcs GetStatistics()
        {
            var result = new Statisitcs();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach(double grade in grades)  // To loop through a colleciton.

            {   
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }

            result.Average /= grades.Count;

            return result;
        }

        public string Name;
        private List<double> grades; 
        
    }
}