using System.ComponentModel.DataAnnotations;

namespace Collection.Models {
    public class Book{
        public int ID {get; set; } 
        [Required]
        [Display(Name = "Titel")]
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int? AuthorID {get; set; }
        [Display(Name = "Författare")]
         public Author? Author {get; set; }
         public string? Status { get; set; } 
         public List<LoanedBooks>? LoanedBooks { get; set; }

    }
    }