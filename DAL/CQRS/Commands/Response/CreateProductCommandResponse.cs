namespace DAL.CQRS.Commands.Response
{
    public class CreateProductCommandResponse
    {
        public bool IsSucceeded { get; set; }
        public Guid ProductId { get; set; }
    }
}
