#!/bin/bash
set -e

echo "Applying EF Core migrations..."
dotnet ef database update --project eCommerce.Infastructure --startup-project eCommerce.Api

echo "Starting the app..."
dotnet eCommerce.Api.dll
