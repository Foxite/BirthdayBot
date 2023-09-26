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
RUN apt update && apt -y install cron dumb-init
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["BirthdayBot/docker/bin/", "/usr/local/bin/"]
RUN bash -c 'chmod +x /usr/local/bin/{run_on_schedule,schedule}'

ENTRYPOINT ["/usr/bin/dumb-init", "--"]
CMD ["dotnet", "BirthdayBot.dll"]
