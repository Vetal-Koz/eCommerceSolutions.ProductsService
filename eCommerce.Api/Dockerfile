FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["eCommerce.Api/eCommerce.Api.csproj", "eCommerce.Api/"]
COPY ["eCommerce.Core/eCommerce.Core.csproj", "eCommerce.Core/"]
COPY ["eCommerce.Infastructure/eCommerce.Infastructure.csproj", "eCommerce.Infastructure/"]
RUN dotnet restore "eCommerce.Api/eCommerce.Api.csproj"
COPY . .
WORKDIR "/src/eCommerce.Api"
RUN dotnet build "eCommerce.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "eCommerce.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV POSTGRES_HOST=localhost
ENV POSTGRES_PASSWORD=12345
ENTRYPOINT ["dotnet", "eCommerce.Api.dll"]
