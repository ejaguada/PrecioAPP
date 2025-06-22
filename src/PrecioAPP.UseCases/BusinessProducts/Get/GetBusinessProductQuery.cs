namespace PrecioAPP.UseCases.BusinessProducts.Get;

public record GetBusinessProductQuery(int BusinessProductId) : IQuery<Result<BusinessProductDTO>>;
