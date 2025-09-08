namespace CatalogService.Application.Features.Queries.GetCatalogById.Response
{
    public class GetCatalogByIdQueryResponse
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public float Price { get; set; }
        public bool OnOrder { get; set; }
    }
}
