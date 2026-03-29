using System;

namespace Assignment5to7.Tests
{
    [TestFixture]
    public class BorrowingManagerTrackingTests
    {
        [Test]
        public void BorrowingManager_BorrowingItemsShouldHaveCorrectItems()
        {
            // Arrange
            var program = new Program();

            Book book1 = new Book("1984", "George Orwell", "978-9389647747");
            Book book2 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "978-0743273565");
            Book book3 = new Book("Coders at Work", "Peter Seibel", "978-1430219491");
            Magazine magazine1 = new Magazine("Tech Weekly", "Various", "9781625272531");

            Person kevin = new Person("Kevin", 12345);
            Person susan = new Person("Susan", 98765);

            Dictionary<string, LibraryItem> libraryItems = new Dictionary<string, LibraryItem>();
            libraryItems.Add(book1.ISBN, book1);
            libraryItems.Add(book2.ISBN, book2);
            libraryItems.Add(book3.ISBN, book3);
            libraryItems.Add(magazine1.ISBN, magazine1);

            BorrowingManager manager = new BorrowingManager();
            manager.BorrowItem(book1, kevin, DateTime.Now.AddDays(14));
            manager.BorrowItem(book3, susan, DateTime.Now.AddDays(-1));

            // Act
            List<LibraryItem> borrowedItems = manager.GetBorrowedItems(libraryItems);

            // Assert
            Assert.That(borrowedItems.Count, Is.EqualTo(2));
            Assert.IsTrue(borrowedItems.Contains(book1));
            Assert.IsTrue(borrowedItems.Contains(book3));
        }

        [Test]
        public void BorrowingManager_OverdueItemsShouldHaveCorrectItems()
        {
            // Arrange
            var program = new Program();

            Book book1 = new Book("1984", "George Orwell", "978-9389647747");
            Book book2 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "978-0743273565");
            Book book3 = new Book("Coders at Work", "Peter Seibel", "978-1430219491");
            Magazine magazine1 = new Magazine("Tech Weekly", "Various", "9781625272531");

            Person kevin = new Person("Kevin", 12345);
            Person susan = new Person("Susan", 98765);

            Dictionary<string, LibraryItem> libraryItems = new Dictionary<string, LibraryItem>();
            libraryItems.Add(book1.ISBN, book1);
            libraryItems.Add(book2.ISBN, book2);
            libraryItems.Add(book3.ISBN, book3);
            libraryItems.Add(magazine1.ISBN, magazine1);

            BorrowingManager manager = new BorrowingManager();
            manager.BorrowItem(book1, kevin, DateTime.Now.AddDays(14));
            manager.BorrowItem(book3, susan, DateTime.Now.AddDays(-1));

            // Act
            List<LibraryItem> overDueItems = manager.GetOverdueItems(libraryItems);

            // Assert
            Assert.That(overDueItems.Count, Is.EqualTo(1));
            Assert.IsTrue(overDueItems.Contains(book3));
        }
    }
}