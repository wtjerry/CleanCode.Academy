FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy and publish app and libraries
COPY . .
RUN dotnet publish -c Release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "CleanCode.Academy.ServiceHost.dll"]
