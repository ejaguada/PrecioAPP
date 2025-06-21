using PrecioAPP.UseCases.Businesses.Create;

namespace PrecioAPP.Web.Businesses;

/// <summary>
/// Create a new Business
/// </summary>
/// <remarks>
/// Creates a new Business given a name.
/// </remarks>
public class Create(IMediator _mediator)
  : Endpoint<CreateBusinessRequest, CreateBusinessResponse>
{
  public override void Configure()
  {
    Post(CreateBusinessRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      // XML Docs are used by default but are overridden by these properties:
      //s.Summary = "Create a new Business.";
      //s.Description = "Create a new Business. A valid name is required.";
      s.ExampleRequest = new CreateBusinessRequest { Name = "Business Name" };
    });
  }

  public override async Task HandleAsync(
    CreateBusinessRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateBusinessCommand(request.Name!, request.Description!, request.Address!, request.Longitude!, request.Latitude!, request.Phone!, request.Email!, request.Website!, request.LogoURL!), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CreateBusinessResponse(result.Value, request.Name!, request.Description!, request.Address!, request.Email!, request.Website!, request.LogoURL!, request.Latitude!, request.Longitude!);
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
