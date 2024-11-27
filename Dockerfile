# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Set the working directory in the container
WORKDIR /app

# Copy the entire project into the container
COPY . ./

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Restore dependencies for the specified project
RUN dotnet restore src/Hcd/Hcd.Api

# Expose the port your application listens on
EXPOSE 5555

# Run the application
CMD ["dotnet", "run", "--project", "src/Hcd/Hcd.Api", "--launch-profile", "Production"]