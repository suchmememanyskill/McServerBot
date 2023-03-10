# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY McServerBot/*.csproj ./McServerBot/
RUN dotnet restore

# copy everything else and build app
COPY McServerBot/. ./McServerBot/
WORKDIR /source/McServerBot
RUN dotnet publish -c release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /app
COPY --from=build /app ./

ENV prefix=mc!
ENTRYPOINT ["dotnet", "McServerBot.dll"]
