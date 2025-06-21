using System.ComponentModel.DataAnnotations;

namespace PrecioAPP.Web.Products;

public class UpdateProductRequest
{
  public const string Route = "/Products/{ProductId:int}";
  public static string BuildRoute(int productId) => Route.Replace("{ProductId:int}", productId.ToString());

  public int ProductId { get; set; }
  public string? Name { get; set; }
  public string? Description { get; set; }
  public string? Barcode { get; set; }
  public string? Brand { get; set; }
  public string? ImageUrl { get; set; }
  public string? Unit { get; set; }
}
