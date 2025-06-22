namespace PrecioAPP.Core.BusinessProductAggregate.Specifications;

public class BusinessProductByIdSpec : Specification<BusinessProduct>
{
  public BusinessProductByIdSpec(int businessProductId) =>
    Query
        .Where(businessProduct => businessProduct.Id == businessProductId);
}
