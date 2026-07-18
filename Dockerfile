FROM mcr.microsoft.com/dotnet/runtime:10.0-nanoserver-ltsc2022 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0-nanoserver-ltsc2022 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Dzien1.csproj", "./"]
RUN dotnet restore "Dzien1.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Dzien1.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Dzien1.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dzien1.dll"]
