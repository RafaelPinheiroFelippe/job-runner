﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ServiceAPI/ServiceAPI.csproj", "ServiceAPI/"]
RUN dotnet restore "ServiceAPI/ServiceAPI.csproj"
COPY . .
WORKDIR "/src/ServiceAPI"
RUN dotnet build "ServiceAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceAPI.dll"]
