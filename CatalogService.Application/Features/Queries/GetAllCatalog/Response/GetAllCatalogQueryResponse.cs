namespace CatalogService.Application.Features.Queries.GetAllCatalog.Response
{
    public class GetAllCatalogQueryResponse
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public float Price { get; set; }
        public bool OnOrder { get; set; }
    }
}
