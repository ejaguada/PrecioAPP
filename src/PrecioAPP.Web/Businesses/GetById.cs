using PrecioAPP.UseCases.Businesses.Get;

namespace PrecioAPP.Web.Businesses;

/// <summary>
/// Get a Business by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching Business record.
/// </remarks>
public class GetById(IMediator _mediator)
  : Endpoint<GetBusinessByIdRequest, BusinessRecord>
{
  public override void Configure()
  {
    Get(GetBusinessByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetBusinessByIdRequest request,
    CancellationToken cancellationToken)
  {
    var query = new GetBusinessQuery(request.BusinessId);

    var result = await _mediator.Send(query, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new BusinessRecord(result.Value.Id, result.Value.Name, result.Value.Description,result.Value.Address,result.Value.Longitude,result.Value.Latitude,result.Value.Email,result.Value.Website,result.Value.LogoURL);
    }
  }
}
