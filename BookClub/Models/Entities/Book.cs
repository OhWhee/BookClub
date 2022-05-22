namespace BookClub.Models.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public List<BookUsers> BookUsers { get; set; }  
    }
}