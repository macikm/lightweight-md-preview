@echo off
color 0B
echo ===================================================
echo   Installation: Lightweight Markdown Preview
echo ===================================================
echo.

:: Check for Administrator privileges
net session >nul 2>&1
if %errorLevel% neq 0 (
    color 0C
    echo ERROR: This script must be run as Administrator!
    echo Please right-click the file and select "Run as administrator".
    echo.
    pause
    exit
)

set REGASM=%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\regasm.exe
set DLLPATH=%~dp0CustomMdPreview.dll

if not exist "%REGASM%" (
    echo ERROR: System tool regasm.exe was not found.
    pause
    exit
)

echo Registering the library into the Windows Registry...
"%REGASM%" "%DLLPATH%" /codebase /s

echo.
color 0A
echo DONE! 
echo Please restart Outlook or Windows Explorer to see the changes.
echo.
pause