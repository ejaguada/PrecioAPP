using PrecioAPP.Core.BusinessProductAggregate;
using PrecioAPP.Core.BusinessProductAggregate.Specifications;

namespace PrecioAPP.UseCases.BusinessProducts.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetBusinessProductHandler(IReadRepository<BusinessProduct> _repository)
  : IQueryHandler<GetBusinessProductQuery, Result<BusinessProductDTO>>
{
  public async Task<Result<BusinessProductDTO>> Handle(GetBusinessProductQuery request, CancellationToken cancellationToken)
  {
    var spec = new BusinessProductByIdSpec(request.BusinessProductId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new BusinessProductDTO(entity.Id, entity.BusinessId, entity.ProductId, entity.CurrentPrice, entity.PreviousPrice, entity.Stock, entity.IsAvailable);
  }
}
