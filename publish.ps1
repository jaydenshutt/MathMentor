# MathMentor release publish script
# Produces a single-file self-contained EXE for Windows x64 (no .NET runtime install required).

$ErrorActionPreference = "Stop"
Set-Location $PSScriptRoot

Write-Host ""
Write-Host "MathMentor: single-file self-contained publish (win-x64)" -ForegroundColor Cyan
Write-Host "========================================================"
Write-Host ""

$outDir = Join-Path $PSScriptRoot "publish\win-x64"

dotnet publish (Join-Path $PSScriptRoot "MathMentor\MathMentor.csproj") `
  -c Release `
  -r win-x64 `
  --self-contained true `
  -p:PublishSingleFile=true `
  -p:IncludeNativeLibrariesForSelfExtract=true `
  -p:EnableCompressionInSingleFile=true `
  -p:DebugType=embedded `
  -o $outDir

if ($LASTEXITCODE -ne 0) {
    Write-Host "Publish failed. Install the .NET 10 SDK from https://dotnet.microsoft.com/download" -ForegroundColor Red
    exit $LASTEXITCODE
}

$exe = Join-Path $outDir "MathMentor.exe"
if (-not (Test-Path $exe)) {
    Write-Host "Expected output not found: $exe" -ForegroundColor Red
    exit 1
}

$item = Get-Item $exe
Write-Host ""
Write-Host "Success." -ForegroundColor Green
Write-Host ""
Write-Host "Share this file:"
Write-Host "  $($item.FullName)"
Write-Host ("  Size: {0:N1} MB" -f ($item.Length / 1MB))
Write-Host "  Modified: $($item.LastWriteTime)"
Write-Host ""
Write-Host "Recipients need 64-bit Windows 10 or 11."
Write-Host "They do NOT need to install .NET separately."
Write-Host ""
