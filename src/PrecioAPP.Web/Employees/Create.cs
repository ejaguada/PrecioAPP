using PrecioAPP.UseCases.Employees.Create;

namespace PrecioAPP.Web.Employees;

/// <summary>
/// Create a new Employee
/// </summary>
/// <remarks>
/// Creates a new Employee given a user ID and full name.
/// </remarks>
public class Create(IMediator _mediator)
  : Endpoint<CreateEmployeeRequest, CreateEmployeeResponse>
{
  public override void Configure()
  {
    Post(CreateEmployeeRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      // XML Docs are used by default but are overridden by these properties:
      //s.Summary = "Create a new Employee.";
      //s.Description = "Create a new Employee. A valid user ID and full name are required.";
      s.ExampleRequest = new CreateEmployeeRequest { UserId = 1, FullName = "John Doe", BusinessId = 1, Role = "Manager" };
    });
  }

  public override async Task HandleAsync(
    CreateEmployeeRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateEmployeeCommand(request.UserId, request.FullName!, request.BusinessId, request.Role!), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CreateEmployeeResponse(result.Value, request.UserId, request.FullName!, request.BusinessId, request.Role!);
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
