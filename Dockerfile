FROM mcr.microsoft.com/dotnet/sdk:6.0
COPY . /app
WORKDIR /app
RUN dotnet restore
RUN dotnet publish ./Piekarnia.Api/Piekarnia.Api.csproj -o /publish
WORKDIR /publish
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Piekarnia.Api.dll
