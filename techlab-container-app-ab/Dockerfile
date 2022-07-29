#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["techlab-container-app-ab/techlab-container-app-ab.csproj", "techlab-container-app-ab/"]
RUN dotnet restore "techlab-container-app-ab/techlab-container-app-ab.csproj"
COPY . .
WORKDIR "/src/techlab-container-app-ab"
RUN dotnet build "techlab-container-app-ab.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "techlab-container-app-ab.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "techlab-container-app-ab.dll"]