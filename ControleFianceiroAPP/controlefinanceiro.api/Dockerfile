# Etapa base para runtime Linux
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Etapa de build SDK Linux
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["controlefinanceiro.api/controlefinanceiro.api.csproj", "controlefinanceiro.api/"]
RUN dotnet restore "./controlefinanceiro.api/controlefinanceiro.api.csproj"
COPY . .
WORKDIR "/src/controlefinanceiro.api"
RUN dotnet build "./controlefinanceiro.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./controlefinanceiro.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final runtime
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "controlefinanceiro.api.dll"]
