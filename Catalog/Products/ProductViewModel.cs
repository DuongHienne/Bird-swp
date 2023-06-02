namespace BiTrap.Catalog.Products;

public class ProductViewModel
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public bool? Status { get; set; }

    public decimal Price { get; set; }

    public string? Decription { get; set; }

    public string? Detail { get; set; }

    public int? QuantitySold { get; set; }

    public int? Rate { get; set; }

    public byte[]? Video { get; set; }

    public byte[]? Image { get; set; }


}
