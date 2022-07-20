FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BirthdayBot/BirthdayBot.csproj", "BirthdayBot/"]
RUN dotnet restore "BirthdayBot/BirthdayBot.csproj"
COPY . .
RUN dotnet build "BirthdayBot/BirthdayBot.csproj" -c Release -o /app/build && \
    dotnet test "BirthdayBot.Tests/BirthdayBot.Tests.csproj"

FROM build AS publish
RUN dotnet publish "BirthdayBot/BirthdayBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "BirthdayBot.dll"]
