FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["CheckIpDotNet/CheckIpDotNet.csproj", "CheckIpDotNet/"]
RUN dotnet restore "CheckIpDotNet/CheckIpDotNet.csproj"
COPY . .
WORKDIR "/src/CheckIpDotNet"
RUN dotnet build "CheckIpDotNet.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CheckIpDotNet.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CheckIpDotNet.dll"]