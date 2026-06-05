using CleanArchAPI.Domain.Entities;
using MediatR;

namespace CleanArchAPI.Application.Commands;

// Varje command är ett eget record — separerat från queries
public record CreateProductCommand(string Name, decimal Price, int CategoryId) : IRequest<Product>;
public record UpdateProductCommand(int Id, string Name, decimal Price, int CategoryId) : IRequest<Product?>;
public record DeleteProductCommand(int Id) : IRequest<bool>;
