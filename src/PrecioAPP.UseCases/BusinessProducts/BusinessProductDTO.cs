namespace PrecioAPP.UseCases.BusinessProducts;
public record BusinessProductDTO(int Id, int BusinessId, int ProductId, decimal CurrentPrice, decimal PreviousPrice, int Stock, bool IsAvailable);
