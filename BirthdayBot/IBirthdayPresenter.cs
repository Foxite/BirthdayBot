using BirthdayBot;
using DSharpPlus.Entities;

namespace BirthdayBot;

public interface IBirthdayPresenter {
	DiscordWebhookBuilder Present(Birthday birthday);
}
