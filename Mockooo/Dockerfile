#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Mockooo/Mockooo.csproj", "Mockooo/"]
COPY ["DataExporter/DataExporter/ExporterCSVTSV/ExporterCSVTSV.csproj", "DataExporter/DataExporter/ExporterCSVTSV/"]
COPY ["DataExporter/DataExporter/ExportJSON/ExportJSON.csproj", "DataExporter/DataExporter/ExportJSON/"]
COPY ["DataExporter/DataExporter/ExportMSSQL/ExportMSSQL.csproj", "DataExporter/DataExporter/ExportMSSQL/"]
COPY ["DataExporter/DataExporter/ExportXML/ExportXML.csproj", "DataExporter/DataExporter/ExportXML/"]
RUN dotnet restore "Mockooo/Mockooo.csproj"
COPY . .
WORKDIR "/src/Mockooo"
RUN dotnet build "Mockooo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mockooo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mockooo.dll"]