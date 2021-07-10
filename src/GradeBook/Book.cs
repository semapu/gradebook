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

            /* Using FORECH */
            foreach(double grade in grades)  // To loop through a colleciton.
            {   
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }

            /* Using DO - WHILE. The first iteration is always done (there is no conditio to check at the beginning*/
            // var index = 0;
            // do
            // {
            //     result.High = Math.Max(grades[index], result.High);
            //     result.Low = Math.Min(grades[index], result.Low);
            //     result.Average += grades[index];

            //     index += 1;

            // } while(index < grades.Count);

            /* Using WHILE */
            // var index = 0;
            // while(index < grades.Count)
            // {
            //     result.High = Math.Max(grades[index], result.High);
            //     result.Low = Math.Min(grades[index], result.Low);
            //     result.Average += grades[index];

            //     index += 1;

            // } 

            /* Using FOR. Statements separated by ; */
            // for(var index = 0; index < grades.Count; index++)
            // {
            //     /* Continu - Break example */
            //     if(grades[index] == 42.1)  // Simple example. No reason behind.
            //     {
            //         // break;
            //         continue;  // For instance, if we do not want to count this grade.
            //         index += 1;
            //     }

            //     /* GOTO exmaple. Nowadays it is rarely used.*/
            //     if(grades[index] == 41.2)  // Simple example. No reason behind.
            //     {
            //         goto done;  // This forces the code to jump to the label.
            //     }

            //     result.High = Math.Max(grades[index], result.High);
            //     result.Low = Math.Min(grades[index], result.Low);
            //     result.Average += grades[index];

            //     index += 1;

            // } 

            result.Average /= grades.Count;

            done:
            return result;
        }

        public string Name;
        private List<double> grades; 
        
    }
}