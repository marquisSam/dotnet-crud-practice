using System.ComponentModel.DataAnnotations;

namespace ItemsApi.Models
{
    public class DndItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Value { get; set; }
        public decimal? Weight { get; set; }
        public string? Rarity { get; set; }
        public string? Type { get; set; }
        public List<string>? Properties { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DndItem()
        {
            Properties = new List<string>();
        }
    }

    public class ErrorResponse
    {
        public string Title { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }


}