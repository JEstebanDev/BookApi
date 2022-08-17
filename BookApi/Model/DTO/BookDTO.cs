
namespace BookApi.Model.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Editorial { get; set; }
        public string? Autor { get; set; }
        public int? Year { get; set; }
        public int? Pages { get; set; }
        public int? CategoryId { get; set; }
    }
}
