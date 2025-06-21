namespace PrecioAPP.UseCases.Businesses.Get;

public record GetBusinessQuery(int BusinessId) : IQuery<Result<BusinessDTO>>;
