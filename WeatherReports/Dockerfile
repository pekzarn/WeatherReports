FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WeatherReports/WeatherReports.csproj", "WeatherReports/"]
RUN dotnet restore "WeatherReports/WeatherReports.csproj"
COPY . .
WORKDIR "/src/WeatherReports"
RUN dotnet build "WeatherReports.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherReports.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherReports.dll"]
