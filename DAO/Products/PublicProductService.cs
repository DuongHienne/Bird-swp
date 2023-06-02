
using Azure.Core;
using BiTrap.Catalog.Products;
using BiTrap.Dtos;
using BiTrap.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BiTrap.DAO.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly SwpContext _context;
        public PublicProductService(SwpContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            var query = from p in _context.TbProducts
                        join pc in _context.TbProductCategories on p.CateId equals pc.CateId
                        join s in _context.TbShops on p.ShopId equals s.ShopId

                      
                        select p;
            var data =  await query.Select(x => new ProductViewModel()
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
            return data;
          
        }

        public async Task<PageResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request)
        {
            //1.select join
            var query = from p in _context.TbProducts
                        join pc in _context.TbProductCategories on p.CateId equals pc.CateId
                        join s in _context.TbShops on p.ShopId equals s.ShopId

                        where p.CateId.Contains(request.CateId)

                        select p;
            //2.filter
            if (!string.IsNullOrEmpty(request.CateId))
            {
                query = query.Where(p => p.CateId == request.CateId);
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

       public async Task<PageResult<ProductViewModel>> GetAllByShopId(GetPublicProductInShopRequest request)
        {
            //1.select join
            var query = from p in _context.TbProducts
                        join pc in _context.TbProductCategories on p.CateId equals pc.CateId
                        join s in _context.TbShops on p.ShopId equals s.ShopId

                        where p.ShopId.Contains(request.ShopId)

                        select p;
            //2.filter
            if (!string.IsNullOrEmpty(request.ShopId))
            {
                query = query.Where(p => p.ShopId == request.ShopId);
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
    }
}

