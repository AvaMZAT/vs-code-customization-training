# GitHub Copilot Customization — Demo Repo (.NET 8 / VS Code)

A deliberately tiny **ASP.NET Core minimal API** (a product catalog). The code is just a
realistic backdrop — the real content is the **`.github/` customization files**, which teach
Copilot this project's standards. Run the exercises below to see Copilot follow *your* rules.

Keep this repo after the session as a reference template.

---

## 1. Prerequisites

- **.NET SDK 8.0 or later** — https://dotnet.microsoft.com/download (the repo targets `net8.0`;
  a newer SDK builds it fine).
- **VS Code** with **C# Dev Kit** (`ms-dotnettools.csdevkit`), **GitHub Copilot**, and
  **Copilot Chat**, signed in to your Copilot seat. VS Code will offer to install these when you
  open the folder.

```bash
dotnet --version    # check your SDK
```

## 2. Run it

```bash
dotnet build
dotnet run --project src/CatalogApi      # http://localhost:5099
dotnet test
```

In VS Code, press **F5** ("Run CatalogApi"), then open `src/CatalogApi/CatalogApi.http` and click
**Send Request** above any request.

> One-time setup so the reset script works (section 6):
> ```bash
> git init -b main && git add -A && git commit -m "demo start" && git tag demo-start
> ```

## 3. The customization files (the point of this repo)

| File | Type | What it does |
|------|------|--------------|
| `AGENTS.md` | **Portable instructions** | Project brief, commands, and conventions; additive to other applicable instructions. |
| `.github/copilot-instructions.md` | Always-on, **VS Code-native** | Thin response preferences; points at the other two. |
| `.github/instructions/csharp.instructions.md` | **Path-specific** (`applyTo: **/*.cs`) | The detailed C# coding standards — only load for C# files. |
| `.github/agents/csharp-reviewer.agent.md` | **Custom agent** | A read-only "C# Reviewer" persona with scoped tools. |
| `.github/skills/changelog-entry/SKILL.md` | **Skill** | On-demand: writes a `CHANGELOG.md` entry in our style. |
| `.github/prompts/new-endpoint.prompt.md` | **Prompt file** (Local Agent backup) | `/new-endpoint` for the Local Agent; deprecated and not loaded in Agent Host sessions. |

The team conventions encoded across these: .NET 8, file-scoped namespaces, nullable enabled (no
`!` without a reason), async methods suffixed `Async`, **injected `TimeProvider` (not system
clock APIs such as `DateTime.Now`, `DateTime.UtcNow`, or `DateTimeOffset.Now`)**, constructor
injection, `record` DTOs, thin handlers, and xUnit AAA tests named `Method_state_expected`.

## 4. Try it yourself

Do these in order — it mirrors the session.

**Custom Instructions**
- In Copilot Chat, ask: ``Add a PATCH /products/{id} endpoint to change a product's price.``
  Watch it follow our rules (thin handler, service method, `Results.*`, a test). Expand the chat
  response's **References** to confirm `csharp.instructions.md` was applied.

**AGENTS.md**
- Ask: ``How do I build, run, and test this project?`` The project guidance includes the port
  and `dotnet` commands. `AGENTS.md` and applicable Copilot instructions are additive; neither
  is a general override for the other.

**Custom Agent**
- Pick **C# Reviewer** from the agent dropdown, then ask: ``Review ProductService.``
  It should flag `DateTimeOffset.Now` in `Add` (our convention is an injected `TimeProvider`).
  Notice it **suggests** a fix but can't edit — it only has read-only tools.

**Skill**
- Make a small change (or use the one above), then invoke `/changelog-entry` with a request to
  record it. Skills can also be selected automatically when relevant, but activation is not
  guaranteed. The skill updates `CHANGELOG.md` under `[Unreleased]`, following `template.md`.

**Prompt File (Local Agent backup)**
- With the Local Agent selected, type ``/new-endpoint`` and give it a resource name. It scaffolds
  an endpoint, a test, and a changelog line — all to our conventions. Prompt files are deprecated
  and are not loaded in Agent Host sessions.

## 5. The intentional smell

`ProductService.Add` sets `CreatedAt` with `DateTimeOffset.Now`. That **violates** our convention
(use an injected `TimeProvider`) and is left in on purpose so the **C# Reviewer** agent has a real
issue to find. Everything else in the repo already follows the standards.

## 6. Reset between runs

```bash
./reset-demo.sh      # macOS / Linux
./reset-demo.ps1     # Windows PowerShell
```

(Requires the one-time `demo-start` tag from section 2.)

## 7. Going further

See the session's **Links & Resources** slide / handout for the official VS Code and GitHub docs
on each customization type, plus the `awesome-copilot` community examples.
