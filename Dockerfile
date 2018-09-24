FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

COPY *.sln .
COPY DockerIdentityServer/*.csproj ./DockerIdentityServer/
RUN dotnet restore

COPY DockerIdentityServer/. ./DockerIdentityServer/
WORKDIR /app/DockerIdentityServer
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/DockerIdentityServer/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "DockerIdentityServer.dll"]