using PrecioAPP.Core.BusinessAggregate;
using PrecioAPP.Core.BusinessAggregate.Specifications;

namespace PrecioAPP.UseCases.Businesses.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetBusinessHandler(IReadRepository<Business> _repository)
  : IQueryHandler<GetBusinessQuery, Result<BusinessDTO>>
{
  public async Task<Result<BusinessDTO>> Handle(GetBusinessQuery request, CancellationToken cancellationToken)
  {
    var spec = new BusinessByIdSpec(request.BusinessId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new BusinessDTO(entity.Id, entity.Name, entity.Description, entity.Address, entity.Longitude, entity.Latitude, entity.Phone, entity.Email, entity.Website, entity.LogoURL);
  }
}
