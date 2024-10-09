using System.ComponentModel.DataAnnotations;

namespace ItemsApi.Models
{
    public class Bag
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public List<Guid> Content { get; set; }
        [Range(0, 5000)]
        public decimal? Capacity { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Bag()
        {
            Content = new List<Guid>();
        }
    }

    public class BagErrorResponse
    {
        public string? Title { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}