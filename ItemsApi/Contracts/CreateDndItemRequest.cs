using System.ComponentModel.DataAnnotations;

public class CreateDndItemRequest
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    public decimal? Value { get; set; }
    public decimal? Weight { get; set; }
    public string? Rarity { get; set; }
    public string? Type { get; set; }
    public List<string>? Properties { get; set; }

    public CreateDndItemRequest()
    {
        Properties = new List<string>();
    }
}