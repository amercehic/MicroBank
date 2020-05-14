#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Document.Api/Document.Api.csproj", "Document.Api/"]
RUN dotnet restore "Document.Api/Document.Api.csproj"
COPY . .
WORKDIR "/src/Document.Api"
RUN dotnet build "Document.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Document.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Document.Api.dll"]