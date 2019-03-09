# Build
FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine AS build
WORKDIR /app

COPY . .
WORKDIR /app/RestApi
RUN dotnet publish -c Release -o /output

# Runtime
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /output .
EXPOSE 80
ENTRYPOINT ["dotnet", "RestApi.dll"]