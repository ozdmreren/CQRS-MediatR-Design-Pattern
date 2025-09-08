using System;

public class CreateProductCommandRequest
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public float UnitPrice { get; set; }
}