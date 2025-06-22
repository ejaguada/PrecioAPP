using PrecioAPP.UseCases.BusinessProducts;

namespace PrecioAPP.Web.BusinessProducts;

public class BusinessProductListResponse
{
  public List<BusinessProductRecord> BusinessProducts { get; set; } = new();
}
