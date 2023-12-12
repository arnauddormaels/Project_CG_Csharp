using CG.API.Mappers;
using CG.API.Model.Input;
using CG.API.Model.Output;
using CG.BL.Models;
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
                return Ok(mapToDTO.MapProducs(manager.GetProducts()));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }
        }

        //GetProductByID
        [HttpGet("({productId})")]
        public ActionResult<ProductRESToutputDTO> GetProductById(int productId)
        {
            try
            {
                return mapToDTO.MapFromProductDomain(manager.GetProductById(productId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }
        }

        //AddProduct
        [HttpPost]
        public ActionResult<ProductRESTinputDTO> AddProduct([FromBody] ProductRESTinputDTO productInputDTO)
        {
            try
            {
                Product product = mapFromDTO.MapToDomainProduct(productInputDTO);
                //dit werkt alleen als de manager de aangemaakte object terug geeft zo kan je de id toeveogen!
                manager.AddProduct(product);
                return CreatedAtAction(nameof(GetProductById), new {productId = product.ProductId},productInputDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        //uitbreiding!
        //UpdateProduct
        //DeleteProduct

    }
}
