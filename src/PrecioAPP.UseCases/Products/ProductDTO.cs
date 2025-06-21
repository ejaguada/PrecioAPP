namespace PrecioAPP.UseCases.Products;

  public record ProductDTO
  (
      int Id,
      string Name,
      string Description,
      string Barcode,
      string Brand,
      string ImageUrl,
      string Unit
  );
