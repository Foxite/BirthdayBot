namespace BirthdayBot.Tests;

public class MockBirthdayProvider : MemoryBirthdayProvider {
	private readonly ICollection<Birthday> m_Birthdays;

	public MockBirthdayProvider(ICollection<Birthday> birthdays) {
		m_Birthdays = birthdays;
	}

	protected override ICollection<Birthday> ReadBirthdays() {
		return m_Birthdays;
	}
}
