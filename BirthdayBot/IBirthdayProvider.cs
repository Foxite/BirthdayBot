namespace BirthdayBot;

public interface IBirthdayProvider {
	Task<ICollection<Birthday>> GetBirthdays(IClock clock);
}
