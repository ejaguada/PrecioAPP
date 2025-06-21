using PrecioAPP.Core.ProductAggregate;

namespace PrecioAPP.UseCases.Products.Update;

public class UpdateProductHandler(IRepository<Product> _repository)
  : ICommandHandler<UpdateProductCommand, Result<ProductDTO>>
{
  public async Task<Result<ProductDTO>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
  {
    var existingProduct = await _repository.GetByIdAsync(request.ProductId, cancellationToken);
    if (existingProduct == null)
    {
      return Result.NotFound();
    }

    existingProduct.UpdateName(request.NewName!);
    existingProduct.UpdateDescription(request.NewDescription!);
    existingProduct.UpdateBarcode(request.NewBarcode!);
    existingProduct.UpdateBrand(request.NewBrand!);
    existingProduct.UpdateImageUrl(request.NewImageUrl!);
    existingProduct.UpdateUnit(request.NewUnit!);

    await _repository.UpdateAsync(existingProduct, cancellationToken);

    return new ProductDTO(existingProduct.Id,
      existingProduct.Name, existingProduct.Description, existingProduct.Barcode, existingProduct.Brand, existingProduct.ImageUrl, existingProduct.Unit);
  }
}
