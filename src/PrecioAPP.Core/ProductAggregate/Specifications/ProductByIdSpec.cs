namespace PrecioAPP.Core.ProductAggregate.Specifications;

public class ProductByIdSpec : Specification<Product>
{
  public ProductByIdSpec(int productId) =>
    Query
        .Where(product => product.Id == productId);
}
