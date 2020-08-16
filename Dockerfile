#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Mastrowi.cz.Api.csproj", ""]
RUN dotnet restore "./Mastrowi.cz.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Mastrowi.cz.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mastrowi.cz.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mastrowi.cz.Api.dll"]