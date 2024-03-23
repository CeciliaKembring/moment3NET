namespace Collection.Models {
    public class User{
        public int ID {get; set; } 
        public string? Name{ get; set; }
        public int? TelephoneNr { get; set; }
        public List<LoanedBooks>? LoanedBooks { get; set; }

    }
}