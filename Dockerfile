FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine

ENV CPMSConnectionString=""

EXPOSE 4000/tcp

COPY /artifacts /app

ENTRYPOINT ["dotnet", "CPMS.Web.dll"]
