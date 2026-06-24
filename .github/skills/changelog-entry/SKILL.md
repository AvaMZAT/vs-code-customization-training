---
name: changelog-entry
description: Add a Keep a Changelog entry for a code change, in this project's style. Use this when the user asks to record, note, or write a changelog entry after making changes.
---
# Changelog entry

When asked to record a change in the changelog:

1. Identify what changed (from the git diff or the user's description).
2. Open `CHANGELOG.md` and find the `## [Unreleased]` section.
3. Add a bullet under the correct category — Added / Changed / Deprecated / Removed / Fixed /
   Security — following the format in [template.md](./template.md).
4. Write one concise, user-facing line in past tense. No internal jargon, no PR numbers.
5. Do **not** invent a version number or release date; leave entries under `[Unreleased]`.
