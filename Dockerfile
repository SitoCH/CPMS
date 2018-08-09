FROM microsoft/dotnet:2.1-sdk-alpine AS build
WORKDIR /app

# Install Nodejs
RUN apk update && \
    apk upgrade && \
    apk add nodejs=8.9.3-r1

# copy csproj and restore as distinct layers
COPY *.sln .
COPY CPMS.Common/*.csproj ./CPMS.Common/
COPY CPMS.Web/*.csproj ./CPMS.Web/
RUN dotnet restore
   
# copy package.json and restore as distinct layers
COPY CPMS.Web/*.json ./CPMS.Web/
RUN cd CPMS.Web && npm install && cd ..

# copy everything else and build app
COPY CPMS.Common/. ./CPMS.Common/
COPY CPMS.Web/. ./CPMS.Web/

WORKDIR /app/CPMS.Web

RUN dotnet publish -c Release -o out 

RUN npm run build-prod


FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS runtime
ENV CPMSConnectionString=""
EXPOSE 4000/tcp
WORKDIR /app
COPY --from=build /app/CPMS.Web/out ./
ENTRYPOINT ["dotnet", "CPMS.Web.dll"]