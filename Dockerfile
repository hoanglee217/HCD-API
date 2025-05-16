# Use the official .NET SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy the entire project into the container
COPY . ./

COPY .env .env

# Install dotnet-ef globally
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Restore dependencies
RUN dotnet restore src/Hcd/Hcd.Api

# Publish the application
RUN dotnet publish src/Hcd/Hcd.Api -c Release -o out

# Use the official .NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the published files
COPY --from=build-env /app/out .

# Expose the port
EXPOSE 5555

# Start the application
CMD ["dotnet", "Hcd.Api.dll"]