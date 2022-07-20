namespace BirthdayBot;

/// <summary>
/// Given an <see cref="IClock"/>, provides today's birthdays.
/// </summary>
public interface IBirthdayProvider {
	Task<ICollection<Birthday>> GetBirthdays(IClock clock);
}
