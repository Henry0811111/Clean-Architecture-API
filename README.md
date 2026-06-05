# Clean Architecture API

ASP.NET Core Web API byggd med Clean Architecture, CQRS, MediatR, Repository Pattern och Entity Framework Core.

## Projektstruktur

```
CleanArchAPI.Domain/          ← Entiteter och interfaces
CleanArchAPI.Application/     ← Commands, Queries och Handlers  
CleanArchAPI.Infrastructure/  ← DbContext och Repositories
CleanArchAPI.API/             ← Controllers och Program.cs
CleanArchAPI.slnx             ← Solution-fil
```

## Beroenden

```
API → Application → Domain
Infrastructure → Domain
```

## Kom igång

### 1. Klona repot
```bash
git clone https://github.com/Henry0811111/Clean-Architecture-API.git
cd Clean-Architecture-API
```

### 2. Skapa databasen
```bash
dotnet ef migrations add InitialCreate \
  --project CleanArchAPI.Infrastructure \
  --startup-project CleanArchAPI.API

dotnet ef database update \
  --project CleanArchAPI.Infrastructure \
  --startup-project CleanArchAPI.API
```

### 3. Starta API:et
```bash
dotnet run --project CleanArchAPI.API
```

Swagger UI: `https://localhost:xxxx/swagger`

## Endpoints
| Metod  | URL                   | Beskrivning  |
|--------|-----------------------|--------------|
| GET    | /api/products         | Hämta alla   |
| GET    | /api/products/{id}    | Hämta en     |
| POST   | /api/products         | Skapa        |
| PUT    | /api/products/{id}    | Uppdatera    |
| DELETE | /api/products/{id}    | Ta bort      |

## Exempel
```json
POST /api/products
{
  "name": "Laptop",
  "price": 9999.00,
  "categoryId": 1
}
```

## Tekniker
- ASP.NET Core Web API
- Clean Architecture
- CQRS med MediatR
- Repository Pattern
- Entity Framework Core
- SQL Server
- Swagger