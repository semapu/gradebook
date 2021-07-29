using System;
using Xunit;

namespace GradeBook.Test
{
    public class BookTest
    {
        [Fact]
        public void BookCalculateAnAverageGrade()
        {
            // Arrange.
            var book = new InMemoryBook("Segi's book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            
            // Act.
            var result = book.GetStatistics();

            // Assert.
            Assert.Equal(85.6, result.Average, 1);  // The third parameter indicates the precision (num. of decimals).
            Assert.Equal(90.5, result.High);
            Assert.Equal(77.3, result.Low);
            Assert.Equal('B', result.Letter);

        }
    }
}
