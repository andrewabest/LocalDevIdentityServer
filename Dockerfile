FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

COPY *.sln .
COPY LocalDevIdentityServer/*.csproj ./LocalDevIdentityServer/
RUN dotnet restore

COPY LocalDevIdentityServer/. ./LocalDevIdentityServer/
WORKDIR /app/LocalDevIdentityServer
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/LocalDevIdentityServer/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "LocalDevIdentityServer.dll"]