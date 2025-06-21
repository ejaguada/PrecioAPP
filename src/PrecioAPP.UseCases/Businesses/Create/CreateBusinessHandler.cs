using PrecioAPP.Core.BusinessAggregate;

namespace PrecioAPP.UseCases.Businesses.Create;

public class CreateBusinessHandler(IRepository<Business> _repository)
  : ICommandHandler<CreateBusinessCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateBusinessCommand request,
    CancellationToken cancellationToken)
  {
    var newBusiness = new Business(request.Name, request.Description, request.Address, request.Longitude, request.Latitude, request.Phone, request.Email, request.Website, request.LogoURL);
    var createdItem = await _repository.AddAsync(newBusiness, cancellationToken);

    return createdItem.Id;
  }
}
