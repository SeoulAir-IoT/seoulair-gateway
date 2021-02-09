FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy of csproj and restore  as distinct layers
COPY *.sln .
COPY ./src/SeoulAir.Gateway.Api/*.csproj ./src/SeoulAir.Gateway.Api/
COPY ./src/SeoulAir.Gateway.Domain/*.csproj ./src/SeoulAir.Gateway.Domain/
COPY ./src/SeoulAir.Gateway.Domain.Services/*.csproj ./src/SeoulAir.Gateway.Domain.Services/

RUN dotnet restore

# copy everything else and build app
COPY *.sln .
COPY ./src/SeoulAir.Gateway.Api/. ./src/SeoulAir.Gateway.Api/
COPY ./src/SeoulAir.Gateway.Domain/. ./src/SeoulAir.Gateway.Domain/
COPY ./src/SeoulAir.Gateway.Domain.Services/. ./src/SeoulAir.Gateway.Domain.Services/

WORKDIR /app/src/SeoulAir.Gateway.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app

COPY --from=build /app/src/SeoulAir.Gateway.Api/out ./
ENV ASPNETCORE_URLS=http://+:5900
ENTRYPOINT ["dotnet","SeoulAir.Gateway.Api.dll"]
