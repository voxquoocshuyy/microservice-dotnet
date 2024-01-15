namespace Shared.DTOs.Product;

public class CreateProductDto : UpsertProductDto
{
    public string No { get; set; }
}