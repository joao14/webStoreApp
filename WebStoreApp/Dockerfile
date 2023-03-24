FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR webstoreapp

EXPOSE 80
EXPOSE 5024

COPY ./*.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /webstoreapp

COPY --from=build /webstoreapp/out
ENTRYPOINT ["dotnet","DockerDotNetApp.dll"]
