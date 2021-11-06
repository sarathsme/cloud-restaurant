#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CloudRestaurant.API/CloudRestaurant.API.csproj", "CloudRestaurant.API/"]
COPY ["CloudRestaurant.Services/CloudRestaurant.Services.csproj", "CloudRestaurant.Services/"]
COPY ["CloudRestaurant.DAO.MongoDB/CloudRestaurant.DAO.MongoDB.csproj", "CloudRestaurant.DAO.MongoDB/"]
COPY ["CloudRestaurant.Shared/CloudRestaurant.Shared.csproj", "CloudRestaurant.Shared/"]
RUN dotnet restore "CloudRestaurant.API/CloudRestaurant.API.csproj"
COPY . .
WORKDIR "/src/CloudRestaurant.API"
RUN dotnet build "CloudRestaurant.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudRestaurant.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudRestaurant.API.dll"]