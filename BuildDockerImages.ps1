Set-Location C:\Proyectos\DockerPoC\ActiveDirectoryAPI;
dotnet publish -c Release -o publish;
docker build . --tag activedirectoryapi:latest;
Set-Location C:\Proyectos\DockerPoC\IdentityAPI;
dotnet publish -c Release -o publish;
docker build . --tag identityapi:latest;
Set-Location C:\Proyectos\DockerPoC;