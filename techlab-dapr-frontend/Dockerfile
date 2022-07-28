#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["techlab-dapr-frontend/techlab-dapr-frontend.csproj", "techlab-dapr-frontend/"]
RUN dotnet restore "techlab-dapr-frontend/techlab-dapr-frontend.csproj"
COPY . .
WORKDIR "/src/techlab-dapr-frontend"
RUN dotnet build "techlab-dapr-frontend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "techlab-dapr-frontend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "techlab-dapr-frontend.dll"]