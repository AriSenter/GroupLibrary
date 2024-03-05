using NUnit.Framework;
namespace TestLibrary
{

    public class Tests
    {
        [TestClass]
        public class UserLoginTests
        {
            [TestMethod]
            public void LoginWithValidCredentials_ShouldSucceed()
            {
                // Arrange
                var loginService = new login();
                var user = new User
                {
                    Login = "1",
                    Password = "1"
                };

                // Act
                var result = loginService.Login(user);

                // Assert
                Assert.IsTrue(result);
            }

            [TestMethod]
            public void LoginWithInvalidLogin_ShouldFail()
            {
                // Arrange
                var loginService = new LoginService();
                var user = new User
                {
                    Login = "invalid",
                    Password = "1"
                };

                // Act
                var result = loginService.Login(user);

                // Assert
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void LoginWithInvalidPassword_ShouldFail()
            {
                // Arrange
                var loginService = new LoginService();
                var user = new User
                {
                    Login = "1",
                    Password = "invalid"
                };

                // Act
                var result = loginService.Login(user);

                // Assert
                Assert.IsFalse(result);
            }
        }
        [TestClass]
        public class BookAddingTests
        {
            [TestMethod]
            public void AddBookWithValidData_ShouldSucceed()
            {
                // Arrange
                var bookService = new BookService();
                var book = new Book
                {
                    Title = "Test Book",
                    Author = "Test Author",
                    Genre = "Test Genre"
                };

                // Act
                var result = bookService.AddBook(book);

                // Assert
                Assert.IsTrue(result);
            }
            

            //Добавление книг

            [TestMethod]
            public void AddBookWithEmptyTitle_ShouldFail()
            {
                // Arrange
                var bookService = new BookService();
                var book = new Book
                {
                    Author = "Test Author",
                    Genre = "Test Genre"
                };

                // Act
                var result = bookService.AddBook(book);

                // Assert
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void AddBookWithEmptyAuthor_ShouldFail()
            {
                // Arrange
                var bookService = new BookService();
                var book = new Book
                {
                    Title = "Test Book",
                    Genre = "Test Genre"
                };

                // Act
                var result = bookService.AddBook(book);

                // Assert
                Assert.IsFalse(result);
            }
        }

        //Изменение книги
        [TestClass]
        public class BookEditingTests
        {
            [TestMethod]
            public void EditBookWithValidData_ShouldSucceed()
            {
                // Arrange
                var bookService = new BookService();
                var book = new Book
                {
                    Id = 1,
                    Title = "Test Book",
                    Author = "Test Author",
                    Genre = "Test Genre"
                };

                // Act
                var result = bookService.EditBook(book);

                // Assert
                Assert.IsTrue(result);
            }

            [TestMethod]
            public void EditBookWithEmptyTitle_ShouldFail()
            {
                // Arrange
                var bookService = new BookService();
                var book = new Book
                {
                    Id = 1,
                    Author = "Test Author",
                    Genre = "Test Genre"
                };

                // Act
                var result = bookService.EditBook(book);

                // Assert
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void EditBookWithEmptyAuthor_ShouldFail()
            {
                // Arrange
                var bookService = new BookService();
                var book = new Book
                {
                    Id = 1,
                    Title = "Test Book",
                    Genre = "Test Genre"
                };

                // Act
                var result = bookService.EditBook(book);

                // Assert
                Assert.IsFalse(result);
            }
        }


    }
}