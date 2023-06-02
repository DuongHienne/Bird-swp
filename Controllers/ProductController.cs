using BiTrap.Catalog.Products;
using BiTrap.DAO.Products;
using BiTrap.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiTrap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IPublicProductService _publicProductService;
        private readonly SwpContext _context;
        private readonly IManageProductService _manageproductService;
        public ProductController(SwpContext ctx, IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _context = ctx;
            _publicProductService = publicProductService;
            _manageproductService = manageProductService;
        }


        

        [HttpGet]
        [Route("productId")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _manageproductService.GetById(id);
            if (product == null)

                return BadRequest("Cannot find product");
            return Ok(product);


        }

        [HttpPost]
        [Route("AddProduct")]

        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _manageproductService.Create(request);
            if (productId == 0)
                return BadRequest();

            var product = await _manageproductService.GetById(productId);

            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAll()
        {
            var product = await _publicProductService.GetAll();
            return Ok(product);
        }


        [HttpGet]
        [Route("public-paging-cateId")]
        public async Task<IActionResult> Get([FromQuery] GetPublicProductPagingRequest request)
        {
            var product = await _publicProductService.GetAllByCategoryId(request);
            return Ok(product);
        }
        
        [HttpGet]
        [Route("public-paging-shopId")]
        public async Task<IActionResult> GetByShopId([FromQuery] GetPublicProductInShopRequest request)
        {
            var product = await _publicProductService.GetAllByShopId(request);
            return Ok(product);
        }


        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> Update([FromBody] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _manageproductService.Update(request);
            if (affectedResult == 0)
                return BadRequest();



            return Ok();
        }

        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _manageproductService.Delete(id);
            if (affectedResult == 0)
                return BadRequest();



            return Ok();
        }

        [HttpPut]
        [Route("UpdatePrice")]
        public async Task<IActionResult> UpdatePrice([FromQuery] int id, decimal newPrice )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageproductService.UpdatePrice(id, newPrice);
            if (result)
                return Ok();
            return BadRequest();



            
        }

    }
}


    
