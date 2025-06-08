# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy solution and restore
COPY SmartTaskManager/SmartTaskManager.sln .
COPY SmartTaskManager/SmartTaskManager/*.csproj ./SmartTaskManager/
RUN dotnet restore SmartTaskManager.sln

# Copy everything else and build
COPY SmartTaskManager/. ./SmartTaskManager/
WORKDIR /src/SmartTaskManager
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SmartTaskManager.dll"]
