using DSharpPlus.Entities;

namespace BirthdayBot; 

public record Birthday(int Month, int Day, string Name, ulong Id) {
	public DiscordWebhookBuilder Present() {
		return new DiscordWebhookBuilder()
			.WithContent($"🎉 <@{Id}> Gefeliciteerd met je verjaardag {Name}! 🥳")
			.AddMention(new UserMention(Id));
	}
}
