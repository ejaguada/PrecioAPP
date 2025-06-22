using PrecioAPP.UseCases.Businesses.Get;
using PrecioAPP.UseCases.Businesses.Update;

namespace PrecioAPP.Web.Businesses;

/// <summary>
/// Update an existing Business.
/// </summary>
/// <remarks>
/// Update an existing Business by providing a fully defined replacement set of values.
/// See: https://stackoverflow.com/questions/60761955/rest-update-best-practice-put-collection-id-without-id-in-body-vs-put-collecti
/// </remarks>
public class Update(IMediator _mediator)
  : Endpoint<UpdateBusinessRequest, UpdateBusinessResponse>
{
  public override void Configure()
  {
    Put(UpdateBusinessRequest.Route);
  }

  public override async Task HandleAsync(
    UpdateBusinessRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateBusinessCommand(request.BusinessId, request.Name!, request.Description!, request.Address!, request.Longitude, request.Latitude, request.Email!, request.Website!, request.LogoURL!), cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetBusinessQuery(request.BusinessId);

    var queryResult = await _mediator.Send(query, cancellationToken);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateBusinessResponse(new BusinessRecord(dto.Id, dto.Name, dto.Description, dto.Address, dto.Longitude, dto.Latitude, dto.Email, dto.Website, dto.LogoURL));
      return;
    }
  }
}
