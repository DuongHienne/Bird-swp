using BiTrap.Dtos;

namespace BiTrap.Catalog.Products
{
    public class GetPublicProductInShopRequest : PagingRequestBase
    {
        public string ShopId { get; set; }
    }
}
