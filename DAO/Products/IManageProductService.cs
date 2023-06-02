using BiTrap.Catalog.Products;
using BiTrap.Dtos;

namespace BiTrap.DAO.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);
        Task<ProductViewModel> GetById(int id);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateQuantitySold(int productId, int addedQuantity);
        Task<int> Delete(int productId);
        Task<PageResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

       

    }
}
