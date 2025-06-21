namespace PrecioAPP.UseCases.Employees.Create;

/// <summary>
/// Create a new Employee.
/// </summary>
/// <param name="Name"></param>
/// <param name="BusinessId"></param>
/// <param name="Role"></param>
public record CreateEmployeeCommand(int UserId, string FullName, int BusinessId, string Role) : Ardalis.SharedKernel.ICommand<Result<int>>;
