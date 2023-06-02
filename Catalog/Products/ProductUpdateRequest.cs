namespace BiTrap.Catalog.Products
{
    public class ProductUpdateRequest
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Decription { get; set; }

        public string? Detail { get; set; }
        public byte[]? Video { get; set; }

        public byte[]? Image { get; set; }


    }
}
