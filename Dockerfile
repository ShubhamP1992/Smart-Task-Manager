# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy everything to the container
COPY . .

# Restore dependencies
RUN dotnet restore SmartTaskManager.sln

# Build and publish the app
RUN dotnet publish SmartTaskManager.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copy build output from the build stage
COPY --from=build /app/publish .

# Start the app
ENTRYPOINT ["dotnet", "SmartTaskManager.dll"]
