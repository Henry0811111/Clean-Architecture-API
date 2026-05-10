using CleanArchG.Domain.Entities;
using MediatR;

namespace CleanArchG.Application.Commands;

// Varje command är ett eget record — separerat från queries
public record CreateProductCommand(string Name, decimal Price, int CategoryId) : IRequest<Product>;
public record UpdateProductCommand(int Id, string Name, decimal Price, int CategoryId) : IRequest<Product?>;
public record DeleteProductCommand(int Id) : IRequest<bool>;
