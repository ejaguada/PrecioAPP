using PrecioAPP.Core.BusinessProductAggregate;

namespace PrecioAPP.UseCases.BusinessProducts.Update;

public class UpdateBusinessProductHandler(IRepository<BusinessProduct> _repository)
  : ICommandHandler<UpdateBusinessProductCommand, Result<BusinessProductDTO>>
{
  public async Task<Result<BusinessProductDTO>> Handle(UpdateBusinessProductCommand request, CancellationToken cancellationToken)
  {
    var existingBusinessProduct = await _repository.GetByIdAsync(request.BusinessProductId, cancellationToken);
    if (existingBusinessProduct == null)
    {
      return Result.NotFound();
    }

    existingBusinessProduct.UpdateProductId(request.NewProductId);
    existingBusinessProduct.UpdateCurrentPrice(request.NewCurrentPrice);
    existingBusinessProduct.UpdatePreviousPrice(request.NewPreviousPrice);
    existingBusinessProduct.UpdateStock(request.NewStock);
    existingBusinessProduct.UpdateIsAvailable(request.NewIsAvailable);

    await _repository.UpdateAsync(existingBusinessProduct, cancellationToken);
    return new BusinessProductDTO(existingBusinessProduct.Id,
      existingBusinessProduct.BusinessId, existingBusinessProduct.ProductId, existingBusinessProduct.CurrentPrice, existingBusinessProduct.PreviousPrice, existingBusinessProduct.Stock, existingBusinessProduct.IsAvailable);
  }
}
