# CleanArchG — ASP.NET Core Web API

Clean Architecture med CQRS, MediatR, Repository Pattern och EF Core.

## Mappstruktur

```
CleanArchG.Domain/          ← Entities, Interfaces (vet ingenting om andra lager)
CleanArchG.Application/     ← Commands, Queries, Handlers
CleanArchG.Infrastructure/  ← DbContext, Repositories, Migrations
CleanArchG.API/             ← Controllers, Program.cs
```

## Kom igång

```bash
# Skapa migrations och databas
dotnet ef migrations add InitialCreate \
  --project CleanArchG.Infrastructure \
  --startup-project CleanArchG.API

dotnet ef database update \
  --project CleanArchG.Infrastructure \
  --startup-project CleanArchG.API

# Starta
dotnet run --project CleanArchG.API
```

Swagger: `https://localhost:xxxx/swagger`

## NuGet-paket

**CleanArchG.Application**
- `MediatR`

**CleanArchG.Infrastructure**
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Tools`

**CleanArchG.API**
- `Swashbuckle.AspNetCore`
- `Microsoft.EntityFrameworkCore.Design`

## Endpoints

| Metod  | URL                   | Beskrivning        |
|--------|-----------------------|--------------------|
| GET    | /api/products         | Hämta alla         |
| GET    | /api/products/{id}    | Hämta en           |
| POST   | /api/products         | Skapa              |
| PUT    | /api/products/{id}    | Uppdatera          |
| DELETE | /api/products/{id}    | Ta bort            |

## Exempelanrop (POST)

```json
POST /api/products
{
  "name": "Laptop",
  "price": 9999.00,
  "categoryId": 1
}
```
