namespace PrecioAPP.UseCases.Businesses.List;

public class ListBusinessesHandler(IListBusinessesQueryService _query)
  : IQueryHandler<ListBusinessesQuery, Result<IEnumerable<BusinessDTO>>>
{
  public async Task<Result<IEnumerable<BusinessDTO>>> Handle(ListBusinessesQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
