using System;

namespace Collection.Models 
{
    public class LoanedBooks
    {
        public int ID { get; set; } 
        public DateTime? LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
      
        public int? BookID { get; set; } 
        public Book? Book { get; set; } 
        public int? UserID { get; set; } 
        public User? User { get; set; } 
    }
}
