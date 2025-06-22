using PrecioAPP.Core.BusinessProductAggregate;

namespace PrecioAPP.UseCases.BusinessProducts.Create;

public class CreateBusinessProductHandler(IRepository<BusinessProduct> _repository)
  : ICommandHandler<CreateBusinessProductCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateBusinessProductCommand request,
    CancellationToken cancellationToken)
  {
    var newBusinessProduct = new BusinessProduct(request.BusinessId, request.ProductId, request.CurrentPrice, request.PreviousPrice, request.Stock, request.IsAvailable);
    var createdItem = await _repository.AddAsync(newBusinessProduct, cancellationToken);

    return createdItem.Id;
  }
}
