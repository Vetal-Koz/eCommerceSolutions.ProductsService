﻿namespace eCommerce.Core.DTO;

public class ProductResponse
{
    public Guid? ProductId { get; set; }
    public string? ProductName { get; set; }
    public string? Category { get; set; }
    public double? UnitPrice { get; set; }
    public int? QuantityInStock { get; set; }
}