# PlayersAPI

REST API to report data about players, video games and games.
Built with ASP.NET Core and a layered, domain-oriented architecture.

## Tech stack

- .NET 6 / C#, ASP.NET Core Web API
- Entity Framework Core 7 with SQL Server
- JWT Bearer authentication
- AutoMapper
- Swagger / OpenAPI (Swashbuckle)
- NUnit + Moq (unit tests), MSTest

## Architecture

| Project | Responsibility |
|---|---|
| `Dominio` | Entities (`Player`, `Game`, `VideoGame`, `User`) and value objects (e.g. `EmailVO`) |
| `ApplicationLayer` | Use cases (one class per operation), services and DTOs |
| `Infraestructura` | EF Core context, data models and DAOs |
| `PlayersAPI` | HTTP entry point: controllers, DTOs, DI and JWT configuration |
| `Test`, `ApplicationLayerTests` | Unit tests |

Request flow: `Controller → Service → Use case → DAO → SQL Server`.

## Getting started

### Prerequisites

- .NET 6 SDK (or the version the project targets)
- SQL Server (LocalDB, Express or a container)

### Configuration

Set the connection string `LocalDB` and the `Jwt` section (`Key`, `Issuer`, `Audience`)
in `appsettings.json`, or better, through user secrets or environment variables.
Do not commit real credentials.

### Run

```bash
git clone https://github.com/and10git/PlayersAPI.git
cd PlayersAPI/PlayersAPI
dotnet run
```

Swagger UI: `https://localhost:7182/swagger`

### Tests

```bash
dotnet test
```

## Authentication

All endpoints except `Login` require a JWT. Create a user with `POST /Login/CreateUser`,
get a token with `POST /Login/Login`, then send it as `Authorization: Bearer <token>`.

## Endpoints

| Method | Route | Description |
|---|---|---|
| POST | `/Login/CreateUser` | Create a user |
| POST | `/Login/Login` | Obtain a JWT |
| GET | `/Players/Get` | List players |
| GET | `/Players/Get/{id}` | Get a player by id |
| POST | `/Players/Create` | Create a player |
| PUT | `/Players/Update` | Update a player |
| DELETE | `/Players/Delete/{id}` | Delete a player |
| GET | `/VideoGames/Get` | List video games |
| POST | `/VideoGames/Create` | Create a video game |
| DELETE | `/VideoGames/Delete/{id}` | Delete a video game |
| GET | `/Games/Get` | List games |
| POST | `/Games/Create` | Create a game (player, video game, points, time played) |
| DELETE | `/Games/Delete/{id}` | Delete a game |

## Roadmap

- [ ] Upgrade to .NET 10
- [ ] Containerize with Docker and Docker Compose
- [ ] Split into microservices
- [ ] Deploy to Azure
- [ ] CI pipeline with GitHub Actions