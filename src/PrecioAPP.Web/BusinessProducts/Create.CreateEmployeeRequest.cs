using System.ComponentModel.DataAnnotations;

namespace PrecioAPP.Web.BusinessProducts;

public class CreateBusinessProductRequest
{
  public const string Route = "/BusinessProducts";

  [Required]
  public int BusinessId { get; set; }
  public int ProductId { get; set; }
  public decimal CurrentPrice { get; set; }
  public decimal PreviousPrice { get; set; }
  public int Stock { get; set; }
  public bool IsAvailable { get; set; }
}
