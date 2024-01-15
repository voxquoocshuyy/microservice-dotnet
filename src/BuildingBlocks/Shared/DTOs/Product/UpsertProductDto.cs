using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs.Product;

public abstract class UpsertProductDto
{
    [Required]
    [MaxLength(250, ErrorMessage = "Product name cannot exceed 250 characters")]
    public string Name { get; set; }
    [Required]
    [MaxLength(50, ErrorMessage = "Product summary cannot exceed 50 characters")]
    public string Summay { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}