# BirthdayBot
Reads a csv file with birthdays, and executes a Discord webhook for every entry matching today's date.

Not yet ready for public use. The webhook message is in Dutch.

## Docker deployment
Use in conjunction with [camilin87/docker-cron](https://github.com/cshtdd/docker-cron) or another scheduler.

Environment variables:
- WEBHOOK_URI, required
- CSV_PATH, optional (default is `birthdays.csv` in the current working directory, which is `/app`)

## Csv layout
```csv
Date,Name,Id
2022-07-01 +0000,Display name,969681332697448509
```
