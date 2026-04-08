@echo off
color 0E
echo ===================================================
echo   Uninstallation: Lightweight Markdown Preview
echo ===================================================
echo.

:: Check for Administrator privileges
net session >nul 2>&1
if %errorLevel% neq 0 (
    color 0C
    echo ERROR: This script must be run as Administrator!
    pause
    exit
)

set REGASM=%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\regasm.exe
set DLLPATH=%~dp0CustomMdPreview.dll

echo Removing registry entries...
"%REGASM%" /u "%DLLPATH%" /s

echo.
color 0A
echo DONE! The extension has been successfully uninstalled.
echo.
pause