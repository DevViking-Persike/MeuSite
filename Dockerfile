FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY MeuSite.sln ./
COPY src/MeuSite.Shared/MeuSite.Shared.csproj src/MeuSite.Shared/
COPY src/MeuSite.Ui/MeuSite.Ui.csproj src/MeuSite.Ui/
COPY src/MeuSite.Web/MeuSite.Web.csproj src/MeuSite.Web/
RUN dotnet restore src/MeuSite.Web/MeuSite.Web.csproj

COPY src/ src/
RUN dotnet publish src/MeuSite.Web/MeuSite.Web.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:7007
ENV ASPNETCORE_ENVIRONMENT=Production
EXPOSE 7007

ENTRYPOINT ["dotnet", "MeuSite.Web.dll"]
