# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY ./publish /app
EXPOSE 5001
ENV ASPNETCORE_URLS=http://*:5001
ENTRYPOINT ["dotnet", "ActiveDirectoryAPI.dll"]
