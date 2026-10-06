# Presenter runbook — live demos (Session 2: Customization)

Keep this on a second screen. Prompts are written to type verbatim. Each demo is staged to fit
the per-topic budget from the deck.

## Pre-flight (before the session)

- [ ] `dotnet build` and `dotnet test` once so packages are restored and tests are green.
- [ ] Open the folder in VS Code; sign in to Copilot; confirm the model picker and the agent
      dropdown both work.
- [ ] One-time: `git init -b main && git add -A && git commit -m "demo start" && git tag demo-start`.
- [ ] Bump the editor font size; open the integrated terminal; close noisy panels.
- [ ] Have screenshot/GIF fallbacks ready in case a model call is slow.
- [ ] `./reset-demo.sh` right before you start.

## Slide 5 — Custom Instructions (DEMO, ~4 min)
- Show `.github/copilot-instructions.md`, then `.github/instructions/csharp.instructions.md`
  (note the `applyTo: "**/*.cs"`).
- In Chat: `Add a PATCH /products/{id} endpoint to change a product's price.`
- Point out the result follows our rules (thin handler, service method, `Results.*`, a test).
- Expand **References** in the response → show `csharp.instructions.md` was used.
- Optional: open a non-`.cs` file and show the C# rule does *not* apply there.

## Slide 6 — AGENTS.md (DEMO light, ~1 min)
- Show `AGENTS.md`. In Chat: `How do I build, run, and test this project?`
- Point out that the project guidance includes the commands and port; applicable instruction
  sources are additive, not a hierarchy where `AGENTS.md` overrides the others.
- One line: `AGENTS.md` is a portable format supported by compatible agents.

## Slide 8 — Custom Agents (DEMO, ~4 min)
- Open `.github/agents/csharp-reviewer.agent.md`; walk the frontmatter (tools = read-only, model).
- Select **C# Reviewer** from the agent dropdown. Prompt: `Review ProductService.`
- It flags `DateTimeOffset.Now` in `Add` (should be injected `TimeProvider`).
- Key beat: it **can't edit** — read-only tools. Try asking it to "fix it" → it suggests a snippet
  but won't modify files. That's tool scoping.

## Slide 10 — Skills (DEMO, ~4 min)
- Show `.github/skills/changelog-entry/` (SKILL.md + template.md).
- Invoke `/changelog-entry` with: `Add a changelog entry for the new PATCH endpoint.`
- The skill edits `CHANGELOG.md` under `[Unreleased]` per the template. Copilot may also select
  a relevant skill automatically, but automatic activation is not guaranteed.
- Point out: skills can load on demand; they are not always-on instructions.

## Slide 13 — Links (no demo)
- Carried-over + refreshed links; ★ = new suggestions. Mirrored in the handout.

## Slide 14 — Prompt Files (BACKUP, ~3 min, only if time/asked)
- With the Local Agent selected, type `/new-endpoint` and give a resource name (e.g. "categories").
- It scaffolds an endpoint + test + changelog line, all to our conventions.
- Prompt files are deprecated and not loaded in Agent Host sessions.

## Reset between runs
```bash
./reset-demo.sh    # or ./reset-demo.ps1 on Windows
```

## If something fails live
- Model slow/unavailable → switch model in the picker, or use your screenshot/GIF.
- Agent goes off-track → stop it, reset, narrate what it *would* have done.
- Build broken after edits → `./reset-demo.sh` and continue; don't debug live.
