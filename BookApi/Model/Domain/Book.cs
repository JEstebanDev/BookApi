using System.ComponentModel.DataAnnotations.Schema;

namespace BookApi.Model.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Editorial { get; set; }
        public string? Autor { get; set; }
        public int? Year { get; set; }
        public int? Pages { get; set; }

        public virtual Category Category { get; set; }
    }
}
