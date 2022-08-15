using System.ComponentModel.DataAnnotations;

namespace BookApi.Model.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
