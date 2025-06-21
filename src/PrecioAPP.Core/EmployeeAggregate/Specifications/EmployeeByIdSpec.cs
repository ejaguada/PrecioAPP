namespace PrecioAPP.Core.EmployeeAggregate.Specifications;

public class EmployeeByIdSpec : Specification<Employee>
{
  public EmployeeByIdSpec(int employeeId) =>
    Query
        .Where(employee => employee.Id == employeeId);
}
