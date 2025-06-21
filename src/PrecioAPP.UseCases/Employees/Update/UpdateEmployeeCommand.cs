namespace PrecioAPP.UseCases.Employees.Update;

public record UpdateEmployeeCommand(int EmployeeId, string NewFullName, int NewBusinessId, string NewRole) : ICommand<Result<EmployeeDTO>>;
