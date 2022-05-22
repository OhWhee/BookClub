using System.ComponentModel.DataAnnotations.Schema;

namespace BookClub.Models.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Name { get; set; }
        public List<BookUsers> BookUsers { get; set; }

    }
}