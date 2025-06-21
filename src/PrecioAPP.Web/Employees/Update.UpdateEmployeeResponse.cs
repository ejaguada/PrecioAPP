namespace PrecioAPP.Web.Employees;

public class UpdateEmployeeResponse(EmployeeRecord employee)
{
  public EmployeeRecord Employee { get; set; } = employee;
}
