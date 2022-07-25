# BirthdayBot
Reads a csv file with birthdays, and executes a Discord webhook for every entry matching today's date.

Not yet ready for public use. The webhook message is in Dutch.

## Docker deployment
Use in conjunction with [camilin87/docker-cron](https://github.com/cshtdd/docker-cron) or another scheduler.

Environment variables:
- WEBHOOK_URI, required
- CSV_PATH, optional (default is `birthdays.csv` in the current working directory, which is `/app`)
- TZ, optional, but you should set it according to your target audience. Provide a tzdata file relative to /usr/share/zoneinfo (ex: Europe/Paris)

## Csv layout
```csv
Month,Day,Id,Name
07,01,969681332697448509,Display name
```
