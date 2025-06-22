using PrecioAPP.UseCases.BusinessProducts.Create;

namespace PrecioAPP.Web.BusinessProducts;

/// <summary>
/// Create a new Business Product 
/// </summary>
/// <remarks>
/// Creates a new Business Product given a business ID and product details.
/// </remarks>
public class CreateBusinessProductEndpoint(IMediator _mediator)
  : Endpoint<CreateBusinessProductRequest, CreateBusinessProductResponse>
{
  public override void Configure()
  {
    Post(CreateBusinessProductRequest.Route);
    Summary(s =>
    {
      // XML Docs are used by default but are overridden by these properties:
      //s.Summary = "Create a new Business Product.";
      //s.Description = "Create a new Business Product. A valid business ID and product details are required.";
      s.ExampleRequest = new CreateBusinessProductRequest { BusinessId = 1, ProductId = 1, CurrentPrice = 100, PreviousPrice = 90, Stock = 10, IsAvailable = true };
    });
  }

  public override async Task HandleAsync(
    CreateBusinessProductRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateBusinessProductCommand(request.BusinessId, request.ProductId, request.CurrentPrice, request.PreviousPrice, request.Stock, request.IsAvailable), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CreateBusinessProductResponse(result.Value, request.BusinessId, request.ProductId, request.CurrentPrice, request.PreviousPrice, request.Stock, request.IsAvailable);
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
