using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class BookDetail
    {
        [Key]
        public int Book_id { get; set; }  // Primary key

        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
       
    }
}
