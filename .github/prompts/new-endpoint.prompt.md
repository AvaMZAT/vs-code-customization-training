---
mode: agent
description: Scaffold a new minimal API endpoint following our conventions
---
Add a new endpoint to the Catalog API for ${input:resource}.

Requirements:
- Follow the C# standards in `.github/instructions/csharp.instructions.md`.
- Put logic in a constructor-injected service; keep the handler thin.
- Return `Results.*` with the correct status codes (200 / 201 / 404).
- Add an xUnit test (Arrange–Act–Assert, `Method_state_expected` naming).
- Record the change in `CHANGELOG.md` under `[Unreleased]`.
