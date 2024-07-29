# Base image olarak Microsoft'un resmi .NET SDK imaj�n� kullan�yoruz
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build a�amas� i�in Microsoft'un resmi .NET SDK imaj�n� kullan�yoruz
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/silahbackend/WebAPI/WebAPI.csproj", "src/silahbacpkend/WebAPI/"]
COPY ["src/silahbackend/Persistence/Persistence.csproj", "src/silahbackend/Persistence/"]
COPY ["src/silahbackend/Infrastructure/Infrastructure.csproj", "src/silahbackend/Infrastructure/"]
COPY ["src/silahbackend/Domain/Domain.csproj", "src/silahbackend/Domain/"]
COPY ["src/silahbackend/Application/Application.csproj", "src/silahbackend/Application/"]
RUN dotnet restore "src/silahbackend/WebAPI/WebAPI.csproj"
COPY . .
WORKDIR "/src/src/silahbackend/WebAPI"
RUN dotnet build "WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI.csproj" -c Release -o /app/publish

# Final imaj�n� olu�turuyoruz
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.dll"]
