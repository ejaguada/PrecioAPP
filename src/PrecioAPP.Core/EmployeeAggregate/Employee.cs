namespace PrecioAPP.Core.EmployeeAggregate;

public class Employee(int userId, string fullName, int businessId, string role) : EntityBase, IAggregateRoot
{
  // Example of validating primary constructor inputs
  // See: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors#initialize-base-class
  public int UserId { get; private set; } = Guard.Against.NegativeOrZero(userId, nameof(userId));
  public string FullName { get; set; } = Guard.Against.NullOrEmpty(nameof(fullName), nameof(fullName));
  public int BusinessId { get; private set; } = Guard.Against.NegativeOrZero(businessId, nameof(businessId));
  public string Role { get; private set; } = Guard.Against.NullOrEmpty(role, nameof(role));


  public void UpdateUserId(int newUserId) => UserId = Guard.Against.NegativeOrZero(newUserId, nameof(newUserId));
  public void UpdateBusinessId(int newBusinessId) => BusinessId = Guard.Against.NegativeOrZero(newBusinessId, nameof(newBusinessId));
  public void UpdateRole(string newRole) => Role = Guard.Against.NullOrEmpty(newRole, nameof(newRole));
  public void UpdateFullName(string newFullName) => FullName = Guard.Against.NullOrEmpty(newFullName, nameof(newFullName));
}
