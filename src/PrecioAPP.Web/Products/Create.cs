using PrecioAPP.UseCases.Products.Create;

namespace PrecioAPP.Web.Products;

/// <summary>
/// Create a new Product
/// </summary>
/// <remarks>
/// Creates a new Product given its details.
/// </remarks>
public class Create(IMediator _mediator)
  : Endpoint<CreateProductRequest, CreateProductResponse>
{
  public override void Configure()
  {
    Post(CreateProductRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      // XML Docs are used by default but are overridden by these properties:
      //s.Summary = "Create a new Product.";
      //s.Description = "Create a new Product. A valid name and description are required.";
      s.ExampleRequest = new CreateProductRequest { Name = "New Product", Description = "Product Description", Barcode = "1234567890123", Brand = "Product Brand", ImageUrl = "http://example.com/image.png", Unit = "pcs" };
    });
  }

  public override async Task HandleAsync(
    CreateProductRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateProductCommand(request.Name!, request.Description!, request.Barcode!, request.Brand!, request.ImageUrl!, request.Unit!), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CreateProductResponse(result.Value, request.Name!, request.Description!, request.Barcode!, request.Brand!, request.ImageUrl!, request.Unit!);
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
