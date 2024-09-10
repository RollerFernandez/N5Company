#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/services/permissions/N5.Management.Permissions.Api/N5.Management.Permissions.Api.csproj", "src/services/permissions/N5.Management.Permissions.Api/"]
COPY ["src/SharedKernel/Infrastructure/Messaging/Kafka/N5.Management.SharedKernel.Infrastructure.Messaging.Kafka/N5.Management.SharedKernel.Infrastructure.Messaging.Kafka.csproj", "src/SharedKernel/Infrastructure/Messaging/Kafka/N5.Management.SharedKernel.Infrastructure.Messaging.Kafka/"]
COPY ["src/SharedKernel/Core/N5.Management.Commons/N5.Management.Commons.csproj", "src/SharedKernel/Core/N5.Management.Commons/"]
COPY ["src/SharedKernel/Infrastructure/Services/ElasticsearchService/N5.Management.SharedKernel.Infrastructure.Elasticsearch/N5.Management.SharedKernel.Infrastructure.Elasticsearch.csproj", "src/SharedKernel/Infrastructure/Services/ElasticsearchService/N5.Management.SharedKernel.Infrastructure.Elasticsearch/"]
COPY ["src/services/permissions/N5.Management.Permissions.Application/N5.Management.Permissions.Application.csproj", "src/services/permissions/N5.Management.Permissions.Application/"]
COPY ["src/SharedKernel/Core/N5.Management.Infrastructure/N5.Management.Infrastructure.csproj", "src/SharedKernel/Core/N5.Management.Infrastructure/"]
COPY ["src/SharedKernel/Core/N5.Management.Domain/N5.Management.Domain.csproj", "src/SharedKernel/Core/N5.Management.Domain/"]
COPY ["src/services/permissions/N5.Management.Permissions.Domain/N5.Management.Permissions.Domain.csproj", "src/services/permissions/N5.Management.Permissions.Domain/"]
COPY ["src/services/permissions/N5.Management.Permissions.Infrastructure/N5.Management.Permissions.Infrastructure.csproj", "src/services/permissions/N5.Management.Permissions.Infrastructure/"]
RUN dotnet restore "./src/services/permissions/N5.Management.Permissions.Api/N5.Management.Permissions.Api.csproj"
COPY . .
WORKDIR "/src/src/services/permissions/N5.Management.Permissions.Api"
RUN dotnet build "./N5.Management.Permissions.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./N5.Management.Permissions.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "N5.Management.Permissions.Api.dll"]