using PrecioAPP.UseCases.Contributors;
using PrecioAPP.UseCases.Businesses;
using PrecioAPP.UseCases.Businesses.List;
using PrecioAPP.Web.Businesses;
using PrecioAPP.UseCases.Employees.List;
using PrecioAPP.UseCases.Employees;

namespace PrecioAPP.Web.Employees;

/// <summary>
/// List all Businesses
/// </summary>
/// <remarks>
/// List all businesses - returns a BusinessListResponse containing the Businesses.
/// </remarks>
public class List(IMediator _mediator) : EndpointWithoutRequest<EmployeeListResponse>
{
  public override void Configure()
  {
    Get("/Employees");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListEmployeesQuery(null, null), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new EmployeeListResponse
      {
        Employees = result.Value.Select(c => new EmployeeRecord(c.Id, c.UserId, c.FullName, c.BusinessId, c.Role)).ToList()
      };
    }
  }
}
