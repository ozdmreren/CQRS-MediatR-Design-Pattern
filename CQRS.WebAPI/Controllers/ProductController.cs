using DAL.CQRS.Commands.Request;
using DAL.CQRS.Commands.Response;
using DAL.CQRS.Handlers.CommandHandlers;
using DAL.CQRS.Handlers.QueryHandlers;
using DAL.CQRS.Queries.Request;
using DAL.CQRS.Queries.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CQRS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        CreateProductCommandHandlers createProductCommandHandler;
        DeleteProductCommandHandler deleteProductCommandHandler;
        GetAllProductQueryHandler getAllProductQueryHandler;
        GetByIdProductQueryHandler getByIdProductQueryHandler;

        public ProductController(CreateProductCommandHandlers createProductCommandHandler, DeleteProductCommandHandler deleteProductCommandHandler, GetAllProductQueryHandler getAllProductQueryHandler, GetByIdProductQueryHandler getByIdProductQueryHandler)
        {
            this.createProductCommandHandler = createProductCommandHandler;
            this.deleteProductCommandHandler = deleteProductCommandHandler;
            this.getAllProductQueryHandler = getAllProductQueryHandler;
            this.getByIdProductQueryHandler = getByIdProductQueryHandler;
        }

        [HttpGet]
        [Route("getall")]
        [ProducesResponseType(typeof(GetAllProductQueryResponse), (int)HttpStatusCode.OK)]
        public IActionResult Get([FromQuery] GetAllProductQueryRequest request)
        {
            List<GetAllProductQueryResponse> products = getAllProductQueryHandler.GetAllProduct(request);

            return Ok(products);
        }

        [HttpGet]
        [Route("get")]
        [ProducesResponseType(typeof(GetByIdProductQueryResponse), (int)HttpStatusCode.OK)]
        public IActionResult Get([FromQuery] GetByIdProductQueryRequest request)
        {
            GetByIdProductQueryResponse entity = getByIdProductQueryHandler.GetProductById(request);

            return Ok(entity);
        }

        [HttpPost]
        [Route("postproduct")]
        [ProducesResponseType(typeof(CreateProductCommandResponse), (int)HttpStatusCode.OK)]
        public IActionResult Store([FromBody] CreateProductCommandRequest request)
        {
            CreateProductCommandResponse createdProduct = createProductCommandHandler.CreateProduct(request);

            return Ok(createdProduct);
        }

        [HttpDelete]
        [Route("deleteproduct")]
        [ProducesResponseType(typeof(DeleteProductCommandResponse), (int)HttpStatusCode.OK)]
        public IActionResult Remove([FromQuery] DeleteProductCommandRequest request)
        {
            DeleteProductCommandResponse result = deleteProductCommandHandler.DeleteProduct(request);

            return Ok(result);
        }
    }
}
