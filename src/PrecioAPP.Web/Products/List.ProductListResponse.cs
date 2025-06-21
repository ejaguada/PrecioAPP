using PrecioAPP.UseCases.Products;

namespace PrecioAPP.Web.Products;

public class ProductListResponse
{
  public List<ProductRecord> Products { get; set; } = new();
}
