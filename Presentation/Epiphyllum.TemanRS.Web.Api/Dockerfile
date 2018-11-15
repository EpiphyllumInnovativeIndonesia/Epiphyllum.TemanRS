FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Presentation/Epiphyllum.TemanRS.Web.Api/Epiphyllum.TemanRS.Web.Api.csproj", "Presentation/Epiphyllum.TemanRS.Web.Api/"]
RUN dotnet restore "Presentation/Epiphyllum.TemanRS.Web.Api/Epiphyllum.TemanRS.Web.Api.csproj"
COPY . .
WORKDIR "/src/Presentation/Epiphyllum.TemanRS.Web.Api"
RUN dotnet build "Epiphyllum.TemanRS.Web.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Epiphyllum.TemanRS.Web.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Epiphyllum.TemanRS.Web.Api.dll"]