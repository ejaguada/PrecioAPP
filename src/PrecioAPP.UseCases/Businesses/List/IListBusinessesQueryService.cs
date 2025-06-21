namespace PrecioAPP.UseCases.Businesses.List;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListBusinessesQueryService
{
  Task<IEnumerable<BusinessDTO>> ListAsync();
}
