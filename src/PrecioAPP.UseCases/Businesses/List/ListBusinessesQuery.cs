namespace PrecioAPP.UseCases.Businesses.List;

public record ListBusinessesQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<BusinessDTO>>>;
