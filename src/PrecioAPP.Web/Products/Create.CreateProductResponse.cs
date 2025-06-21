using System.ComponentModel.DataAnnotations;

namespace PrecioAPP.Web.Products;

public class CreateProductResponse(int id, string name, string description, string barcode, string brand, string imageUrl, string unit)
{
  public int Id { get; set; } = id;
  public string Name { get; set; } = name;
  public string? Description { get; set; } = description;
  public string? Barcode { get; set; } = barcode;
  public string? Brand { get; set; } = brand;
  public string? ImageUrl { get; set; } = imageUrl;
  public string? Unit { get; set; } = unit;

}
