using DSharpPlus.Entities;

namespace BirthdayBot; 

public class BirthdayPresenter : IBirthdayPresenter {
	private readonly string? m_MessageFormat;
	
	public BirthdayPresenter(string? messageFormat) {
		m_MessageFormat = messageFormat;
	}
	
	public DiscordWebhookBuilder Present(Birthday birthday) {
		string messageFormat = m_MessageFormat ?? "🎉 <@{0}> Gefeliciteerd met je verjaardag {1}! 🥳";
		string messageContent = string.Format(messageFormat, birthday.Id, birthday.Name);
		
		return new DiscordWebhookBuilder()
			.WithContent(messageContent)
			.AddMention(new UserMention(birthday.Id));
	}
}
