# Apollo — ASP.NET Core Web API Template

A clean, reusable **ASP.NET Core Web API** starter template for building RESTful backend services. Built to be a solid, opinionated foundation you can clone and rename for any new project — not a finished application.

> ⚠️ **Status: Work in progress.** This template is being built incrementally. See [Roadmap](#roadmap) for what's done and what's next.

## Tech Stack

| Concern | Technology |
|---|---|
| Framework | ASP.NET Core Web API (.NET 10 LTS) |
| Database | PostgreSQL |
| ORM | Entity Framework Core (Npgsql provider) |
| Authentication | JWT Bearer + API Key (dual scheme) |
| Authorization | Policy-based |
| Logging | Serilog |
| API Docs | OpenAPI (+ Scalar/Swagger UI) |
| DI | Built-in ASP.NET Core DI |

## Project Structure

Flat layout — every project sits directly under the solution root.

```
Apollo/
├── Apollo.sln
├── Apollo.Api/              # Controllers, middleware, DI wiring, Program.cs (composition root)
├── Apollo.Application/      # Interfaces, DTOs, service contracts, business logic
├── Apollo.Domain/           # Entities, enums, domain exceptions — no dependencies
├── Apollo.Infrastructure/   # EF Core DbContext, repositories, auth, external services
├── Apollo.UnitTests/        # Unit tests
└── Apollo.IntegrationTests/ # Integration tests (WebApplicationFactory, etc.)
```

**Dependency direction:** `Domain` ← `Application` ← `Infrastructure` ← `Api`
`Domain` has zero project references — it's pure C#. Everything else depends inward toward it.

| Project | Depends on |
|---|---|
| `Apollo.Domain` | *(none)* |
| `Apollo.Application` | `Apollo.Domain` |
| `Apollo.Infrastructure` | `Apollo.Application`, `Apollo.Domain` |
| `Apollo.Api` | `Apollo.Application`, `Apollo.Infrastructure`, `Apollo.Domain` |
| `Apollo.UnitTests` | `Apollo.Application`, `Apollo.Domain` |
| `Apollo.IntegrationTests` | `Apollo.Api` |

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/) (or Docker)
- Visual Studio 2026 (or VS Code with C# Dev Kit)

## Getting Started

```bash
git clone https://github.com/<you>/Apollo.git
cd Apollo
dotnet build
```

> Database setup, migrations, and run instructions will be added once EF Core and configuration are wired up.

## Roadmap

- [x] Solution & project scaffolding
- [ ] Domain base entities (`AuditableEntity`)
- [ ] EF Core + PostgreSQL integration
- [ ] Configuration & Options pattern
- [ ] Serilog logging
- [ ] Global exception handling
- [ ] JWT authentication
- [ ] API Key authentication
- [ ] Authorization policies
- [ ] OpenAPI / Scalar UI
- [ ] DI cleanup pass
- [ ] Unit & integration test setup
- [ ] Template polish for reuse

## License

TBD
