# CleanArchG — ASP.NET Core Web API 

Clean Architecture med CQRS, MediatR, Repository Pattern och EF Core.

## Projektstruktur

```
CleanArchG.sln
├── CleanArchG.Domain/            ← Entities, Interfaces
│   ├── Entities/
│   │   ├── Product.cs
│   │   └── Category.cs
│   └── Interfaces/
│       ├── IRepository.cs
│       └── IProductRepository.cs
│
├── CleanArchG.Application/       ← Commands, Queries, Handlers
│   ├── Commands/ProductCommands.cs
│   ├── Queries/ProductQueries.cs
│   └── Handlers/
│       ├── ProductCommandHandlers.cs
│       └── ProductQueryHandlers.cs
│
├── CleanArchG.Infrastructure/    ← DbContext, Repositories
│   ├── Data/AppDbContext.cs
│   └── Repositories/
│       ├── Repository.cs
│       └── ProductRepository.cs
│
└── CleanArchG.API/               ← Controllers, Program.cs
    ├── Controllers/ProductsController.cs
    ├── Program.cs
    └── appsettings.json
```

## Projektreferenser (beroenden pekar inåt mot Domain)

```
Application  →  Domain
Infrastructure  →  Domain
API  →  Application + Infrastructure
```

## Kom igång

```bash
# 1. Skapa migration
dotnet ef migrations add InitialCreate \
  --project CleanArchG.Infrastructure \
  --startup-project CleanArchG.API

# 2. Kör mot databasen
dotnet ef database update \
  --project CleanArchG.Infrastructure \
  --startup-project CleanArchG.API

# 3. Starta API:et
dotnet run --project CleanArchG.API
```

Swagger: `https://localhost:xxxx/swagger`

## Endpoints

| Metod  | URL                 | Beskrivning  |
|--------|---------------------|--------------|
| GET    | /api/products       | Hämta alla   |
| GET    | /api/products/{id}  | Hämta en     |
| POST   | /api/products       | Skapa        |
| PUT    | /api/products/{id}  | Uppdatera    |
| DELETE | /api/products/{id}  | Ta bort      |

## POST-exempel

```json
POST /api/products
{
  "name": "Laptop",
  "price": 9999.00,
  "categoryId": 1
}
```