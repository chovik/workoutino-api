FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Workoutino/Workoutino.csproj", "Workoutino/"]
RUN dotnet restore "Workoutino/Workoutino.csproj"
COPY . .
WORKDIR "/src/Workoutino"
RUN dotnet build "Workoutino.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Workoutino.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Workoutino.dll"]