using BiTrap.Dtos;

namespace BiTrap.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
       public string keyword { get; set; }
        public string CateId { get; set; }
    }
   
}
