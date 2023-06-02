using BiTrap.Dtos;

namespace BiTrap.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public string CateId { get; set; }
       
    }
}
