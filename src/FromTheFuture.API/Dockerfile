FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FromTheFuture.API/FromTheFuture.API.csproj", "FromTheFuture.API/"]
COPY ["FromTheFuture.Domain/FromTheFuture.Domain.csproj", "FromTheFuture.Domain/"]
COPY ["FromTheFuture.Infrastructure/FromTheFuture.Infrastructure.csproj", "FromTheFuture.Infrastructure/"]
RUN dotnet restore "FromTheFuture.API/FromTheFuture.API.csproj"
COPY . .
WORKDIR "/src/FromTheFuture.API"
RUN dotnet build "FromTheFuture.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FromTheFuture.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FromTheFuture.API.dll"]