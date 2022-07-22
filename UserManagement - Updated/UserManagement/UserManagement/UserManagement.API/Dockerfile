FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet build
RUN dotnet publish -c Release -o outdir

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS final
WORKDIR /app
COPY --from=build /src/outdir .
ENTRYPOINT ["dotnet", "MVCDocker.dll"]

