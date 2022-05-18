#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WEBClient/Proiect_PWEB.Api.csproj", "WEBClient/"]
COPY ["Core/Proiect_PWEB.Core.csproj", "Core/"]
COPY ["Proiect_PWEB.Infrastructure/Proiect_PWEB.Infrastructure.csproj", "Proiect_PWEB.Infrastructure/"]
RUN dotnet restore "WEBClient/Proiect_PWEB.Api.csproj"
COPY . .
WORKDIR "/src/WEBClient"
RUN dotnet build "Proiect_PWEB.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Proiect_PWEB.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Proiect_PWEB.Api.dll"]
