# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj files and restore dependencies
COPY ./*.sln ./
COPY Application/*.csproj ./Application/
COPY Domain/*.csproj ./Domain/
COPY Infrastructure/*.csproj ./Infrastructure/
COPY Common/*.csproj ./Common/
COPY Kanban/*.csproj ./Kanban/

RUN dotnet restore

# Copy the rest of the source code
COPY . .

# Build the app
RUN dotnet publish Kanban/Kanban.csproj -c Release -o /out

# Use ASP.NET runtime to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out ./

# Set environment variables (can be overridden by docker-compose)
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Kanban.dll"]
