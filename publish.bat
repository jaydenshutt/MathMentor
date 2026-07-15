@echo off
setlocal
cd /d "%~dp0"

echo.
echo  MathMentor: single-file self-contained publish (win-x64)
echo  ========================================================
echo.
echo  This builds MathMentor.exe with the .NET runtime inside.
echo  You can share just that one file. No .NET install needed.
echo.

dotnet publish MathMentor\MathMentor.csproj -c Release -r win-x64 --self-contained true ^
  -p:PublishSingleFile=true ^
  -p:IncludeNativeLibrariesForSelfExtract=true ^
  -p:EnableCompressionInSingleFile=true ^
  -p:DebugType=embedded ^
  -o publish\win-x64

if errorlevel 1 (
  echo.
  echo Publish failed. Make sure the .NET 10 SDK is installed:
  echo   https://dotnet.microsoft.com/download
  echo.
  exit /b 1
)

echo.
echo Success.
echo.
echo Share this file:
echo   %cd%\publish\win-x64\MathMentor.exe
echo.
echo Recipients need 64-bit Windows 10 or 11.
echo They do NOT need to install .NET.
echo First launch may take a few seconds while the app unpacks.
echo.
if exist "%cd%\publish\win-x64\MathMentor.exe" (
  for %%A in ("%cd%\publish\win-x64\MathMentor.exe") do echo Size: %%~zA bytes
)
echo.
pause
