namespace PrecioAPP.UseCases.BusinessProducts.List;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListBusinessProductsQueryService
{
  Task<IEnumerable<BusinessProductDTO>> ListAsync();
}
