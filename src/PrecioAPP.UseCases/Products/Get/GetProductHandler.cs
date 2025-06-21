using PrecioAPP.Core.ProductAggregate;
using PrecioAPP.Core.ProductAggregate.Specifications;

namespace PrecioAPP.UseCases.Products.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetProductHandler(IReadRepository<Product> _repository)
  : IQueryHandler<GetProductQuery, Result<ProductDTO>>
{
  public async Task<Result<ProductDTO>> Handle(GetProductQuery request, CancellationToken cancellationToken)
  {
    var spec = new ProductByIdSpec(request.ProductId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new ProductDTO(entity.Id, entity.Name, entity.Description, entity.Barcode, entity.Brand, entity.ImageUrl, entity.Unit);
  }
}
