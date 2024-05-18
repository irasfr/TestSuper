#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
EXPOSE 8080
EXPOSE 8081

# Устанавливаем MediatR версии 11.0.0
RUN dotnet add package MediatR --version 11.0.0

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ENV BUILD_CONFIGURATION=Release
COPY ["WebApi/WebApi.csproj", "WebApi/"]
RUN dotnet restore "./WebApi/WebApi.csproj"
COPY . .
RUN dotnet build "./WebApi.csproj" -c $BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ENV BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApi.csproj" -c $BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]