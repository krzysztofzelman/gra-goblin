FROM mcr.microsoft.com/dotnet/runtime:10.0-nanoserver-ltsc2022 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0-nanoserver-ltsc2022 AS build
ARG configuration=Release
WORKDIR /src
COPY ["GraGoblin.csproj", "./"]
RUN dotnet restore "GraGoblin.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "GraGoblin.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "GraGoblin.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GraGoblin.dll"]
