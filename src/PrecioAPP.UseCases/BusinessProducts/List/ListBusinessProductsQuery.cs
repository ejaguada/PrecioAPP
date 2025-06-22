namespace PrecioAPP.UseCases.BusinessProducts.List;

public record ListBusinessProductsQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<BusinessProductDTO>>>;
