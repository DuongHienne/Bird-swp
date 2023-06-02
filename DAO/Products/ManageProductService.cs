using Azure.Core;
using BiTrap.Catalog.Products;
using BiTrap.Dtos;
using BiTrap.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using static System.Net.Mime.MediaTypeNames;

namespace BiTrap.DAO.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly SwpContext _context;
        public ManageProductService(SwpContext context)
        {
            _context = context;
        }
        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new TbProduct()
            {
                Name = request.Name,
                Status = request.Status,
                Price = request.Price,
                Decription = request.Decription,
                Detail = request.Detail,

                CateId = request.CateId,
                ShopId = request.ShopId,
                Rate = request.Rate,
                Video = request.Video,
                Image = request.Image,

            };
            _context.TbProducts.Add(product);
            await _context.SaveChangesAsync();
            return product.ProductId;
           
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.TbProducts.FindAsync(productId);
            if (product == null) throw new Exception("Cannot find a product with id");


            _context.TbProducts.Remove(product);
            return await _context.SaveChangesAsync();

        }



        public async Task<PageResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            //1.select join
            var query = from p in _context.TbProducts
                        join pc in _context.TbProductCategories on p.CateId equals pc.CateId
                        join s in _context.TbShops on p.ShopId equals s.ShopId

                        where p.Name.Contains(request.keyword)

                        select p;
            //2.filter
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.Name.Contains(request.keyword));
            if (!string.IsNullOrEmpty(request.CateId))
            {
                query = query.Where(p => request.CateId.Contains(p.CateId));
            }
            //3.paging
            int totalRow = await query.CountAsync();
            var data = query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(x => new ProductViewModel()
            {
                ProductId = x.ProductId,
                Name = x.Name,
                Status = x.Status,
                Price = x.Price,
                Decription = x.Decription,
                Detail = x.Detail,
                QuantitySold = x.QuantitySold,
                Rate = x.Rate,
                Video = x.Video,
                Image = x.Image,
            }).ToListAsync();

            //4. select and projection
            var pageResult = new PageResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = await data
            };
            return pageResult;
        }

        

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.TbProducts.FindAsync(request.ProductId);
            if (product == null) throw new Exception($"Not find a product with id:{request.ProductId}");
            product.Name = request.Name;
            product.Decription = request.Decription;
            product.Detail = request.Detail;
            product.Video = request.Video;
            product.Image = request.Image;
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.TbProducts.FindAsync(productId);
            if (product == null) throw new Exception($"Not find a product with id:{productId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateQuantitySold(int productId, int addedQuantity)
        {

            var product = await _context.TbProducts.FindAsync(productId);
            if (product == null) throw new Exception($"Not find a product with id:{productId}");
            product.QuantitySold += addedQuantity;
            return await _context.SaveChangesAsync() > 0;

        }

        public  async Task<ProductViewModel> GetById(int id)
        {
           var product = await _context.TbProducts.FindAsync(id);
           
            var productViewModel = new ProductViewModel()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Status = product.Status,
                Price = product.Price,
                Decription = product.Decription,
                Detail = product.Detail,
                QuantitySold = product.QuantitySold,
                Rate = product.Rate,
                Video = product.Video,
                Image = product.Image,

            };

           return productViewModel;
            
        }
    }
}
