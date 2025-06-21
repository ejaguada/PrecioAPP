namespace PrecioAPP.Core.BusinessAggregate.Specifications;

public class BusinessByIdSpec : Specification<Business>
{
  public BusinessByIdSpec(int businessId) =>
    Query
        .Where(business => business.Id == businessId);
}
