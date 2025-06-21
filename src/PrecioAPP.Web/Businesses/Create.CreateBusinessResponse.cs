using System.ComponentModel.DataAnnotations;

namespace PrecioAPP.Web.Businesses;

public class CreateBusinessResponse(int id, string name, string? description, string? address, string? email, string? website, string? logoURL, int latitude, int longitude)
{
  public int Id { get; set; } = id;
  public string? Name { get; set; } = name;
  public string? Description { get; set; } = description;
  public string? Address { get; set; } = address;
  public string? Email { get; set; } = email;
  public string? Website { get; set; } = website;
  public string? LogoURL { get; set; } = logoURL;
  public int Latitude { get; set; } = latitude;
  public int Longitude { get; set; } = longitude;

}
