# Start from the sdk image
FROM mcr.microsoft.com/dotnet/sdk:6.0.102-alpine3.14@sha256:8d15f73dcd72485cc89e59cf0fa2e97ef016c4500164dd26b71cea6d532b8134 AS build

# Set the working directory to where the source is located
WORKDIR /dicom-cast/src

# Copy everything
COPY ./ ./

# Execute a dotnet build and publish the hosting project
RUN dotnet build "./converter/dicom-cast/src/Microsoft.Health.DicomCast.Hosting/Microsoft.Health.DicomCast.Hosting.csproj" --configuration Release -warnaserror
RUN dotnet publish "./converter/dicom-cast/src/Microsoft.Health.DicomCast.Hosting/Microsoft.Health.DicomCast.Hosting.csproj" -c Release -o "/.build" --no-build

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0.2-alpine3.14@sha256:7f9385ad945d06b35bc93b3d91a2be3e65a921ff0c872f6982b01b27088c4149 AS runtime

RUN set -x && \
    addgroup nonroot && \
    adduser -S -D -H -s /sbin/nologin -G nonroot -g nonroot nonroot

# Set the workiting directory and copy the build
WORKDIR /app
COPY --from=build .build .

# Expose and start the web app on port 8080
USER nonroot
ENTRYPOINT ["dotnet", "Microsoft.Health.DicomCast.Hosting.dll"]
