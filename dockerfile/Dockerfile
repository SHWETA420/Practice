# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file
COPY *.sln .

# Create directory structure
RUN mkdir -p MVCProject Service Repository Common Model WebAPI

# Copy project files
COPY MVCProject/*.csproj ./MVCProject/
COPY Service/*.csproj ./Service/
COPY Repository/*.csproj ./Repository/
COPY Common/*.csproj ./Common/
COPY Model/*.csproj ./Model/
COPY WebAPI/*.csproj ./WebAPI/

# Restore dependencies
RUN dotnet restore "MVCProject/MVCProject.csproj"

# Copy remaining source code
COPY . .

# Build and publish
WORKDIR "/src/MVCProject"
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "MVCProject.dll"]
