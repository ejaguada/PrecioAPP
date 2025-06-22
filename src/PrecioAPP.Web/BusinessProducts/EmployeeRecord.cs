namespace PrecioAPP.Web.BusinessProducts;

public record BusinessProductRecord(int Id, int BusinessId, int ProductId, decimal CurrentPrice, decimal PreviousPrice, int Stock, bool IsAvailable);
