namespace PrecioAPP.UseCases.BusinessProducts.List;

public class ListBusinessProductsHandler(IListBusinessProductsQueryService _query)
  : IQueryHandler<ListBusinessProductsQuery, Result<IEnumerable<BusinessProductDTO>>>
{
  public async Task<Result<IEnumerable<BusinessProductDTO>>> Handle(ListBusinessProductsQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
