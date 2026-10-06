---
applyTo: "**/*.cs"
---
# C# coding standards

- Use **file-scoped namespaces**; put `using` directives outside the namespace.
- Nullable reference types are enabled. **Never** use the null-forgiving `!` operator
  without a `// reason` comment on the same line.
- Public async methods do I/O, end in `Async`, and return `Task`/`Task<T>`. No `async void`.
- Prefer an injected `TimeProvider` over system clock APIs such as `DateTime.Now`,
  `DateTime.UtcNow`, or `DateTimeOffset.Now`.
- Inject dependencies through the constructor. No static service locators.
- Use `record` types for immutable DTOs and request/response models.
- Keep minimal API handlers thin — put logic in a service and return `Results.*`.
- One public type per file; the file name matches the type name.
