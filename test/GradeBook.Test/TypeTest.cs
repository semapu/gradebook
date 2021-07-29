using System;
using Xunit;

namespace GradeBook.Test
{
    // Defining a delegate that allows us to handle logging messages
    public delegate string WrtieLogDelegate(string logMessage);

    public class TypeTest
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WrtieLogDelegate log;

            log = ReturnMessage;

            var result = log("Hello!");
            Assert.Equal("Hello!", result);

        }

        string ReturnMessage(string message)
        {
            return message;
        }

        [Fact]
        public void StringBehaveLikeValueType()
        {
            string name = "Sergi";
            var upper = MakeUppercase(name);
            
            Assert.Equal("SERGI", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesCanPassByReference()
        {   
            /*
            GetIntSetInt receive "x" as reference, therefore, it can be modified.
            */
            var x = GetInt();
            GetIntSetInt(ref x);
            
            Assert.Equal(42, x);
        }

        private void GetIntSetInt(ref object z)
        {
            z = 42;
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {   
            /*
            SetInt() will create a copy of x.
            */
            var x = GetInt();
            SetInt(x);
            
            Assert.Equal(3, x);
        }

        private void SetInt(object z)
        {
            z = 42;
        }

        private object GetInt()
        {   
            return 3;
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            /* 
            To be able to make changes we have to pass the object by reference. Remember: By defalut, 
                in C# elements are passed by value.

            In this case, we will not receive a copy of the value. We will receive, the value inside 
                the variable (a memory referece of where it is store).
            */

            // Arrange.
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New name");

            // Act.

            // Assert.
            Assert.Equal("New name", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
        
        [Fact]
        public void CSharpIsPassByValue()
        {
            /* 
            When we invoke GetBookSetName(), we made a copy of the value inside the variable book 1.
                
            When we pass a varible to another method, we do not wnat that other method to unexpectedly
                change the value or the reference inside the variable.

            In this case, GetBookSetName is creating a new book with the new name. It cannot reach book 1.

            To be able to make changes we have to pass the object by reference. Remember: By defalut, 
                in C# elements are passed by value (see mehtod above).
            */

            // Arrange.
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New name");

            // Act.

            // Assert.
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // Arrange.
            var book1 = GetBook("Book 1");
            SetName(book1, "New name");

            // Act.

            // Assert.
            Assert.Equal("New name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // Arrange.
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");            

            // Act.

            // Assert.
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void TwoVariablesCanReferenceTheSameObject()
        {
            // Arrange.
            var book1 = GetBook("Book 1");
            var book2 = book1;            

            // Act.

            // Assert.
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);

            Assert.Same(book1, book2);  //Equivalent to the two previous lines.
            Assert.True(Object.ReferenceEquals(book1, book2));  // Equivalent to the previous line.
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
