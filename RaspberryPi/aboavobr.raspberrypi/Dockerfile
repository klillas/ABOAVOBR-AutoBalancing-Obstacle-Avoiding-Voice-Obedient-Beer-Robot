FROM aboavobr/raspberry-env AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["aboavobr.raspberrypi/aboavobr.raspberrypi.csproj", "aboavobr.raspberrypi/"]
RUN dotnet restore "aboavobr.raspberrypi/aboavobr.raspberrypi.csproj"
COPY . .
WORKDIR "/src/aboavobr.raspberrypi"
RUN dotnet build "aboavobr.raspberrypi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "aboavobr.raspberrypi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "aboavobr.raspberrypi.dll"]