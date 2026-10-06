# Catalog API — agent brief

A tiny ASP.NET Core (.NET 8) minimal API for a product catalog. Its real purpose is to
demonstrate **GitHub Copilot customization**, so keep changes small and conventional.

## Build, run, test
- Build: `dotnet build`
- Run:   `dotnet run --project src/CatalogApi`  (listens on <http://localhost:5099>)
- Test:  `dotnet test`

## Conventions (non-negotiable)
- Target .NET 8. File-scoped namespaces. Nullable enabled — never use `!` without a reason comment.
- Public async methods end in `Async` and return `Task`/`Task<T>`; no `async void`.
- Inject dependencies via the constructor. Use an injected `TimeProvider`; avoid system clock APIs such as `DateTime.Now`, `DateTime.UtcNow`, and `DateTimeOffset.Now`.
- Endpoints stay thin: logic lives in a service, handlers return `Results.*` with correct status codes.
- Tests use xUnit, Arrange–Act–Assert, named `Method_state_expected`.

## Layout
- `src/CatalogApi` — the API (`Program.cs`, `Models/`, `Services/`)
- `tests/CatalogApi.Tests` — xUnit tests

Trust these instructions; only explore the codebase if something here is missing or wrong.
