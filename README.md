# BirthdayBot
Reads a csv file with birthdays, and executes a Discord webhook for every entry matching today's date.

Not yet ready for public use. The webhook message is in Dutch.

## Docker deployment
The docker image comes with cron pre-installed and you can optionally make the bot run on a cron schedule. To do this, use the command `schedule` when starting the container. The cron schedule should be set in the SCHEDULE environment variable.

Alternatively you can run the bot directly by starting the container with `dotnet /app/BirthdayBot.dll` and you could use an external scheduler to start the container.

Environment variables:
- WEBHOOK_URI, required
- CSV_PATH, optional (default is `birthdays.csv` in the current working directory, which is `/app`)
- TZ, optional, but you should set it according to your target audience. Provide a tzdata file relative to /usr/share/zoneinfo (ex: Europe/Paris)
- SCHEDULE, optional, only used if using cron (see above). If not specified, the default will be `0 6 * * *`

## Csv layout
```csv
Month,Day,Id,Name
07,01,969681332697448509,Display name
```
