namespace PrecioAPP.Web.BusinessProducts;

public class GetBusinessProductByIdRequest
{
  public const string Route = "/BusinessProducts/{Id:int}";
  public static string BuildRoute(int id) => Route.Replace("{Id:int}", id.ToString());

  public int BusinessProductId { get; set; }
}
