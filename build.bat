@echo off
echo Building InvoiceApp executable...
echo.

REM Clean previous builds
dotnet clean

REM Build with detailed logging
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -v detailed

if %errorlevel% equ 0 (
    echo.
    echo Build successful! Check for errors in the log above.
    echo.
    echo To run the application:
    echo 1. Open Command Prompt
    echo 2. Navigate to:
    echo    cd bin\Release\net6.0-windows\win-x64\publish
    echo 3. Run: InvoiceApp.exe
    echo.
    echo This will show any error messages if the app fails to start.
) else (
    echo.
    echo Build failed. Check the error messages above.
)

pause