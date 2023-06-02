using BiTrap.Catalog.Products;

namespace BiTrap.Dtos
{
    public class PageResult<T>
    {
        public List<T> Items { set; get; }
        public int TotalRecord { set; get; }

        public static implicit operator PageResult<T>(PageResult<ProductViewModel> v)
        {
            throw new NotImplementedException();
        }
    }
}
