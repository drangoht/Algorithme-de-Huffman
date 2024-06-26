#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILDPLATFORM
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["huffmanweb.client/nuget.config", "huffmanweb.client/"]
COPY ["HuffmanWeb.Server/HuffmanWeb.Server.csproj", "HuffmanWeb.Server/"]
COPY ["huffmanweb.client/huffmanweb.client.esproj", "huffmanweb.client/"]
RUN dotnet restore "./HuffmanWeb.Server/./HuffmanWeb.Server.csproj"
COPY . .
WORKDIR "/src/HuffmanWeb.Server"
RUN dotnet build "./HuffmanWeb.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HuffmanWeb.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
#ENV ASPNETCORE_URLS="http://*:8080/"
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HuffmanWeb.Server.dll"]