#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["nutrifit.Api/Nutrifit.Api.csproj", "nutrifit.Api/"]
COPY ["nutrifit.Domain/Nutrifit.Domain.csproj", "nutrifit.Domain/"]
COPY ["nutrifit.Infra.CrossCutting.Ioc/Nutrifit.Infra.CrossCutting.Ioc.csproj", "nutrifit.Infra.CrossCutting.Ioc/"]
COPY ["nutrifit.Infra.Data/Nutrifit.Infra.Data.csproj", "nutrifit.Infra.Data/"]
COPY ["nutrifit.Infra.CrossCutting/Nutrifit.Infra.CrossCutting.csproj", "nutrifit.Infra.CrossCutting/"]
COPY ["nutrifit.Service/Nutrifit.Service.csproj", "nutrifit.Service/"]
RUN dotnet restore "./nutrifit.Api/./Nutrifit.Api.csproj"
COPY . .
WORKDIR "/src/nutrifit.Api"
RUN dotnet build "./Nutrifit.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Nutrifit.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nutrifit.Api.dll"]