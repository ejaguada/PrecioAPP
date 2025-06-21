using System.ComponentModel.DataAnnotations;

namespace PrecioAPP.Web.Businesses;

public class UpdateBusinessRequest
{
  public const string Route = "/Businesses/{BusinessId:int}";
  public static string BuildRoute(int businessId) => Route.Replace("{BusinessId:int}", businessId.ToString());

  public int BusinessId { get; set; }
  public string? Name { get; set; }
  public string? Description { get; set; }
  public string? Address { get; set; }
  public string? Email { get; set; }
  public string? Website { get; set; }
  public string? LogoURL { get; set; }
  public int Latitude { get; set; }
  public int Longitude { get; set; }
}
