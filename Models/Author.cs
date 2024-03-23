namespace Collection.Models {
    public class Author{
        public int ID {get; set; } 
        public string? Name { get; set; }
        public string? Biography { get; set; }
        public string? Nationality {get; set; }
        public List<Book>? Book { get; set; }

    }
}