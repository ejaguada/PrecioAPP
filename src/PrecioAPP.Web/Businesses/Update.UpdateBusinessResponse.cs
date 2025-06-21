namespace PrecioAPP.Web.Businesses;

public class UpdateBusinessResponse(BusinessRecord business)
{
  public BusinessRecord Business { get; set; } = business;
}
