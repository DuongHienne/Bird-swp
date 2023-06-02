using BiTrap.Catalog.Products;
using BiTrap.Dtos;


namespace BiTrap.DAO.Products
{
    public interface IPublicProductService
    {
        Task<PageResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);

        Task<List<ProductViewModel>> GetAll();

        Task<PageResult<ProductViewModel>> GetAllByShopId(GetPublicProductInShopRequest request);

    }
}
