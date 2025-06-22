using System.ComponentModel.DataAnnotations;

namespace PrecioAPP.Web.BusinessProducts;

public class UpdateBusinessProductRequest
{
  public const string Route = "/BusinessProducts/{BusinessProductId:int}";
  public static string BuildRoute(int businessProductId) => Route.Replace("{BusinessProductId:int}", businessProductId.ToString());

  public int BusinessProductId { get; set; }

  public int BusinessId { get; set; }

  public int ProductId { get; set; }

  public decimal CurrentPrice { get; set; }

  public decimal PreviousPrice { get; set; }

  public int Stock { get; set; }

  public bool IsAvailable { get; set; }
}
