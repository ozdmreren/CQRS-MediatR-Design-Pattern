using CatalogService.Application.Features.Commands.CreateCatalog.Request;
using CatalogService.Application.Features.Commands.CreateCatalog.Response;
using CatalogService.Application.Features.Commands.DeleteCatalog.Request;
using CatalogService.Application.Features.Commands.DeleteCatalog.Response;
using CatalogService.Application.Features.Queries.GetAllCatalog.Response;
using CatalogService.Application.Features.Queries.GetAllCatalogById.Request;
using CatalogService.Application.Features.Queries.GetCatalogById.Request;
using CatalogService.Application.Features.Queries.GetCatalogById.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator mediator;

        public CatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("getall")]
        [ProducesResponseType(typeof(GetAllCatalogQueryResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync([FromQuery] GetAllCatalogQueryRequest request)
        {
            List<GetAllCatalogQueryResponse> allCatalogs = await mediator.Send(request);
            Console.WriteLine(typeof(GetAllCatalogQueryResponse).Assembly);
            return Ok(allCatalogs);
        }

        [HttpGet]
        [Route("getbyid")]
        [ProducesResponseType(typeof(GetCatalogByIdQueryResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync([FromQuery] GetCatalogByIdQueryRequest request)
        {
            GetCatalogByIdQueryResponse catalog = await mediator.Send(request);
            return Ok(catalog);
        }

        [HttpPost]
        [Route("post")]
        [ProducesResponseType(typeof(CreateCatalogCommandRequest), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] CreateCatalogCommandRequest request)
        {
            CreateCatalogCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(typeof(CreateCatalogCommandRequest), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromQuery] DeleteCatalogCommandRequest request)
        {
            DeleteCatalogCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
