using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the new object.
            var book = new Book("Sergi's grade book");
            
            // Methods used to interact with the object.
            book.AddGrade(89.1);
            book.AddGrade(98.1);
            book.AddGrade(74.61);

            var stats = book.GetStatistics();   

            Console.WriteLine($"The avergare grade is: {stats.Average:N2}");  // Specifying the number of decimals.
            Console.WriteLine($"The max grade is: {stats.High}");  // Specifying the number of decimals.
            Console.WriteLine($"The min grade is: {stats.Low}");  // Specifying the number of decimals.
        }
    }
}
