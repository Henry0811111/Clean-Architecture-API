using CleanArchAPI.Application.Commands;
using CleanArchAPI.Domain.Entities;
using CleanArchAPI.Domain.Interfaces;
using MediatR;

namespace CleanArchAPI.Application.Handlers;

public class CreateProductCommandHandler(IProductRepository repository)
    : IRequestHandler<CreateProductCommand, Product>
{
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken ct)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            CategoryId = request.CategoryId
        };
        return await repository.AddAsync(product);
    }
}

public class UpdateProductCommandHandler(IProductRepository repository)
    : IRequestHandler<UpdateProductCommand, Product?>
{
    public async Task<Product?> Handle(UpdateProductCommand request, CancellationToken ct)
    {
        var product = await repository.GetByIdAsync(request.Id);
        if (product is null) return null;

        product.Name = request.Name;
        product.Price = request.Price;
        product.CategoryId = request.CategoryId;

        await repository.UpdateAsync(product);
        return product;
    }
}

public class DeleteProductCommandHandler(IProductRepository repository)
    : IRequestHandler<DeleteProductCommand, bool>
{
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken ct)
    {
        var product = await repository.GetByIdAsync(request.Id);
        if (product is null) return false;

        await repository.DeleteAsync(product);
        return true;
    }
}
