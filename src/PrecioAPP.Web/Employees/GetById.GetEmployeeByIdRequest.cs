namespace PrecioAPP.Web.Employees;

public class GetEmployeeByIdRequest
{
  public const string Route = "/Employees/{Id:int}";
  public static string BuildRoute(int id) => Route.Replace("{Id:int}", id.ToString());

  public int EmployeeId { get; set; }
}
