namespace PrecioAPP.Web.Businesses;

public class GetBusinessByIdRequest
{
  public const string Route = "/Businesses/{BusinessId:int}";
  public static string BuildRoute(int businessId) => Route.Replace("{BusinessId:int}", businessId.ToString());

  public int BusinessId { get; set; }
}
