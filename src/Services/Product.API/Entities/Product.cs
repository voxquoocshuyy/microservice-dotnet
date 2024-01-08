using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.API.Entities;

public class Product
{
    public long Id { get; set; }
    
    [Required]
    [Column(TypeName = "nvarchar(250)")]
    public string No { get; set; }
    
    [Required]
    [Column(TypeName = "nvarchar(250)")]
    public string Name { get; set; }
    
    [Column(TypeName = "nvarchar(max)")]
    public string Summary { get; set; }
    
    [Column(TypeName = "nvarchar(250)")]
    public string Description { get; set; }
    
    public decimal Price { get; set; }
}