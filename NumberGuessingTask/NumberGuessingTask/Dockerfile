FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NumberGuessingTask/NumberGuessingTask.csproj", "NumberGuessingTask/"]
COPY ["NumberGuessingTask.Core/NumberGuessingTask.Core.csproj", "NumberGuessingTask.Core/"]
COPY ["NumberGuessingTask.Data/NumberGuessingTask.Data.csproj", "NumberGuessingTask.Data/"]
RUN dotnet restore "./NumberGuessingTask/NumberGuessingTask.csproj"
COPY . .
WORKDIR "/src/NumberGuessingTask"
RUN dotnet build "./NumberGuessingTask.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NumberGuessingTask.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NumberGuessingTask.dll"]