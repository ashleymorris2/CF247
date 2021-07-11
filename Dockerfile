FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

EXPOSE 5001

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Debug -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "CF247TechTest.API.dll"]