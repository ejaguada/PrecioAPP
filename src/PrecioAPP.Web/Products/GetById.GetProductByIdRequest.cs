namespace PrecioAPP.Web.Products;

public class GetProductByIdRequest
{
  public const string Route = "/Products/{Id:int}";
  public static string BuildRoute(int id) => Route.Replace("{Id:int}", id.ToString());

  public int ProductId { get; set; }
}
