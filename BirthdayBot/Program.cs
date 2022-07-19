using System.Globalization;
using BirthdayBot;
using CsvHelper;
using CsvHelper.Configuration;
using DSharpPlus;
using DSharpPlus.Entities;

using var csvReader = new CsvReader(File.OpenText(Environment.GetEnvironmentVariable("CSV_PATH") ?? "birthdays.csv"), new CsvConfiguration(CultureInfo.InvariantCulture));
csvReader.Read();
csvReader.ReadHeader();

List<Birthday> birthdays = csvReader.GetRecords<Birthday>()
	.Where(birthday => birthday.Date.Date == DateTimeOffset.Now.Date).ToList();

if (birthdays.Count > 0) {
	var discord = new DiscordWebhookClient();
	DiscordWebhook webhook = await discord.AddWebhookAsync(new Uri(Environment.GetEnvironmentVariable("WEBHOOK_URI")!));

	foreach (Birthday birthday in birthdays) {
		await webhook.ExecuteAsync(birthday.Present());
	}
}
