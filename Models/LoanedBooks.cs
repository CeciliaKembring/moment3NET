using System;
using System.ComponentModel.DataAnnotations;


namespace Collection.Models 
{
    public class LoanedBooks
    {
        public int ID { get; set; } 
        [Display(Name = "Utlåningsdatum")]
        [Required]
        public DateTime? LoanDate { get; set; }
        [Display(Name = "Returdatum")]
        [Required]
        public DateTime? ReturnDate { get; set; }
      [Display(Name = "Bok")]
        public int? BookID { get; set; } 
        [Display(Name = "Bok")]
        public Book? Book { get; set; } 
        [Display(Name = "Användare")]
        public int? UserID { get; set; } 
        [Display(Name = "Användare")]
        public User? User { get; set; } 
    }
}
