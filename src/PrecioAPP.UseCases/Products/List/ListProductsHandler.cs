namespace PrecioAPP.UseCases.Products.List;

public class ListProductsHandler(IListProductsQueryService _query)
  : IQueryHandler<ListProductsQuery, Result<IEnumerable<ProductDTO>>>
{
  public async Task<Result<IEnumerable<ProductDTO>>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
