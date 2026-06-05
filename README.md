# Clean Architecture API

ASP.NET Core Web API med Clean Architecture, CQRS, MediatR, Repository Pattern och EF Core.

## Projektstruktur

- CleanArchAPI.Domain - Entiteter och interfaces
- CleanArchAPI.Application - Commands, Queries och Handlers
- CleanArchAPI.Infrastructure - DbContext och Repositories  
- CleanArchAPI.API - Controllers och Program.cs

## Starta projektet

dotnet run --project CleanArchAPI.API

## Endpoints

- GET /api/products
- GET /api/products/{id}
- POST /api/products
- PUT /api/products/{id}
- DELETE /api/products/{id}
