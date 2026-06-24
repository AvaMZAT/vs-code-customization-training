#!/usr/bin/env bash
# Resets the working tree back to the clean "demo-start" tag.
# One-time setup first (see README): git init, commit, then: git tag demo-start
set -e
if ! git rev-parse -q --verify "refs/tags/demo-start" >/dev/null; then
  echo "Tag 'demo-start' not found. Run the one-time setup in the README first."
  exit 1
fi
git reset --hard demo-start >/dev/null
git clean -fd >/dev/null
echo "Repo reset to 'demo-start'. Ready for the next run."
