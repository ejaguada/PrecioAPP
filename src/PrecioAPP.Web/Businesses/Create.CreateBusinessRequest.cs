using System.ComponentModel.DataAnnotations;

namespace PrecioAPP.Web.Businesses;

public class CreateBusinessRequest
{
  public const string Route = "/Businesses";

  [Required]
  public string? Name { get; set; }
  public string? Description { get; set; }
  public string? Address { get; set; }
  public string? Email { get; set; }
  public string? Website { get; set; }
  public string? LogoURL { get; set; }
  public int Latitude { get; set; }
  public int Longitude { get; set; }
  public string? Phone { get; set; }

}
