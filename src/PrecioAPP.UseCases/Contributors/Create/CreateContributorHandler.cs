using PrecioAPP.Core.ContributorAggregate;

namespace PrecioAPP.UseCases.Contributors.Create;

public class CreateBusinessHandler(IRepository<Contributor> _repository)
  : ICommandHandler<CreateBusinessCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateBusinessCommand request,
    CancellationToken cancellationToken)
  {
    var newContributor = new Contributor(request.Name);
    if (!string.IsNullOrEmpty(request.PhoneNumber))
    {
      newContributor.SetPhoneNumber(request.PhoneNumber);
    }
    var createdItem = await _repository.AddAsync(newContributor, cancellationToken);

    return createdItem.Id;
  }
}
