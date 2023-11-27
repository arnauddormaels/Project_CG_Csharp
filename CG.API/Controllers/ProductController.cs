using CG.API.Mappers;
using CG.API.Model.Input;
using CG.API.Model.Output;
using CollectAndGO.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private DomainManager manager;
        private MapFromDTO mapFromDTO;
        private MapToDTO mapToDTO;
        public ProductController(DomainManager manager, MapFromDTO mapFromDTO, MapToDTO mapToDTO)
        {
            this.manager = manager;
            this.mapFromDTO = mapFromDTO;
            this.mapToDTO = mapToDTO;
        }

        //GetAllProduct
        [HttpGet]
        public ActionResult<List<ProductRESToutputDTO>> GetAllProduct()
        {
            try
            {
                return mapToDTO.MapProducs(manager.GetProducts());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }
        }

        //GetProductByID


        //AddProduct
        [HttpPost]
        public ActionResult<ProductRESTinputDTO> AddProduct(ProductRESTinputDTO productInputDTO)
        {
            try
            {
                manager.addProduct(mapFromDTO.MapToDomainProduct(productInputDTO));
                return productInputDTO;
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }
        }

        //UpdateProduct
        //DeleteProduct

        //GetALLBrandProduct
        [HttpGet("({productId})")]
        public ActionResult<List<BrandProductRESToutputDTO>> GetAllBrandProductOfProduct(int productId)
        {
            try
            {
                return mapToDTO.MapBrandProducts(manager.GetBrandProducts(productId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }
        }
    }
}
