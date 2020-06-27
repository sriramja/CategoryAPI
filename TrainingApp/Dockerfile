FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["TariningApp.Service/TrainingApp.Service.csproj", "TariningApp.Service/"]
COPY ["TrainingApp.DataAccess/TrainingApp.DataAccess.csproj", "TrainingApp.DataAccess/"]
COPY ["TrainingApp.Domain/TrainingApp.Domain.csproj", "TrainingApp.Domain/"]
COPY ["TrainingApp/TrainingApp.csproj", "TrainingApp/"]

RUN dotnet restore "TrainingApp/TrainingApp.csproj"
COPY . .
WORKDIR "/src/TrainingApp"
RUN dotnet build "TrainingApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TrainingApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrainingApp.dll"]