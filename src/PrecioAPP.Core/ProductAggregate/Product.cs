namespace PrecioAPP.Core.ProductAggregate;

public class Product(string name, string description, string barcode, string brand, string imageUrl, string unit) : EntityBase, IAggregateRoot
{
  // Example of validating primary constructor inputs
  // See: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors#initialize-base-class
  public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));
  public string Description { get; private set; } = Guard.Against.NullOrEmpty(description, nameof(description));
  public string Barcode { get; private set; } = Guard.Against.NullOrEmpty(barcode, nameof(barcode));
  public string Brand { get; private set; } = Guard.Against.NullOrEmpty(brand, nameof(brand));
  public string ImageUrl { get; private set; } = Guard.Against.NullOrEmpty(imageUrl, nameof(imageUrl));
  public string Unit { get; private set; } = Guard.Against.NullOrEmpty(unit, nameof(unit));

  public void UpdateName(string newName) => Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  public void UpdateDescription(string newDescription) => Description = Guard.Against.NullOrEmpty(newDescription, nameof(newDescription));
  public void UpdateBarcode(string newBarcode) => Barcode = Guard.Against.NullOrEmpty(newBarcode, nameof(newBarcode));
  public void UpdateBrand(string newBrand) => Brand = Guard.Against.NullOrEmpty(newBrand, nameof(newBrand));
  public void UpdateImageUrl(string newImageUrl) => ImageUrl = Guard.Against.NullOrEmpty(newImageUrl, nameof(newImageUrl));
  public void UpdateUnit(string newUnit) => Unit = Guard.Against.NullOrEmpty(newUnit, nameof(newUnit));

}
