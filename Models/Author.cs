using System.ComponentModel.DataAnnotations;

namespace Collection.Models {
    public class Author{
        public int ID {get; set; } 
        [Display(Name = "Namn")]
        [Required]
        public string? Name { get; set; }
        [Display(Name = "Biografi")]
        public string? Biography { get; set; }
        [Display(Name = "Nationalitet")]
        public string? Nationality {get; set; }
        public List<Book>? Book { get; set; }

    }
}