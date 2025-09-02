#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS base
WORKDIR /app
EXPOSE 8080
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y build-essential curl libgl1-mesa-glx libjpeg-dev libpng-dev libxi6
RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
ARG BUILDPLATFORM
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs

# Install latest npm and required tools
RUN npm install -g npm@latest
RUN npm install -g node-gyp
RUN apt-get install -y build-essential python3

ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Add a step to clean and rebuild node_modules
RUN mkdir -p /src/huffmanweb.client
COPY ["src/HuffmanWeb/huffmanweb.client/nuget.config", "huffmanweb.client/"]
COPY ["src/HuffmanWeb/HuffmanWeb.Server/HuffmanWeb.Server.csproj", "HuffmanWeb.Server/"]
COPY ["src/HuffmanWeb/HuffmanWeb.Algorithm/HuffmanWeb.Algorithm.csproj", "HuffmanWeb.Algorithm/"]
COPY ["src/HuffmanWeb/HuffmanWeb.Common/HuffmanWeb.Common.csproj", "HuffmanWeb.Common/"]
COPY ["src/HuffmanWeb/huffmanweb.client/huffmanweb.client.esproj", "huffmanweb.client/"]
RUN dotnet restore "HuffmanWeb.Server/HuffmanWeb.Server.csproj"
COPY src/HuffmanWeb/. .

# Clean and rebuild node_modules
WORKDIR "/src/huffmanweb.client"
RUN rm -rf node_modules package-lock.json
RUN npm install
RUN npm rebuild

WORKDIR "/src/HuffmanWeb.Server"
RUN dotnet build "./HuffmanWeb.Server.csproj" -c "$BUILD_CONFIGURATION" -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HuffmanWeb.Server.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
#ENV ASPNETCORE_URLS="http://*:8080/"
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HuffmanWeb.Server.dll"]