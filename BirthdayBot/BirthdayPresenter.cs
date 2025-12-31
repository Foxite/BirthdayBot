using DSharpPlus.Entities;

namespace BirthdayBot; 

public class BirthdayPresenter : IBirthdayPresenter {
	private readonly string? m_PingMessageFormat;
	private readonly string? m_NonPingMessageFormat;
	
	public BirthdayPresenter(string? pingMessageFormat, string? nonPingMessageFormat) {
		m_PingMessageFormat = pingMessageFormat;
		m_NonPingMessageFormat = nonPingMessageFormat;
	}
	
	public DiscordWebhookBuilder Present(Birthday birthday) {
		string messageContent;
		if (birthday.Id == 0) {
			string messageFormat = m_NonPingMessageFormat ?? "🎉 Gefeliciteerd met je verjaardag {0}! 🥳";
			messageContent = string.Format(messageFormat, birthday.Name);
		} else {
			string messageFormat = m_PingMessageFormat ?? "🎉 <@{0}> Gefeliciteerd met je verjaardag {1}! 🥳";
			messageContent = string.Format(messageFormat, birthday.Id, birthday.Name);
		}

		return new DiscordWebhookBuilder()
			.WithContent(messageContent)
			.AddMention(new UserMention(birthday.Id));
	}
}
