# Use the .NET SDK for building
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy necessary directories and build
COPY Controllers/ Controllers/
COPY Data/ Data/
COPY Models/ Models/
COPY Properties/ Properties/
COPY Repositories/ Repositories/
COPY *.cs ./
RUN dotnet publish -c Release -o out

# Copy wait-for-it.sh to the Docker image
COPY wait-for-it.sh wait-for-it.sh
RUN chmod +x wait-for-it.sh

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
COPY --from=build-env /app/wait-for-it.sh .
ENV ASPNETCORE_URLS=http://*:5233
# Use wait-for-it.sh to start your application
CMD ["./wait-for-it.sh", "mysql:3306", "--", "dotnet", "DotNet.Docker.dll"]