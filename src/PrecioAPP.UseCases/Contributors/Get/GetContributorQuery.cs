﻿using PrecioAPP.UseCases.Businesses;

namespace PrecioAPP.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
