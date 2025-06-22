using PrecioAPP.UseCases.Products.Get;
using PrecioAPP.UseCases.Products.Update;

namespace PrecioAPP.Web.Products;

/// <summary>
/// Update an existing Product.
/// </summary>
/// <remarks>
/// Update an existing Product by providing a fully defined replacement set of values.
/// See: https://stackoverflow.com/questions/60761955/rest-update-best-practice-put-collection-id-without-id-in-body-vs-put-collecti
/// </remarks>
public class Update(IMediator _mediator)
  : Endpoint<UpdateProductRequest, UpdateProductResponse>
{
  public override void Configure()
  {
    Put(UpdateProductRequest.Route);
  }

  public override async Task HandleAsync(
    UpdateProductRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateProductCommand(request.ProductId, request.Name!, request.Description!, request.Barcode!, request.Brand!, request.ImageUrl!, request.Unit!), cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetProductQuery(request.ProductId);

    var queryResult = await _mediator.Send(query, cancellationToken);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateProductResponse(new ProductRecord(dto.Id, dto.Name, dto.Description, dto.Barcode, dto.Brand, dto.ImageUrl, dto.Unit));
      return;
    }
  }
}
