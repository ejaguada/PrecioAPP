namespace PrecioAPP.Web.BusinessProducts;

public class UpdateBusinessProductResponse(BusinessProductRecord businessProduct)
{
  public BusinessProductRecord BusinessProduct { get; set; } = businessProduct;
}
