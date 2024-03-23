using System.ComponentModel.DataAnnotations;
namespace Collection.Models {
    public class User{
        public int ID {get; set; } 
        [Display(Name = "Namn")]
        [Required]
        public string? Name{ get; set; }
        [Display(Name = "Telefonnummer")]
        public int? TelephoneNr { get; set; }
        public List<LoanedBooks>? LoanedBooks { get; set; }

    }
}