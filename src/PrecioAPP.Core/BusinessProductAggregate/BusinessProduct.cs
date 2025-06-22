namespace PrecioAPP.Core.BusinessProductAggregate;

public class BusinessProduct(int businessId, int productId, decimal currentPrice, decimal previousPrice, int stock, bool isAvailable) : EntityBase, IAggregateRoot
{
  public int BusinessId { get; private set; } = Guard.Against.NegativeOrZero(businessId, nameof(businessId));
  public int ProductId { get; private set; } = Guard.Against.NegativeOrZero(productId, nameof(productId));
  public decimal CurrentPrice { get; private set; } = Guard.Against.NegativeOrZero(currentPrice, nameof(currentPrice));
  public decimal PreviousPrice { get; private set; } = Guard.Against.NegativeOrZero(previousPrice, nameof(previousPrice));
  public int Stock { get; private set; } = Guard.Against.NegativeOrZero(stock, nameof(stock));
  public bool IsAvailable { get; private set; } = Guard.Against.Null(isAvailable, nameof(isAvailable));


  public void UpdateBusinessId(int newBusinessId) => BusinessId = Guard.Against.NegativeOrZero(businessId, nameof(businessId));
  public void UpdateProductId(int newProductId) => ProductId = Guard.Against.NegativeOrZero(newProductId, nameof(newProductId));
  public void UpdateCurrentPrice(decimal newCurrentPrice) => CurrentPrice = Guard.Against.NegativeOrZero(newCurrentPrice, nameof(newCurrentPrice));
  public void UpdatePreviousPrice(decimal newPreviousPrice) => PreviousPrice = Guard.Against.NegativeOrZero(newPreviousPrice, nameof(newPreviousPrice));
  public void UpdateStock(int newStock) => Stock = Guard.Against.NegativeOrZero(newStock, nameof(newStock));
  public void UpdateIsAvailable(bool newIsAvailable) => IsAvailable = Guard.Against.Null(newIsAvailable, nameof(newIsAvailable));
}
