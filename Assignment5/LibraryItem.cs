using System;
using System.Collections.Generic;

namespace Assignment5to7
{
    public abstract class LibraryItem : IBorrowable
    {
        public string Title { get; }
        public string Author { get; }
        public string ISBN { get; }
        public bool IsBorrowed { get; private set; }

        public List<BorrowingRecord> BorrowingHistory { get; }

        public LibraryItem(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsBorrowed = false;
            BorrowingHistory = new List<BorrowingRecord>();
        }

        public void Borrow()
        {
            IsBorrowed = true;
        }

        public void Return()
        {
            IsBorrowed = false;
        }

        public Person GetCurrentBorrower()
        {
            if (BorrowingHistory.Count == 0)
                return null;
            return BorrowingHistory[BorrowingHistory.Count - 1].Borrower;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Borrowed: {IsBorrowed}";
        }
    }
}
