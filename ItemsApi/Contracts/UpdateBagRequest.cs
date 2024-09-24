using System.ComponentModel.DataAnnotations;

namespace ItemsApi.Contracts
{
    public class UpdateBagRequest
    {
        [StringLength(100)]
        public string? Name { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        [Range(0, 5000)]
        public decimal? Capacity { get; set; }
    }
}