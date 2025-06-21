namespace PrecioAPP.Core.BusinessAggregate;

public class Business(string name, string description, string address, int longitude, int latitude, string phone, string email, string website, string logoURL) : EntityBase, IAggregateRoot
{
  // Example of validating primary constructor inputs
  // See: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors#initialize-base-class
  public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));
  public string Description { get; private set; } = Guard.Against.NullOrEmpty(description, nameof(description));
  public string Address { get; private set; } = Guard.Against.NullOrEmpty(address, nameof(address));
  public int Longitude { get; private set; } = Guard.Against.NegativeOrZero(longitude, nameof(longitude));
  public int Latitude { get; private set; } = Guard.Against.NegativeOrZero(latitude, nameof(latitude));
  public string Phone { get; private set; } = Guard.Against.NullOrEmpty(phone, nameof(phone));
  public string Email { get; private set; } = Guard.Against.NullOrEmpty(email, nameof(email));
  public string Website { get; private set; } = Guard.Against.NullOrEmpty(website, nameof(website));
  public string LogoURL { get; private set; } = Guard.Against.NullOrEmpty(logoURL, nameof(logoURL));

  public void UpdateName(string newName) => Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  public void UpdateDescription(string newDescription) => Description = Guard.Against.NullOrEmpty(newDescription, nameof(newDescription));
  public void UpdateAddress(string newAddress) => Address = Guard.Against.NullOrEmpty(newAddress, nameof(newAddress));
  public void UpdateLongitude(int newLongitude) => Longitude = Guard.Against.NegativeOrZero(newLongitude, nameof(newLongitude));
  public void UpdateLatitude(int newLatitude) => Latitude = Guard.Against.NegativeOrZero(newLatitude, nameof(newLatitude));
  public void UpdatePhone(string newPhone) => Phone = Guard.Against.NullOrEmpty(newPhone, nameof(newPhone));
  public void UpdateEmail(string newEmail) => Email = Guard.Against.NullOrEmpty(newEmail, nameof(newEmail));
  public void UpdateWebsite(string newWebsite) => Website = Guard.Against.NullOrEmpty(newWebsite, nameof(newWebsite));
  public void UpdateLogoURL(string newLogoURL) => LogoURL = Guard.Against.NullOrEmpty(newLogoURL, nameof(newLogoURL));
}
