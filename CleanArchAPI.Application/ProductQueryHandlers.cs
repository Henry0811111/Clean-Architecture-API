using CleanArchAPI.Application.Queries;
using CleanArchAPI.Domain.Entities;
using CleanArchAPI.Domain.Interfaces;
using MediatR;

namespace CleanArchAPI.Application.Handlers;

public class GetAllProductsQueryHandler(IProductRepository repo)
    : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery r, CancellationToken ct)
        => await repo.GetAllWithCategoryAsync();
}

public class GetProductByIdQueryHandler(IProductRepository repo)
    : IRequestHandler<GetProductByIdQuery, Product?>
{
    public async Task<Product?> Handle(GetProductByIdQuery r, CancellationToken ct)
        => await repo.GetByIdWithCategoryAsync(r.Id);
}
