using System;
using System.Collections.Generic;

namespace GradeBook
{
    // Defining a delegate for the event. Typically they have two parameters.
        public delegate void GradeAddedDelegate(object sender, EventArgs args);

    // Example on inheritance.
    public class NamedObject
    {   
        // Constructor for the clas.
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;            
        }
    }

    // Interface definition.
    public interface IBook
    {
        // public at the behining cannot be used.
        void AddGrade(double grade);
        Statisitcs GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    // Used to implement polymorphisim.
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public virtual event GradeAddedDelegate GradeAdded;

        // Inside an abstract class we can have abstract methods.
        public abstract void AddGrade(double grade);

        public virtual Statisitcs GetStatistics()
        {
            throw new NotImplementedException();
        }
    }

    public class InMemoryBook : Book
    {       

        // Explicit CONSTRUCTOR. Same name than int he class.
        // "name" is constructor parameter. Requiered when creating a new object.
        // base() is used to refer to the constractor of the base class. In this case NamedObject.
        public InMemoryBook(string name) : base(name)
        {
            Name = name; // Implicity name.
            grades = new List<double>();  // Initiallization
        }

        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':  // SINGLE cotation must be used.
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:  // If it does not match none of the previous cases.
                    AddGrade(0);
                    break;
            }
        }

        // We can only override abstract methods. 
        // Requiered for the implementaiton using polymorphism
        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                // Console.WriteLine("Invalid value");

                // nameof() force of to change the name "grade", if changed.
                throw new ArgumentException($"Invalid {nameof(grade)}"); 
            }
        }

        // Definfing the event. A field in the Book class.
        public override event GradeAddedDelegate GradeAdded;

        public override Statisitcs GetStatistics()
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

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            // done:  // Label for the 'goto' statement
            return result;
        }

        // public string Name;

        // To encapsulate the property.
        //  To have access the name, and be able to set it.
        public string Name
        {
            // What read the property.
            get{
                return name;
            }
            // what sets the property.
            set{
                if(!String.IsNullOrEmpty(value))
                {
                    name = value;  // value is an implicity variable of the setter. It is the value trying to be written in the property.
                }
            }
        }

        // To protect the name of the gradeebook.
        private string name;
        
        private List<double> grades; 
        
    }
}