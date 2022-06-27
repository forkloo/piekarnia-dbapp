dotnet publish Piekarnia.Api/Piekarnia.Api.csproj -o ./publish
docker build -t piekarniaapi_v2 -f ./Dockerfile-Runtime .
docker-compose up