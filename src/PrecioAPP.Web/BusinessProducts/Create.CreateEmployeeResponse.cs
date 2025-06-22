using System.ComponentModel.DataAnnotations;

namespace PrecioAPP.Web.BusinessProducts;

public class CreateBusinessProductResponse(int id, int businessId, int productId, decimal currentPrice, decimal previousPrice, int stock, bool isAvailable)
{
  public int Id { get; set; } = id;
  public int BusinessId { get; set; } = businessId;
  public int? ProductId { get; set; } = productId;
  public decimal? CurrentPrice { get; set; } = currentPrice;
  public decimal? PreviousPrice { get; set; } = previousPrice;
  public int? Stock { get; set; } = stock;
  public bool? IsAvailable { get; set; } = isAvailable;
}
