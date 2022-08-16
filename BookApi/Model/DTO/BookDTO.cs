using BookApi.Model.Domain;

namespace BookApi.Model.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Autor { get; set; }
        public int? Year { get; set; }

        public int IdCategory { get; set; }
    }
}
