# -------- Stage 1: Build --------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy .csproj files and restore dependencies
COPY *.sln .
COPY SmartTaskManager/*.csproj ./SmartTaskManager/
RUN dotnet restore

# Copy the remaining source code
COPY SmartTaskManager/. ./SmartTaskManager/

# Build and publish the app
WORKDIR /src/SmartTaskManager
RUN dotnet publish -c Release -o /app/publish

# -------- Stage 2: Runtime --------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published output from the build stage
COPY --from=build /app/publish .

# Expose the port (optional, depending on Render setup)
EXPOSE 80

# Entry point
ENTRYPOINT ["dotnet", "SmartTaskManager.dll"]
