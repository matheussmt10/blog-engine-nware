# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/BlogEngine.API/BlogEngine.API.csproj", "src/BlogEngine.API/"]
COPY ["src/BlogEngine.Application/BlogEngine.Application.csproj", "src/BlogEngine.Application/"]
COPY ["src/BlogEngine.Communication/BlogEngine.Communication.csproj", "src/BlogEngine.Communication/"]
COPY ["src/BlogEngine.Domain/BlogEngine.Domain.csproj", "src/BlogEngine.Domain/"]
COPY ["src/BlogEngine.Exception/BlogEngine.Exception.csproj", "src/BlogEngine.Exception/"]
COPY ["src/BlogEngine.Infrastructure/BlogEngine.Infrastructure.csproj", "src/BlogEngine.Infrastructure/"]
RUN dotnet restore "./src/BlogEngine.API/BlogEngine.API.csproj"
COPY . .
WORKDIR "/src/src/BlogEngine.API"
RUN dotnet build "./BlogEngine.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BlogEngine.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlogEngine.API.dll"]