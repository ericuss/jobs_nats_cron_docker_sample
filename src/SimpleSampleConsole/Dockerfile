#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/SimpleSampleConsole/SimpleSampleConsole.csproj", "src/SimpleSampleConsole/"]
RUN dotnet restore "src/SimpleSampleConsole/SimpleSampleConsole.csproj"
COPY . .
WORKDIR "/src/src/SimpleSampleConsole"
RUN dotnet build "SimpleSampleConsole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleSampleConsole.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleSampleConsole.dll"]