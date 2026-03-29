using System;

namespace Assignment5to7
{
    public class BorrowingManager
    {
        public void BorrowItem(LibraryItem item, Person person, DateTime dueDate)
        {
            Console.WriteLine($"Borrowing Item with ISBN {item.ISBN} by {person}. Due date: {dueDate:dd-MM-yyyy}.");
            item.Borrow();
            item.BorrowingHistory.Add(new BorrowingRecord(person, DateTime.Now, dueDate));
        }

        public void ReturnItem(LibraryItem item)
        {
            Console.WriteLine($"Returning Item with ISBN {item.ISBN}.");
            item.Return();
        }
        public List<LibraryItem> GetBorrowedItems(Dictionary<string, LibraryItem> items)
        {
            return items.Values.Where(item => item.IsBorrowed).ToList();
        }

        public List<LibraryItem> GetOverdueItems(Dictionary<string, LibraryItem> items)
        {
            DateTime now = DateTime.Now;
            return items.Values
           .Where(item => item.IsBorrowed && item.BorrowingHistory.Count > 0 &&
            item.BorrowingHistory.Last().DueDate < now).ToList();
        }

    }
}

