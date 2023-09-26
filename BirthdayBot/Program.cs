using BirthdayBot;
using DSharpPlus;
using DSharpPlus.Entities;

IClock clock = new SystemClock();
IBirthdayProvider birthdayProvider = new CsvBirthdayProvider(Environment.GetEnvironmentVariable("CSV_PATH") ?? "birthdays.csv");
ICollection<Birthday> birthdays = await birthdayProvider.GetBirthdays(clock);

if (birthdays.Count > 0) {
	var discord = new DiscordWebhookClient();
	DiscordWebhook webhook = await discord.AddWebhookAsync(new Uri(Environment.GetEnvironmentVariable("WEBHOOK_URI")!));

	foreach (Birthday birthday in birthdays) {
		await webhook.ExecuteAsync(birthday.Present());
	}
}
