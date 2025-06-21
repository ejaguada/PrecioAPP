namespace PrecioAPP.UseCases.Products.List;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListProductsQueryService
{
  Task<IEnumerable<ProductDTO>> ListAsync();
}
