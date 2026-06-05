using CleanArchAPI.Domain.Entities;
using MediatR;

namespace CleanArchAPI.Application.Queries;

public record GetAllProductsQuery : IRequest<IEnumerable<Product>>;
public record GetProductByIdQuery(int Id) : IRequest<Product?>;
