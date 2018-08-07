FROM microsoft/dotnet:2.1-sdk-alpine AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY CPMS.Common/*.csproj ./CPMS.Common/
COPY CPMS.Web/*.csproj ./CPMS.Web/
RUN dotnet restore

# copy everything else and build app
COPY CPMS.Common/. ./CPMS.Common/
COPY CPMS.Web/. ./CPMS.Web/
WORKDIR /app/CPMS.Web
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS runtime
ENV CPMSConnectionString=""
WORKDIR /app
COPY --from=build /app/CPMS.Web/out ./
ENTRYPOINT ["dotnet", "CPMS.Web.dll"]