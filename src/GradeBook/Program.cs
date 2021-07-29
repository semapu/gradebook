using System;

namespace GradeBook
{
    class Program
    {
        // Inside the main methods have to be as few code as possible.
        static void Main(string[] args)
        {
            // Create the new object.
            // var book = new InMemoryBook("Sergi's grade book");
            IBook book = new DiskBook("Sergi's grade book");


            // To tell the book that we want to handdle the event.
            book.GradeAdded += OnGradeAdded;

            // book.AddGrade(89.1);
            // book.AddGrade(98.1);
            // book.AddGrade(74.61);

            // Encapsulation of the logic behind receiving input elements from the shell.
            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the bookgrade named {book.Name}");
            Console.WriteLine($"The avergare grade is: {stats.Average:N2}");  // Specifying the number of decimals.
            Console.WriteLine($"The max grade is: {stats.High}");  // Specifying the number of decimals.
            Console.WriteLine($"The min grade is: {stats.Low}");  // Specifying the number of decimals.
            Console.WriteLine($"The letter is : {stats.Letter}");  // Specifying the number of decimals.
        }

        // Now book is polymorphic. We do not know if it is a InMemoryBook, or stored in a file.
        // However, we know that every book has a name and we can add grades to it.
        private static void EnterGrades(IBook book)
        {
            // Input grades from the console
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to exit: ");
                var input = Console.ReadLine();

                if (input == "q")  // Required the "" to indicate the comparition with an string
                {
                    break;
                }

                // Ensuring the input from the user is valid. Exception thrown in Book.AddGrade().
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                // Catching specifically the exception of interest. Invalid argument.
                catch (ArgumentException ex)
                {
                    //  Due to we have catch the exception, we can continue with the excecution.
                    Console.WriteLine(ex.Message);
                }
                // Catching a possible exception due the converting the input string into double (from input to grade).
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // Piece of code you always want to execute.
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        // Event handdler.
        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("A graded has been added");
        }
    }
}
