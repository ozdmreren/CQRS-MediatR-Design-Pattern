namespace DAL.CQRS.Queries.Response
{
    public class GetAllProductQueryResponse
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
