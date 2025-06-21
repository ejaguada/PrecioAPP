using PrecioAPP.Core.ProductAggregate;

namespace PrecioAPP.UseCases.Products.Create;

public class CreateProductHandler(IRepository<Product> _repository)
  : ICommandHandler<CreateProductCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateProductCommand request,
    CancellationToken cancellationToken)
  {
    var newProduct = new Product(request.Name, request.Description, request.Barcode, request.Brand, request.ImageUrl, request.Unit);
    var createdItem = await _repository.AddAsync(newProduct, cancellationToken);

    return createdItem.Id;
  }
}
