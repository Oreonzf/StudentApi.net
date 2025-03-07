# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ./StudentApi/StudentApi.csproj ./StudentApi/
RUN dotnet restore "./StudentApi/StudentApi.csproj"

COPY . .
WORKDIR "/src/StudentApi"
RUN dotnet build "StudentApi.csproj" -c Release -o /app/build

# Publish application
FROM build AS publish
RUN dotnet publish "StudentApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentApi.dll"]
