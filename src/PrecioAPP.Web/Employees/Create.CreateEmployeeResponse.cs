using System.ComponentModel.DataAnnotations;

namespace PrecioAPP.Web.Employees;

public class CreateEmployeeResponse(int id, int userId, string fullName, int businessId, string role)
{
  public int Id { get; set; } = id;
  public int UserId { get; set; } = userId;
  public string? FullName { get; set; } = fullName;
  public int BusinessId { get; set; } = businessId;
  public string? Role { get; set; } = role;

}
