namespace PrecioAPP.UseCases.Products.Get;

public record GetProductQuery(int ProductId) : IQuery<Result<ProductDTO>>;
