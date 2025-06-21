namespace PrecioAPP.UseCases.Products.List;

public record ListProductsQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<ProductDTO>>>;
