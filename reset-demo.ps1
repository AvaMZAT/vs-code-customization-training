# Resets the working tree back to the clean "demo-start" tag.
# One-time setup first (see README): git init, commit, then: git tag demo-start
$ErrorActionPreference = "Stop"
if (-not (git tag -l "demo-start")) {
    Write-Host "Tag 'demo-start' not found. Run the one-time setup in the README first." -ForegroundColor Yellow
    exit 1
}
git reset --hard demo-start | Out-Null
git clean -fd | Out-Null
Write-Host "Repo reset to 'demo-start'. Ready for the next run." -ForegroundColor Green
