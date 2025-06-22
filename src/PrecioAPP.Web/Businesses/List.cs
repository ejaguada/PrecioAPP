using PrecioAPP.UseCases.Businesses;
using PrecioAPP.UseCases.Businesses.List;

namespace PrecioAPP.Web.Businesses;

/// <summary>
/// List all Businesses
/// </summary>
/// <remarks>
/// List all businesses - returns a BusinessListResponse containing the Businesses.
/// </remarks>
public class List(IMediator _mediator) : EndpointWithoutRequest<BusinessListResponse>
{
  public override void Configure()
  {
    Get("/Businesses");
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    Result<IEnumerable<BusinessDTO>> result = await _mediator.Send(new ListBusinessesQuery(null, null), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new BusinessListResponse
      {
        Businesses = result.Value.Select(c => new BusinessRecord(c.Id, c.Name, c.Description, c.Address, c.Longitude, c.Latitude, c.Email, c.Website, c.LogoURL)).ToList()
      };
    }
  }
}
