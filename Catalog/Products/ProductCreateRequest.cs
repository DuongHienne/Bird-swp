namespace BiTrap.Catalog.Products
{
    public class ProductCreateRequest
    {
        public string Name { get; set; } = null!;

        public bool? Status { get; set; }

        public decimal Price { get; set; }

        public string? Decription { get; set; }

        public string? Detail { get; set; }



        public string? CateId { get; set; }

        public string? ShopId { get; set; }

        public int? Rate { get; set; }

        public byte[]? Video { get; set; }

        public byte[]? Image { get; set; }

    }
}
