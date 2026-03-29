using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Assignment5to7
{
    public class BorrowingRecord
    {
        public Person Borrower { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; } = null;

        public BorrowingRecord(Person borrower, DateTime borrowDate, DateTime dueDate)
        {
            Borrower = borrower;
            BorrowDate = borrowDate;
            DueDate = dueDate;
        }
    }
}
