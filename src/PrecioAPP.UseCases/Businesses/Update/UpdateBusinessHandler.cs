using PrecioAPP.Core.BusinessAggregate;

namespace PrecioAPP.UseCases.Businesses.Update;

public class UpdateBusinessHandler(IRepository<Business> _repository)
  : ICommandHandler<UpdateBusinessCommand, Result<BusinessDTO>>
{
  public async Task<Result<BusinessDTO>> Handle(UpdateBusinessCommand request, CancellationToken cancellationToken)
  {
    var existingBusiness = await _repository.GetByIdAsync(request.BusinessId, cancellationToken);
    if (existingBusiness == null)
    {
      return Result.NotFound();
    }

    existingBusiness.UpdateName(request.NewName!);
    existingBusiness.UpdateDescription(request.NewDescription!);
    existingBusiness.UpdateAddress(request.NewAddress!);
    existingBusiness.UpdateLongitude(request.NewLongitude);
    existingBusiness.UpdateLatitude(request.NewLatitude);
    existingBusiness.UpdateEmail(request.NewEmail!);
    existingBusiness.UpdateWebsite(request.NewWebsite!);
    existingBusiness.UpdateLogoURL(request.NewLogoURL!);

    await _repository.UpdateAsync(existingBusiness, cancellationToken);

    return new BusinessDTO(existingBusiness.Id,
      existingBusiness.Name, existingBusiness.Description, existingBusiness.Address, existingBusiness.Longitude, existingBusiness.Latitude, existingBusiness.Phone, existingBusiness.Email, existingBusiness.Website, existingBusiness.LogoURL);
  }
}
