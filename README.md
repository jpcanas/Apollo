# Apollo — ASP.NET Core Web API Template

A clean, reusable **ASP.NET Core Web API** starter template for building RESTful backend services. It provides a solid, opinionated foundation — PostgreSQL, EF Core, dual JWT/API Key authentication, policy-based authorization, structured logging, and global exception handling — so new projects can start from a working baseline instead of from scratch.

This is a **pure backend template**: no UI, no application-specific business logic. Clone it, rename it, and build your domain on top.

## Purpose

Rather than re-solving the same setup problems on every new project (auth, logging, config, exception handling, project structure), this template bakes in sensible defaults for those cross-cutting concerns once, correctly, so they don't need to be revisited each time. It's built to be simple enough for a solo developer to navigate, while keeping the separation of concerns needed to scale into a larger application.

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
| Dependency Injection | Built-in ASP.NET Core DI |

## Architecture & Project Structure

A pragmatic layered architecture, flat under the solution root — every project sits directly at `Apollo\`, no nested `src`/`tests` folders.

```
Apollo/
├── Apollo.sln
├── Apollo.Api/              # Controllers, middleware, DI wiring, Program.cs (composition root)
├── Apollo.Application/      # Interfaces, DTOs, service contracts, business logic
├── Apollo.Domain/           # Entities, enums, domain exceptions — no dependencies
├── Apollo.Infrastructure/   # EF Core DbContext, repositories, auth, external services
├── Apollo.UnitTests/        # Unit tests
└── Apollo.IntegrationTests/ # Integration tests
```

**Dependency direction:** `Domain` ← `Application` ← `Infrastructure` ← `Api`

`Domain` is pure C# with zero project references. Every other layer depends inward toward it, giving the template the dependency-inversion benefits of Clean Architecture without the overhead of a mediator pattern or excessive project splitting.

| Project | Depends on |
|---|---|
| `Apollo.Domain` | *(none)* |
| `Apollo.Application` | `Apollo.Domain` |
| `Apollo.Infrastructure` | `Apollo.Application`, `Apollo.Domain` |
| `Apollo.Api` | `Apollo.Application`, `Apollo.Infrastructure`, `Apollo.Domain` |
| `Apollo.UnitTests` | `Apollo.Application`, `Apollo.Domain` |
| `Apollo.IntegrationTests` | `Apollo.Api` |

## License

TBD